import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { HeritageService } from 'src/app/services/heritage.service';
import { ToastrService } from 'ngx-toastr';
import { Router, ActivatedRoute } from '@angular/router';
import { HeritageModel } from 'src/app/models/heritage.model';

@Component({
  selector: 'app-edit-heritage-page',
  templateUrl: './edit-heritage-page.component.html',
  styleUrls: ['./edit-heritage-page.component.css']
})
export class EditHeritagePageComponent implements OnInit {
  public busy: Boolean = false;
  public form: FormGroup;
  public id: String;

  constructor(private service: HeritageService, private toastr: ToastrService, private router: Router, 
    private activatedRoute: ActivatedRoute, private fb: FormBuilder) {
      this.form = this.fb.group({
        id: ['', Validators.required],
        description: ['', Validators.compose([
          Validators.minLength(2),
          Validators.required
        ])],
        purchaseDate: ['', Validators.required],
        status: ['', Validators.required],
        barcode: ['']
      });
     }

  ngOnInit() {
    this.busy = true;
    this.id = this.activatedRoute.snapshot.paramMap.get('id');
    this.service.getById(this.id).subscribe(
      (data: HeritageModel) => {
        this.form.controls['id'].setValue(data.id);
        this.form.controls['description'].setValue(data.description);
        this.form.controls['purchaseDate'].setValue(data.purchaseDate);
        this.form.controls['status'].setValue(data.status);
        this.form.controls['barCode'].setValue(data.barCode);
      }
    );
    this.busy = false;
  }

  public submit() {
    this.busy = true;
    this.service.put(this.form.value).subscribe(
      (data: any) => {
        if (data.status) {
          this.toastr.success(data.message, 'Sucesso');
          this.router.navigate(['/heritages']);
        }
        else
          this.toastr.error(data.message, 'Erro');
      }
    )
    this.busy = false;
  }
}
