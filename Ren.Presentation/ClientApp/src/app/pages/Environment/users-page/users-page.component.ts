import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { UserService } from 'src/app/services/user.service';
import { GetusersModel } from 'src/app/models/getUsers.model';

@Component({
  selector: 'app-users-page',
  templateUrl: './users-page.component.html',
  styleUrls: ['./users-page.component.css']
})
export class UsersPageComponent implements OnInit {
  public $users: Observable<GetusersModel[]>;

  constructor(private service: UserService) { 
    this.$users = this.service.get();
  }

  ngOnInit() {
  }

}
