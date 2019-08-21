import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FramePageComponent } from './pages/master/frame-page/frame-page.component';
import { DashboardPageComponent } from './pages/Environment/dashboard-page/dashboard-page.component';
import { LoginPageComponent } from './pages/account/login-page/login-page.component';


const routes: Routes = [
  {
    path: '',
    component: FramePageComponent,
    children: [
      {path: '', component: DashboardPageComponent}
    ]
  },
  { path: 'account/auth', component: LoginPageComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
