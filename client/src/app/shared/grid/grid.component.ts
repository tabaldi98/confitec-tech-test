import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { GridColumn, GridConfig } from './models/grid-columns.model';
import { IGridModel } from './models/grid.model';
import { IODataModel } from './models/odata.model';
import { GridODataService } from './shared/grid-odata.service';

@Component({
  selector: 'app-grid',
  templateUrl: './grid.component.html',
  styleUrls: ['./grid.component.scss']
})
export class GridComponent implements OnInit {
  @Input() public config?: GridConfig;
  @Input() public data: IGridModel[] = [];
  @Input() public router: string = '';
  @Output() public onRowChecked: EventEmitter<any> = new EventEmitter<any>();
  @Output() public onAllRowsChecked: EventEmitter<boolean> = new EventEmitter<boolean>();

  displayedColumns: string[] = [];
  dataSource!: MatTableDataSource<any>;
  allChecked: boolean = false;
  clickedRows = new Set<any>();
  isLoading: boolean = true;

  top: number = 100;
  skip: number = 0;
  field: string = 'id';
  direction: string = 'asc';

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private gridService: GridODataService) { }

  ngOnInit(): void {
    this.startGrid();
  }

  startGrid(): void {
    this.gridService.get(this.generateQuery())
      .subscribe((data: IODataModel<any>) => {
        this.dataSource = new MatTableDataSource(data.value);
        this.isLoading = false;

        setTimeout(() => {
          this.dataSource.paginator = this.paginator;
          this.dataSource.sort = this.sort;

          this.displayedColumns.push('check');
          this.displayedColumns.push(...this.config?.columns.map((x: GridColumn) => x.field) ?? '');

          this.sort.sortChange.subscribe((sort: Sort) => {
            this.onSortChange(sort.active, sort.direction.toString());
          })
        }, 0);
      })
  } 
  
  refreshGrid(): void {
    this.gridService.get(this.generateQuery())
      .subscribe((data: IODataModel<any>) => {
        this.dataSource = new MatTableDataSource(data.value);
        this.isLoading = false;
      })
  }

  onCallbackAction(column: GridColumn, value: any): void {
    if (column.callback) {
      column?.callback(value);
    }
  }

  setAll(checked: boolean): void {
    this.dataSource.data.forEach((model: IGridModel) => {
      model.checked = checked;
    })

    this.onAllRowsChecked.emit(checked);
  }

  setItem(model: IGridModel): void {
    model.checked = !model.checked;

    const index: number = this.dataSource.data.findIndex((x: IGridModel) => x.id === model.id);
    this.dataSource.data[index] = model;

    this.onRowChecked.emit(model);
  }

  applyFilter(event: Event): void {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  onSortChange(field: string, direction: string): void {
    this.field = field;
    this.direction = direction === '' ? 'asc' : direction;

    this.refreshGrid();
  }

  onPageEvent(page: any): void {
    this.top = page.pageSize;
    this.skip = page.pageIndex;

    this.refreshGrid();
  }

  generateQuery(): string {
    return `${this.router}?count=true&top=${this.top}&skip=${this.skip}&orderby=${this.field} ${this.direction}`
  }
}
