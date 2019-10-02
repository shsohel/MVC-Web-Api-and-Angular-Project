import { Component, OnInit } from '@angular/core';
import { SkilldetailsService } from 'src/app/shared/skillinfo/skilldetails.service';
import { AuthService } from 'src/app/auth/auth.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-skill-form',
  templateUrl: './skill-form.component.html',
  styleUrls: ['./skill-form.component.css']
})
export class SkillFormComponent implements OnInit {
  constructor(private service: SkilldetailsService, private authService: AuthService) { }

  ngOnInit() {
    this.resetForm();
  }
  resetForm(form?: NgForm) {
    if (form != null) {
    form.resetForm();
    }
    this.service.formData = {
      SkillID: null,
      SkillName: '',
      PersonalDetailID: null,
    };
  }

onSubmit(form: NgForm) {
  if (form.value.SkillID == null) {
  this.insertRecord(form);
  } else {
  this.updateRecord(form);
  }
}

insertRecord(form: NgForm) {
  this.service.postSkill(form.value).subscribe(res => {
    this.resetForm(form);
    this.service.refreshList();
  });
}
updateRecord(form: NgForm) {
  this.service.putSkill(form.value).subscribe(res => {
    this.resetForm(form);
    this.service.refreshList();
  });
}
}
