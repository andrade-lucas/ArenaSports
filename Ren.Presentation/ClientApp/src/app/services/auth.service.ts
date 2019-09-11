import { HttpClient } from '@angular/common/http';
import { Security } from '../utils/security.util';
import { AppHeader } from '../utils/header.util';
import { Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { UserAuthModel } from '../models/authUser.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

    constructor(private http: HttpClient, private router: Router) {
    }
    
    canActivate() {
      const token = Security.hasToken();
      const expiration = Security.getExpiration();
      const now = new Date();
      if (!token) {
        this.router.navigate(['account/login']);
        return false;
      }
      else if (now > new Date(expiration)) {
        Security.clear();
        this.router.navigate(['account/login']);
        return false;
      }
      return true;
    }
  
    public login(data: UserAuthModel) {
      return this.http.post(`${AppHeader.url}/account/login`, data);
    }
}