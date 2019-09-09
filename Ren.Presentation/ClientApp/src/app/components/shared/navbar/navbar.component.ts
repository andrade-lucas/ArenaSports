import { Component, OnInit } from '@angular/core';
import { Security } from 'src/app/utils/security.util';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor(private toastr: ToastrService, private router: Router) { }

  ngOnInit() {
  }

  logout() {
    Security.clear();
    this.toastr.info('Volte sempre', 'Sessão Encerrada');
    this.router.navigate(['account/login']);
  }
}
