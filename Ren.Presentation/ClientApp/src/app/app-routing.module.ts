import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FramePageComponent } from './pages/master/frame-page/frame-page.component';
import { DashboardPageComponent } from './pages/Environment/dashboard-page/dashboard-page.component';
import { LoginPageComponent } from './pages/account/login-page/login-page.component';
import { AuthService } from './services/auth.service';
import { UsersPageComponent } from './pages/Environment/users-page/users-page.component';
import { CreateUserPageComponent } from './pages/Environment/create-user-page/create-user-page.component';
import { EditUserPageComponent } from './pages/Environment/edit-user-page/edit-user-page.component';

const routes: Routes = [
  {
    path: '',
    canActivate: [AuthService],
    component: FramePageComponent,
    children: [
      { path: '', component: DashboardPageComponent }
    ]
  },
  {
    path: '',
    canActivate: [AuthService],
    component: FramePageComponent,
    children: [
      { path: 'users', component: UsersPageComponent },
      { path: 'users/create', component: CreateUserPageComponent },
      { path: 'users/edit/:id', component: EditUserPageComponent }
    ]
  },
  { path: 'account/login', component: LoginPageComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
