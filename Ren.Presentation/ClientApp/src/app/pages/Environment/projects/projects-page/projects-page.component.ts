import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ConfirmDialogService } from 'src/app/services/confirmDialog.service';
import { ProjectService } from 'src/app/services/project.service';
import { ProjectModel } from 'src/app/models/project.model';

@Component({
  selector: 'app-projects-page',
  templateUrl: './projects-page.component.html',
  styleUrls: ['./projects-page.component.css']
})
export class ProjectsPageComponent implements OnInit {
  public busy: Boolean = false;
  public projects$: Observable<ProjectModel[]>;

  constructor(private service: ProjectService, private dialog: ConfirmDialogService) { }

  ngOnInit() {
    this.loadProjects();
  }

  private loadProjects() {
    this.busy = true;
    this.projects$ = this.service.get();
    this.busy = false;
  }

  public delete(id: string) {
    this.dialog.confirmThis(this.service, id);
  }
}
