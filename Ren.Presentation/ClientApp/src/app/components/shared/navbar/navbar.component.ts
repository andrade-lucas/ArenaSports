import { Component, OnInit } from '@angular/core';
import { Security } from 'src/app/utils/security.util';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { UserModel } from 'src/app/models/user.model';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  public $user: Observable<UserModel>;

  constructor(private toastr: ToastrService, private router: Router) { 
    this.$user = Security.getUser();
  }

  ngOnInit() {
  }

  logout() {
    Security.clear();
    this.toastr.info('Volte sempre', 'Sessão Encerrada');
    this.router.navigate(['account/login']);
  }
}
