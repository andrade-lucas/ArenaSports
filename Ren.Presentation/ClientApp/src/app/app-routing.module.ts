import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FramePageComponent } from './pages/master/frame-page/frame-page.component';
import { DashboardPageComponent } from './pages/Environment/dashboard-page/dashboard-page.component';
import { LoginPageComponent } from './pages/account/login-page/login-page.component';
import { AuthService } from './services/auth.service';
import { RegisterPageComponent } from './pages/account/register-page/register-page.component';


const routes: Routes = [
  {
    path: '',
    canActivate: [AuthService],
    component: FramePageComponent,
    children: [
      {path: '', component: DashboardPageComponent}
    ]
  },
  { path: 'account/login', component: LoginPageComponent },
  { path: 'account/register', component: RegisterPageComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
