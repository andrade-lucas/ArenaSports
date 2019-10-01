import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FramePageComponent } from './pages/master/frame-page/frame-page.component';
import { DashboardPageComponent } from './pages/Environment/dashboard-page/dashboard-page.component';
import { LoginPageComponent } from './pages/account/login-page/login-page.component';
import { AuthService } from './services/auth.service';
import { UsersPageComponent } from './pages/Environment/users/users-page/users-page.component';
import { CreateUserPageComponent } from './pages/Environment/users/create-user-page/create-user-page.component';
import { EditUserPageComponent } from './pages/Environment/users/edit-user-page/edit-user-page.component';
import { ProjectsPageComponent } from './pages/Environment/projects/projects-page/projects-page.component';
import { CreateProjectPageComponent } from './pages/Environment/projects/create-project-page/create-project-page.component';
import { EditProjectPageComponent } from './pages/Environment/projects/edit-project-page/edit-project-page.component';

const routes: Routes = [
  { path: 'account/login', component: LoginPageComponent },
  {
    path: '',
    canActivate: [AuthService],
    component: FramePageComponent,
    children: [
      { path: '', component: DashboardPageComponent }
    ]
  },
  {
    path: 'users',
    canActivate: [AuthService],
    component: FramePageComponent,
    children: [
      { path: '', component: UsersPageComponent },
      { path: 'create', component: CreateUserPageComponent },
      { path: 'edit/:id', component: EditUserPageComponent }
    ]
  },
  {
    path: 'projects',
    canActivate: [AuthService],
    component: FramePageComponent,
    children: [
      { path: '', component: ProjectsPageComponent },
      { path: 'create', component: CreateProjectPageComponent },
      { path: 'edit/:id', component: EditProjectPageComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
