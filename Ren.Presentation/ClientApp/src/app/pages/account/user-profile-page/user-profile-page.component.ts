import { Component, OnInit } from '@angular/core';
import { UserModel } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user.service';
import { Security } from 'src/app/utils/security.util';

@Component({
  selector: 'app-user-profile-page',
  templateUrl: './user-profile-page.component.html',
  styleUrls: ['./user-profile-page.component.css']
})
export class UserProfilePageComponent implements OnInit {
  public user$: UserModel;
  public busy: Boolean = false;

  constructor(private service: UserService) {
  }

  ngOnInit() {
    this.loadUser();
  }

  private loadUser() {
    this.busy = true;
    let user = Security.getUser();
    this.service.getById(user.id).subscribe(
      (data: UserModel) => {
        this.user$ = data;
      }
    )
    this.busy = false;
  }
}
