import { Component, OnInit } from '@angular/core';
import { HeritageService } from 'src/app/services/heritage.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-create-heritage-page',
  templateUrl: './create-heritage-page.component.html',
  styleUrls: ['./create-heritage-page.component.css']
})
export class CreateHeritagePageComponent implements OnInit {
  public busy: Boolean = false;
  public form: FormGroup;

  constructor(private service: HeritageService, private toastr: ToastrService, private router: Router, private fb: FormBuilder) { 
    this.form = this.fb.group({
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
  }

  public submit() {
    this.busy = true;
    this.service.post(this.form.value).subscribe(
      (data: any) => {
        if (data.status) {
          this.toastr.success('Sucesso', data.message);
          this.router.navigate(['/heritages']);
        }
        else
          this.toastr.error('Erro', data.message);
      }
    )
    this.busy = false;
  }
}
