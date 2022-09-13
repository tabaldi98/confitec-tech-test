import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { SystemUserService } from 'src/app/core/authentication/system-user.service';
import { SnackBarService } from 'src/app/core/snack-bar/snack-bar.service';
import { GridComponent } from 'src/app/shared/grid/grid.component';
import { GridColumnType, GridConfig } from 'src/app/shared/grid/models/grid-columns.model';
import { IGridModel } from 'src/app/shared/grid/models/grid.model';
import { ConfirmDeleteComponent } from '../confirm-delete/confirm-delete.component';
import { SystemUser } from '../shared/system-user.model';

@Component({
  selector: 'app-system-user',
  templateUrl: './system-user-grid.component.html',
  styleUrls: ['./system-user-grid.component.scss']
})
export class SystemUserGridComponent implements OnInit {
  gridConfig?: GridConfig;
  isLoading: boolean = false;
  rowsSelected: IGridModel[] = [];

  @ViewChild(GridComponent) grid!: GridComponent;

  constructor(
    public dialog: MatDialog,
    public userService: SystemUserService,
    private router: Router,
    private snackBarService: SnackBarService
  ) { }

  ngOnInit(): void {
    this.gridConfig = {
      actions: [
        {
          title: 'Deletar',
          icon: 'delete',
          callback: (): void => {
            this.onDeleteCheckeds();
          }
        },],
      columns: [
        {
          field: 'userName',
          title: 'Login',
          size: '20%',
          type: GridColumnType.LinkButton,
          callback: (user: SystemUser): void => {
            this.analyseSystemUser(user);
          },
          cell: (user: SystemUser) => `${user.userName}`,
          hideOnMobile: false,
          filtered: true,
        },
        {
          field: 'fullName',
          title: 'Nome completo',
          size: '30%',
          type: GridColumnType.Text,
          cell: (user: SystemUser) => `${user.fullName}`,
          hideOnMobile: false,
          filtered: true,
        },
        {
          field: 'mail',
          title: 'E-mail',
          size: '10%',
          type: GridColumnType.Text,
          cell: (user: SystemUser) => `${user.mail}`,
          hideOnMobile: false,
          filtered: true,
        },
        {
          field: 'isAproved',
          title: 'Status',
          size: '10%',
          type: GridColumnType.BooleanWithIcon,
          cell: (user: SystemUser) => `${user.isAproved}`,
          customFormat: (user: SystemUser) => user.isAproved ? 'Habilitado' : 'Desabilitado',
          hideOnMobile: false,
          filtered: false,
        },
      ]
    }
  }

  // Grid Events
  onAllRowsChecked(allChecked: boolean): void {
    if (allChecked) {
      this.rowsSelected.push(...this.grid.data);
    } else {
      this.rowsSelected = [];
    }
  }

  onRowChecked(user: SystemUser): void {
    if (user.checked) {
      this.rowsSelected.push(user);
    } else {
      this.rowsSelected = this.rowsSelected.filter(p => p.id !== user.id);
    }
  }

  onAddUser(): void {
    this.router.navigate(['/system-users/create']);
  }

  analyseSystemUser(element: SystemUser): void {
    this.router.navigate([`/system-users/${element.id}`]);
  }

  onDeleteCheckeds(): void {
    if (!this.rowsSelected.some((user: IGridModel) => user.checked)) { return; }

    if (this.rowsSelected.some((user: IGridModel) => user.id === 1)) {
      this.snackBarService.showErrorSnackBar('Não é possível deletar o usuário principal do sistema!');
      return;
    }
    if (this.rowsSelected.find((user: IGridModel) => user.checked)) {

      const dialogRef = this.dialog.open(ConfirmDeleteComponent, {
        width: '250px',
        data: null
      });

      dialogRef.afterClosed()
        .subscribe(
          result => {
            if (result) {
              this.isLoading = true;
              this.isLoading = true;
              const usersIds: number[] = this.rowsSelected.map((user: IGridModel) => user.id);
              this.userService
                .delete({ iDs: usersIds })
                .subscribe(() => {
                  this.grid.refreshGrid();
                  this.isLoading = false;
                });
            }
          });
    }
  }
}
