import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnInit {
  public busy: Boolean = false;
  public form: FormGroup;

  constructor(private service: AuthService, private router: Router, private fb: FormBuilder) {
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
    this.service.register(this.form.value).subscribe(
      (data: any) => {
        if (data.status) {
          //this.toastr.success(data.message, 'Sucesso');
          this.router.navigate(['login']);
        }
        else
          console.log('Erro');
        //this.toastr.error(data.message, 'Erro');
      }
    )
    this.busy = false;
  }
}
