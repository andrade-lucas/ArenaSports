import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { UserService } from 'src/app/services/user.service';
import { GetUsersModel } from 'src/app/models/getUsers.model';
import { ConfirmDialogService } from 'src/app/services/confirmDialog.service';

@Component({
  selector: 'app-users-page',
  templateUrl: './users-page.component.html',
  styleUrls: ['./users-page.component.css']
})
export class UsersPageComponent implements OnInit {
  public busy: Boolean = false;
  public users$: Observable<GetUsersModel[]>;

  constructor(private service: UserService, private dialog: ConfirmDialogService) {
  }

  ngOnInit() {
    this.loadUsers();
  }

  public loadUsers() {
    this.busy = true;
    this.users$ = this.service.get();
    this.busy = false;
  }

  delete(id: string) {
    this.dialog.confirmThis(this.service, id);
  }
}
