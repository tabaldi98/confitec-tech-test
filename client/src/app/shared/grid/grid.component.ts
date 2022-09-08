import { moveItemInArray } from '@angular/cdk/drag-drop';
import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { GridColumn, GridConfig } from './models/grid-columns.model';
import { IGridModel } from './models/grid.model';

@Component({
  selector: 'app-grid',
  templateUrl: './grid.component.html',
  styleUrls: ['./grid.component.scss']
})
export class GridComponent implements OnInit {
  @Input() public config?: GridConfig;
  @Input() public data: any[] = [];
  @Output() public onRowChecked: EventEmitter<any> = new EventEmitter<any>();
  @Output() public onAllRowsChecked: EventEmitter<boolean> = new EventEmitter<boolean>();

  displayedColumns: string[] = [];
  dataSource!: MatTableDataSource<any>;
  allChecked: boolean = false;
  clickedRows = new Set<any>();

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor() { }

  ngOnInit(): void {
    setTimeout(() => {
      this.dataSource = new MatTableDataSource(this.data);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;

      this.displayedColumns.push('check');
      this.displayedColumns.push(...this.config?.columns.map((x: GridColumn) => x.field) ?? '');
    }, 0);
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

  onPageEvent(page: any): void {
    //debugger;
  }
}
