import { Component, OnInit } from '@angular/core';
import { ExperiencedetailsService } from 'src/app/shared/experienceinfo/experiencedetails.service';
import { Experience } from 'src/app/shared/experienceinfo/experience.model';

@Component({
  selector: 'app-experience-list',
  templateUrl: './experience-list.component.html',
  styleUrls: ['./experience-list.component.css']
})
export class ExperienceListComponent implements OnInit {

  rootURl = localStorage.getItem('url');
  constructor(private service: ExperiencedetailsService) { }

  ngOnInit() {
    this.service.refreshList();
  }

  populateForm(details: Experience) {
    this.service.formData = Object.assign({}, details);
  }

  onDelete(id: any) {
    if (confirm('Are You Sure??')) {
      console.log(id);
      this.service.deleteExperience(id).subscribe(x => {
        console.log(x), this.service.refreshList();
      });
    }
  }

}
