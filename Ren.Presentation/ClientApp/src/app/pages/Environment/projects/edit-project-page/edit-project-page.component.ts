import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ProjectService } from 'src/app/services/project.service';
import { UserService } from 'src/app/services/user.service';
import { ToastrService } from 'ngx-toastr';
import { Router, ActivatedRoute } from '@angular/router';
import { GetUsersModel } from 'src/app/models/getUsers.model';
import { Observable } from 'rxjs';
import { ProjectModel } from 'src/app/models/project.model';

@Component({
  selector: 'app-edit-project-page',
  templateUrl: './edit-project-page.component.html',
  styleUrls: ['./edit-project-page.component.css']
})
export class EditProjectPageComponent implements OnInit {
  public busy: Boolean = false;
  public form: FormGroup;
  public users$: Observable<GetUsersModel[]>;
  public id: String;

  constructor(private service: ProjectService, private userService: UserService, private toastr: ToastrService,
      private router: Router, private activatedRoute: ActivatedRoute, private fb: FormBuilder) { 
        this.form = this.fb.group({
          id: ['', Validators.required],
          title: ['', Validators.compose([
            Validators.minLength(2),
            Validators.maxLength(30),
            Validators.required
          ])],
          ownerId: ['', Validators.required],
          description: ['', Validators.compose([
            Validators.minLength(3),
            Validators.required
          ])],
          status: ['', Validators.required]
        });
      }

  ngOnInit() {
    this.busy = true;
    this.users$ = this.userService.get();
    this.id = this.activatedRoute.snapshot.paramMap.get('id');
    this.service.getById(this.id).subscribe(
      (data: ProjectModel) => {
        this.form.controls['id'].setValue(data.id);
        this.form.controls['title'].setValue(data.title);
        this.form.controls['ownerId'].setValue(data.ownerId);
        this.form.controls['description'].setValue(data.description);
        this.form.controls['status'].setValue(data.status);
      }
    )
    this.busy = false;
  }

  public submit() {
    this.busy = true;
    this.service.put(this.form.value).subscribe(
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
