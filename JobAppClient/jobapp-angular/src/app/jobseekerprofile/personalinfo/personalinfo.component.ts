import { Component, OnInit } from '@angular/core';
import { PersonaldetailService } from 'src/app/shared/personalinfo/personaldetail.service';
import { Personaldetail } from 'src/app/shared/personalinfo/personaldetail.model';
import { Router } from '@angular/router';
import { Jobseeker } from 'src/app/shared/jobseeker/jobseeker.model';

@Component({
  selector: 'app-personalinfo',
  templateUrl: './personalinfo.component.html',
  styleUrls: ['./personalinfo.component.css']
})
export class PersonalinfoComponent implements OnInit {

  rootURl = localStorage.getItem('url');
  constructor(private service: PersonaldetailService) { }


  ngOnInit() {
    this.service.refreshList();
  }

  populateForm(details: Personaldetail) {
    this.service.formData = Object.assign({}, details);
  }



  onDelete(id: any) {
    if (confirm('Are You Sure??')) {
      console.log(id);
      this.service.deleteDetails(id).subscribe(x => {
        console.log(x), this.service.refreshList();
      });
    }
  }

}
