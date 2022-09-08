import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { GridColumnType, GridConfig } from 'src/app/shared/grid/models/grid-columns.model';
import { ConfirmDeleteComponent } from '../confirm-delete/confirm-delete.component';
import { formatScholarity, User } from '../shared/user.model';
import { UserService } from '../shared/user.service';

@Component({
  selector: 'app-home-user',
  templateUrl: './home-user.component.html',
  styleUrls: ['./home-user.component.scss'],
})
export class HomeUserComponent implements OnInit {
  data: User[] = [];
  gridConfig?: GridConfig;
  isLoading: boolean = true;
  rowsSelected: User[] = [];

  constructor(
    public dialog: MatDialog,
    public userService: UserService,
    private router: Router,
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
        },
        {
          title: 'Adicionar',
          icon: 'add',
          callback: (): void => {
            this.onAddUser();
          }
        },
      ],
      columns: [
        {
          field: 'name',
          title: 'Nome',
          size: '30%',
          type: GridColumnType.LinkButton,
          callback: (user: User): void => {
            this.editElement(user);
          },
          cell: (user: User) => `${user.name}`,
          hideOnMobile: false,
        },
        {
          field: 'surname',
          title: 'Sobrenome',
          size: '15%',
          type: GridColumnType.Text,
          cell: (user: User) => `${user.surname}`,
          hideOnMobile: false,
        },
        {
          field: 'mail',
          title: 'E-mail',
          size: '10%',
          type: GridColumnType.Text,
          cell: (user: User) => `${user.mail}`,
          hideOnMobile: false,
        },
        {
          field: 'birthDate',
          title: 'Data de nascimento',
          size: '10%',
          type: GridColumnType.Date,
          cell: (user: User) => `${user.birthDate}`,
          hideOnMobile: false,
        },
        {
          field: 'scholarity',
          title: 'Escolaridade',
          size: '10%',
          type: GridColumnType.Enum,
          cell: (user: User) => `${user.scholarity}`,
          customFormat: (user: User) => {
            return formatScholarity(user.scholarity);
          },
          hideOnMobile: true,
        },
        {
          field: 'actionEdit',
          title: 'Editar',
          size: '2%',
          type: GridColumnType.Action,
          callback: (user: User): void => {
            this.editElement(user);
          },
          hideOnMobile: true,
          iconAction: 'edit'
        },
        {
          field: 'actionDelete',
          title: 'Deletar',
          size: '5%',
          type: GridColumnType.Action,
          callback: (user: User): void => {
            this.deleteElement(user);
          },
          hideOnMobile: true,
          iconAction: 'delete'
        },
      ]
    }
    this.updateTable();
  }

  // Grid Events
  onAllRowsChecked(allChecked: boolean): void {
    if (allChecked) {
      this.rowsSelected.push(...this.data);
    } else {
      this.rowsSelected = [];
    }
  }

  onRowChecked(user: User): void {
    if (user.checked) {
      this.rowsSelected.push(user);
    } else {
      this.rowsSelected = this.rowsSelected.filter(p => p.id !== user.id);
    }
  }

  onAddUser(): void {
    this.router.navigate(['users/create']);
  }

  editElement(element: User): void {
    this.router.navigate([`users/${element.id}`]);
  }

  deleteElement(user: User): void {
    const dialogRef = this.dialog.open(ConfirmDeleteComponent, {
      width: '250px',
      data: user
    });

    dialogRef.afterClosed()
      .subscribe(
        result => {
          if (result) {
            this.isLoading = true;
            this.userService
              .deleteUser(user.id)
              .subscribe(() => {
                this.data = this.data.filter(p => p.id !== user.id);
                this.isLoading = false;
              });
          }
        });
  }

  updateTable(): void {
    this.userService.getAllUsers()
      .subscribe((data: User[]) => {
        this.data = data;
        this.isLoading = false;
      });
  }

  onDeleteCheckeds(): void {
    const dialogRef = this.dialog.open(ConfirmDeleteComponent, {
      width: '250px',
      data: null
    });

    dialogRef.afterClosed()
      .subscribe(
        result => {
          if (result) {
            this.isLoading = true;
            const usersIds: number[] = this.rowsSelected.map((user: User) => user.id);
            this.userService
              .deleteManyUsers({ ids: usersIds })
              .subscribe(() => {
                this.data = this.data.filter((p: User) => !usersIds.includes(p.id));
                this.isLoading = false;
              });
          }
        });
  }
}
