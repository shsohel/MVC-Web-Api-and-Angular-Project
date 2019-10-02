import { Component, OnInit } from '@angular/core';
import { CompanyaddressdetailsService } from 'src/app/shared/companyaddress/companyaddressdetails.service';
import { AuthService } from 'src/app/auth/auth.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-companyaddress-form',
  templateUrl: './companyaddress-form.component.html',
  styleUrls: ['./companyaddress-form.component.css']
})
export class CompanyaddressFormComponent implements OnInit {
  constructor(private service: CompanyaddressdetailsService, private authService: AuthService) { }

  ngOnInit() {
    this.resetForm();
  }
  resetForm(form?: NgForm) {
    if (form != null) {
    form.resetForm();
    }
    this.service.formData = {
      CompanyAddressID: null,
      Country: '',
      District: '',
      Thana: '',
      AddressDetails: '',
      EmployerID: null,

    };
}

onSubmit(form: NgForm) {
  if (form.value.CompanyAddressID == null) {
  this.insertRecord(form);
  } else {
  this.updateRecord(form);
  }
}

insertRecord(form: NgForm) {
  this.service.postCompanyaddress(form.value).subscribe(res => {
    this.resetForm(form);
    this.service.refreshList();
  });
}
updateRecord(form: NgForm) {
  this.service.putCompanyaddress(form.value).subscribe(res => {
    this.resetForm(form);
    this.service.refreshList();
  });
}
}
