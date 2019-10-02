import { Component, OnInit } from '@angular/core';
import { CompanyaddressdetailsService } from 'src/app/shared/companyaddress/companyaddressdetails.service';
import { Companyaddress } from 'src/app/shared/companyaddress/companyaddress.model';

@Component({
  selector: 'app-companyaddress-list',
  templateUrl: './companyaddress-list.component.html',
  styleUrls: ['./companyaddress-list.component.css']
})
export class CompanyaddressListComponent implements OnInit {
  rootURl = localStorage.getItem('url');
  constructor(private service: CompanyaddressdetailsService) { }

  ngOnInit() {
    this.service.refreshList();
  }

  populateForm(details: Companyaddress) {
    this.service.formData = Object.assign({}, details);
  }

  onDelete(id: any) {
    if (confirm('Are You Sure??')) {
      console.log(id);
      this.service.deleteCompanyaddress(id).subscribe(x => {
        console.log(x), this.service.refreshList();
      });
    }
  }
}
