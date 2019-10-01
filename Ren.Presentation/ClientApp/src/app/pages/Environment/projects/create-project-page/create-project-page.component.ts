import { Component, OnInit } from '@angular/core';
import { ProjectModel } from 'src/app/models/project.model';
import { ProjectService } from 'src/app/services/project.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-create-project-page',
  templateUrl: './create-project-page.component.html',
  styleUrls: ['./create-project-page.component.css']
})
export class CreateProjectPageComponent implements OnInit {
  public form: FormGroup;
  public busy: Boolean = false;
  public project: ProjectModel;

  constructor(private service: ProjectService, private fb: FormBuilder, private toastr: ToastrService) { 
    this.form = this.fb.group({

    })
  }

  ngOnInit() {
  }

  public submit() {
    this.service.post(this.project).subscribe(
      
    )
  }
}
