import { Component, OnInit } from '@angular/core';
import { JsaddressService } from 'src/app/shared/seekeraddress/jsaddress.service';
import { Address } from 'src/app/shared/seekeraddress/address.model';

@Component({
  selector: 'app-jsaddress-list',
  templateUrl: './jsaddress-list.component.html',
  styleUrls: ['./jsaddress-list.component.css']
})
export class JsaddressListComponent implements OnInit {
  rootURl = localStorage.getItem('url');
  constructor(private service: JsaddressService) { }

  ngOnInit() {
    this.service.refreshList();
  }

  populateForm(details: Address) {
    this.service.formData = Object.assign({}, details);
  }

  onDelete(id: any) {
    if (confirm('Are You Sure??')) {
      console.log(id);
      this.service.deleteAddress(id).subscribe(x => {
        console.log(x), this.service.refreshList();
      });
    }
  }

}
