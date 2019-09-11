import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { UserService } from 'src/app/services/user.service';
import { Router, ActivatedRoute } from '@angular/router';
import { UserModel } from 'src/app/models/user.model';

@Component({
  selector: 'app-edit-user-page',
  templateUrl: './edit-user-page.component.html',
  styleUrls: ['./edit-user-page.component.css']
})
export class EditUserPageComponent implements OnInit {
  public form: FormGroup;
  public id: String;
  public busy: Boolean = false;

  constructor(private activatedRoute: ActivatedRoute, private router: Router, private service: UserService, private fb: FormBuilder, private toastr: ToastrService) { 
    this.form = this.fb.group({
      id: ['', Validators.required],
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
      email: ['', Validators.compose([
        Validators.minLength(4),
        Validators.maxLength(160),
        Validators.email,
        Validators.required
      ])],
      phone: [''],
      status: ['', Validators.required],
      image: ['']
    });
  }

  ngOnInit() {
    this.id = this.activatedRoute.snapshot.paramMap.get("id");
    this.service.getById(this.id).subscribe(
      (data: UserModel) => {
        this.form.controls['id'].setValue(data.id);
        this.form.controls['firstName'].setValue(data.firstName);
        this.form.controls['lastName'].setValue(data.lastName);
        this.form.controls['email'].setValue(data.email);
        this.form.controls['phone'].setValue(data.phone);
        this.form.controls['status'].setValue(data.status);
        this.form.controls['image'].setValue(data.image);
      }
    )
  }

  submit() {
    this.busy = true;
    this.service.put(this.form.value).subscribe(
      (data: any) => {
        if (data.status) {
          this.toastr.success(data.message, 'Sucesso');
          this.router.navigate(['/users']);
        }
        else
          this.toastr.error(data.message, 'Erro');
      }
    )
    this.busy = false;
  }
}
