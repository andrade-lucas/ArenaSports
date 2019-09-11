import { Component, OnInit } from '@angular/core';
import { Security } from 'src/app/utils/security.util';

@Component({
  selector: 'app-dashboard-page',
  templateUrl: './dashboard-page.component.html',
  styleUrls: ['./dashboard-page.component.css']
})
export class DashboardPageComponent implements OnInit {
  public user: any;

  constructor() { 
    this.user = Security.getToken();
    console.log(this.user);
  }

  ngOnInit() {
  }

}
