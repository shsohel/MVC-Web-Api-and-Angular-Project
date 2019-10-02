import { Component, OnInit } from '@angular/core';
import { JoblistService } from 'src/app/shared/job/joblist.service';
import { Joblist } from 'src/app/shared/job/joblist.model';

@Component({
  selector: 'app-job-list',
  templateUrl: './job-list.component.html',
  styleUrls: ['./job-list.component.css']
})
export class JobListComponent implements OnInit {

  constructor(private service: JoblistService) { }

  ngOnInit() {
    this.service.refreshList();
  }
  populateForm(job: Joblist) {
    this.service.formData = Object.assign({}, job);
  }

  onDelete(id: any) {
    if (confirm('Are You Sure??')) {
      console.log(id);
      this.service.deleteJoblist(id).subscribe(x => {
        console.log(x), this.service.refreshList();

      });
    }
  }

}
