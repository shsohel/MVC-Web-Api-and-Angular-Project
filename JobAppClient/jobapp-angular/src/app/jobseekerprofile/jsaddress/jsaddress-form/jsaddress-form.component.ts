import { Component, OnInit } from '@angular/core';
import { JsaddressService } from 'src/app/shared/seekeraddress/jsaddress.service';
import { AuthService } from 'src/app/auth/auth.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-jsaddress-form',
  templateUrl: './jsaddress-form.component.html',
  styleUrls: ['./jsaddress-form.component.css']
})
export class JsaddressFormComponent implements OnInit {
  constructor(private service: JsaddressService, private authService: AuthService) { }

  ngOnInit() {
    this.resetForm();
  }
  resetForm(form?: NgForm) {
    if (form != null) {
    form.resetForm();
    }
    this.service.formData = {
    AddressID: null,
    PresentAddress: '',
    PermanentAddress: '',
    PersonalDetailID: null
    };
  }

onSubmit(form: NgForm) {
  if (form.value.AddressID == null) {
  this.insertRecord(form);
  } else {
  this.updateRecord(form);
  }
}

insertRecord(form: NgForm) {
  this.service.postAddress(form.value).subscribe(res => {
    this.resetForm(form);
    this.service.refreshList();
  });
}
updateRecord(form: NgForm) {
  this.service.putAddress(form.value).subscribe(res => {
    this.resetForm(form);
    this.service.refreshList();
  });
}
}
