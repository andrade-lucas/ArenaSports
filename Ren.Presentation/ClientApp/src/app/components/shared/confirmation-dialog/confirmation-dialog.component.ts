import { Component, OnInit } from '@angular/core';
import { ConfirmDialogService } from 'src/app/services/confirmDialog.service';

@Component({
  selector: 'app-confirmation-dialog',
  templateUrl: './confirmation-dialog.component.html',
  styleUrls: ['./confirmation-dialog.component.css']
})
export class ConfirmationDialogComponent implements OnInit {
  public message: any;

  constructor(private service: ConfirmDialogService) { }

  ngOnInit() {
  }

  confirm() {
    this.service.confirm();
  }
}
