import { Component, OnInit } from '@angular/core';
import { JobapplyService } from 'src/app/shared/jobapplyinfo/jobapply.service';
import { Jobapply } from 'src/app/shared/jobapplyinfo/jobapply.model';

@Component({
  selector: 'app-jobapply-list',
  templateUrl: './jobapply-list.component.html',
  styleUrls: ['./jobapply-list.component.css']
})
export class JobapplyListComponent implements OnInit {

  rootURl = localStorage.getItem('url');
  constructor(private service: JobapplyService) { }

  ngOnInit() {
    this.service.refreshList();
  }

  populateForm(details: Jobapply) {
    this.service.formData = Object.assign({}, details);
  }

  onDelete(id: any) {
    if (confirm('Are You Sure??')) {
      console.log(id);
      this.service.deleteApplyJob(id).subscribe(x => {
        console.log(x), this.service.refreshList();
      });
    }
  }

}

