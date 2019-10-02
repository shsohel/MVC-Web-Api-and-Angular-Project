import { Component, OnInit } from '@angular/core';
import { PersonaldetailService } from 'src/app/shared/personalinfo/personaldetail.service';
import { AuthService } from 'src/app/auth/auth.service';
import { NgForm, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-updatepersonalinfo',
  templateUrl: './updatepersonalinfo.component.html',
  styleUrls: ['./updatepersonalinfo.component.css']
})
export class UpdatepersonalinfoComponent implements OnInit {

  constructor(private service: PersonaldetailService, private authService: AuthService) { }

  ngOnInit() {
    this.resetForm();
  }
  resetForm(form?: NgForm) {
    if (form != null) {
    form.resetForm();
    }
    this.service.formData = {
      PersonalDetailID: null,
      UserName: '',
      FirstName : '',
      LastName : '' ,
      FatherName : '',
      MotherName: '',
      NationalID: '',
      DOB: null,
      Email : '',
      CellPhone : '',
      Photo: '',
    };
}

onSubmit(form: NgForm) {
  if (form.value.PersonalDetailID == null) {
  this.insertRecord(form);
  } else {
  this.updateRecord(form);
  }
}

insertRecord(form: NgForm) {
  this.service.postDetails(form.value).subscribe(res => {
    this.resetForm(form);
    this.service.refreshList();
  });
}
updateRecord(form: NgForm) {
  this.service.putDetails(form.value).subscribe(res => {
    this.resetForm(form);
    this.service.refreshList();
  });
}
}
