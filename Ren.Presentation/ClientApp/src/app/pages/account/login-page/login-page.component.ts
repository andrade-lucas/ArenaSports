import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Security } from 'src/app/utils/security.util';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnInit {
  public busy: Boolean = false;
  public form: FormGroup;

  constructor(private service: AuthService, private toastr: ToastrService, private router: Router, private fb: FormBuilder) {
    this.form = this.fb.group({
      email: ['', Validators.compose([
        Validators.required,
        Validators.email
      ])],
      password: ['', Validators.compose([
        Validators.required,
        Validators.minLength(6),
        Validators.maxLength(20)
      ])]
    })
  }

  ngOnInit() {
  }

  submit() {
    this.busy = true;
    this.service.login(this.form.value).subscribe(
      (data: any) => {
        if (data.status) {
          this.toastr.success(data.message, 'Sucesso');
          this.setUser(data.user.data, data.accessToken);
        }
        else
          this.toastr.error(data.message, 'Erro');
      }
    )
    this.busy = false;
  }

  setUser(user, token) {
    Security.set(user, token);
    this.router.navigate(['/']);
  }
}
