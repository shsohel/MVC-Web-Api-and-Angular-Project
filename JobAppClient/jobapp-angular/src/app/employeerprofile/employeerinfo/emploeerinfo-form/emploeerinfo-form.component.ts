import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/auth/auth.service';
import { EmployeerinfoService } from 'src/app/shared/employeerinfo/employeerinfo.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-emploeerinfo-form',
  templateUrl: './emploeerinfo-form.component.html',
  styleUrls: ['./emploeerinfo-form.component.css']
})
export class EmploeerinfoFormComponent implements OnInit {
  constructor(private service: EmployeerinfoService, private authService: AuthService) { }

  ngOnInit() {
    this.resetForm();
  }
  resetForm(form?: NgForm) {
    if (form != null) {
    form.resetForm();
    }
    this.service.formData = {
      EmployerID: null,
    UserName: '',
    CompanyName: '',
    Catageory: '',
    BusinessDescription: '',
    WebsiteUrl: '',
    PhoneNumber: '',
    TelePhone: '',
    Fax: '',
    Email: '',

    };
}

onSubmit(form: NgForm) {
  if (form.value.EmployerID == null) {
  this.insertRecord(form);
  } else {
  this.updateRecord(form);
  }
}

insertRecord(form: NgForm) {
  this.service.postEmployer(form.value).subscribe(res => {
    this.resetForm(form);
    this.service.refreshList();
  });
}
updateRecord(form: NgForm) {
  this.service.putEmployeer(form.value).subscribe(res => {
    this.resetForm(form);
    this.service.refreshList();
  });
}
}
