import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register-page',
  templateUrl: './register-page.component.html',
  styleUrls: ['./register-page.component.css']
})
export class RegisterPageComponent implements OnInit {
  public form: FormGroup;
  public imageSrc = 'assets/img/user-medium.png';
  imgURL: any;

  constructor(private service: AuthService, private router: Router, private fb: FormBuilder) { 
    this.form = this.fb.group({
      firstName: ['', Validators.compose([
        Validators.minLength(2),
        Validators.maxLength(30),
        Validators.required
      ])],
      lastName: ['', Validators.compose([
        Validators.minLength(2),
        Validators.maxLength(30),
        Validators.required
      ])],
      document: ['', Validators.compose([
        Validators.minLength(11),
        Validators.maxLength(14),
        Validators.required
      ])],
      email: ['', Validators.compose([
        Validators.minLength(4),
        Validators.maxLength(160),
        Validators.required
      ])],
      password:['', Validators.compose([
        Validators.minLength(6),
        Validators.maxLength(20),
        Validators.required
      ])],
      phone: [''],
      image: ['']
    });
  }

  ngOnInit() {
  }

  onImageSelected(event) {
    const file = event.target.files[0];
    var mimeType = file.type;
    if (mimeType.match(/image\/*/) == null) {
      //this.toastr.error('Por favor, selecione um arquivo de imagem', 'Formato Incorreto');
      return;
    }
    var reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = (_event) => {
      this.imgURL = reader.result;
    }
  }

  submit() {
    this.service.register(this.form.value).subscribe(
      (data: any) => {
        if (data.status) {
          //this.toastr.success(data.message, 'Sucesso');
          this.router.navigate(['account/login']);
        }
        else
          console.log('Erro');
          //this.toastr.error(data.message, 'Erro');
      }
    )
  }
}
