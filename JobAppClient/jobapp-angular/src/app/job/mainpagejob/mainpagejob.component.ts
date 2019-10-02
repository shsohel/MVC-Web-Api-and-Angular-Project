import { Component, OnInit } from '@angular/core';
import { JoblistService } from 'src/app/shared/job/joblist.service';
import { Joblist } from 'src/app/shared/job/joblist.model';

@Component({
  selector: 'app-mainpagejob',
  templateUrl: './mainpagejob.component.html',
  styleUrls: ['./mainpagejob.component.css']
})
export class MainpagejobComponent implements OnInit {

  constructor( private service: JoblistService) { }

  ngOnInit() {
    this.service.refreshList();
  }



}
