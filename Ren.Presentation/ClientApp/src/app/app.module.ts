import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms'
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FramePageComponent } from './pages/master/frame-page/frame-page.component';
import { NavbarComponent } from './components/shared/navbar/navbar.component';
import { FooterComponent } from './components/shared/footer/footer.component';
import { DashboardPageComponent } from './pages/Environment/dashboard-page/dashboard-page.component';
import { LoginPageComponent } from './pages/account/login-page/login-page.component';
import { ConfirmationDialogComponent } from './components/shared/confirmation-dialog/confirmation-dialog.component';
import { LoadingComponent } from './components/shared/loading/loading.component';
import { RegisterPageComponent } from './pages/account/register-page/register-page.component';
import { ToastrModule } from 'ngx-toastr';
import { NgxMaskModule } from 'ngx-mask'
import { UsersPageComponent } from './pages/Environment/users/users-page/users-page.component';
import { CreateUserPageComponent } from './pages/Environment/users/create-user-page/create-user-page.component';
import { EditUserPageComponent } from './pages/Environment/users/edit-user-page/edit-user-page.component';
import { ProjectsPageComponent } from './pages/Environment/projects/projects-page/projects-page.component';
import { CreateProjectPageComponent } from './pages/Environment/projects/create-project-page/create-project-page.component';
import { EditProjectPageComponent } from './pages/Environment/projects/edit-project-page/edit-project-page.component';
import { UserProfilePageComponent } from './pages/account/user-profile-page/user-profile-page.component';

@NgModule({
  declarations: [
    AppComponent,
    FramePageComponent,
    NavbarComponent,
    FooterComponent,
    DashboardPageComponent,
    LoginPageComponent,
    ConfirmationDialogComponent,
    LoadingComponent,
    RegisterPageComponent,
    UsersPageComponent,
    CreateUserPageComponent,
    EditUserPageComponent,
    ProjectsPageComponent,
    CreateProjectPageComponent,
    EditProjectPageComponent,
    UserProfilePageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    NgxMaskModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
