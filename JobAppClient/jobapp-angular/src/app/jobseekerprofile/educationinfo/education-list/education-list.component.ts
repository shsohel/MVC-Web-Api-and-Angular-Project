import { Component, OnInit } from '@angular/core';
import { EducationdetailsService } from 'src/app/shared/educationinfo/educationdetails.service';
import { Education } from 'src/app/shared/educationinfo/education.model';

@Component({
  selector: 'app-education-list',
  templateUrl: './education-list.component.html',
  styleUrls: ['./education-list.component.css']
})
export class EducationListComponent implements OnInit {

  rootURl = localStorage.getItem('url');
  constructor(private service: EducationdetailsService) { }

  ngOnInit() {
    this.service.refreshList();
  }

  populateForm(details: Education) {
    this.service.formData = Object.assign({}, details);
  }

  onDelete(id: any) {
    if (confirm('Are You Sure??')) {
      console.log(id);
      this.service.deleteEducation(id).subscribe(x => {
        console.log(x), this.service.refreshList();
      });
    }
  }

}
