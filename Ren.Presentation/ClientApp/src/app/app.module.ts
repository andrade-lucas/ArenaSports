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
import { UsersPageComponent } from './pages/Environment/users-page/users-page.component';

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
    UsersPageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
