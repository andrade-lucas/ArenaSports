import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { HeritageModel } from 'src/app/models/heritage.model';
import { HeritageService } from 'src/app/services/heritage.service';
import { ConfirmDialogService } from 'src/app/services/confirmDialog.service';

@Component({
  selector: 'app-heritages-page',
  templateUrl: './heritages-page.component.html',
  styleUrls: ['./heritages-page.component.css']
})
export class HeritagesPageComponent implements OnInit {
  public busy: Boolean = false;
  public heritages$: Observable<HeritageModel[]>;

  constructor(private service: HeritageService, private dialog: ConfirmDialogService) { }

  ngOnInit() {
    this.busy = true;
    this.heritages$ = this.service.get();
    this.busy = false;
  }

  public delete(id: string) {
    this.dialog.confirmThis(this.service, id);
  }
}
