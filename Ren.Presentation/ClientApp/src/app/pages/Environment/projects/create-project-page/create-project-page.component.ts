import { Component, OnInit } from '@angular/core';
import { ProjectService } from 'src/app/services/project.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { GetUsersModel } from 'src/app/models/getUsers.model';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-create-project-page',
  templateUrl: './create-project-page.component.html',
  styleUrls: ['./create-project-page.component.css']
})
export class CreateProjectPageComponent implements OnInit {
  public form: FormGroup;
  public busy: Boolean = false;
  public users$: Observable<GetUsersModel[]>;

  constructor(private service: ProjectService, private usersService: UserService, private fb: FormBuilder, private toastr: ToastrService, 
      private router: Router) { 
    this.form = this.fb.group({
      title: ['', Validators.compose([
        Validators.minLength(2),
        Validators.maxLength(30),
        Validators.required
      ])],
      description: ['', Validators.compose([
        Validators.minLength(3),
        Validators.required
      ])],
      ownerId: ['', Validators.required]
    });
  }

  ngOnInit() {
    this.users$ = this.usersService.get();
  }

  public submit() {
    this.busy = true;
    this.service.post(this.form.value).subscribe(
      (data: any) => {
        if (data.status) {
          this.toastr.success('Sucesso', data.message);
          this.router.navigate(['/projects']);
        }
        else
          this.toastr.error('Erro', data.message);
      }
    )
    this.busy = false;
  }
}
