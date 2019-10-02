import { Component, OnInit } from '@angular/core';
import { EmployeerinfoService } from 'src/app/shared/employeerinfo/employeerinfo.service';
import { Employeerinfo } from 'src/app/shared/employeerinfo/employeerinfo.model';

@Component({
  selector: 'app-emploeerinfo-list',
  templateUrl: './emploeerinfo-list.component.html',
  styleUrls: ['./emploeerinfo-list.component.css']
})
export class EmploeerinfoListComponent implements OnInit {
  rootURl = localStorage.getItem('url');
  constructor(private service: EmployeerinfoService) { }

  ngOnInit() {
    this.service.refreshList();
  }

  populateForm(details: Employeerinfo) {
    this.service.formData = Object.assign({}, details);
  }

  onDelete(id: any) {
    if (confirm('Are You Sure??')) {
      console.log(id);
      this.service.deleteEmployeer(id).subscribe(x => {
        console.log(x), this.service.refreshList();
      });
    }
  }
}
