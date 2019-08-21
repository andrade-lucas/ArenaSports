import { HttpClient } from '@angular/common/http';
import { Security } from '../utils/security.util';
import { AppHeader } from '../utils/header.util';
import { Router } from '@angular/router';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

    constructor(private http: HttpClient, private router: Router) {
    }
    
    canActivate() {
      const token = Security.hasToken();
      if (!token) {
        this.router.navigate(['account/login']);
        return false;
      }
      return true;
    }
  
    public login(data: any) {
      return this.http.post(`${AppHeader.url}/account/login`, data);
    }
  
    public refreshToken() {
      return this.http.post(`${AppHeader.url}/account/refreshToken`, null, { headers: AppHeader.composeHeader() });
    }

    public register(data: any) {
      return this.http.post(`${AppHeader.url}/account/register`, data, { headers: AppHeader.composeHeader() });
    }
}