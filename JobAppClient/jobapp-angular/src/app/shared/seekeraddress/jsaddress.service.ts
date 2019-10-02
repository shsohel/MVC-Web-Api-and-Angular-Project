import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Address } from './address.model';

@Injectable({
  providedIn: 'root'
})
export class JsaddressService {
  formData: Address;
  list: Address[];
  rootURl = localStorage.getItem('url');
  constructor(private http: HttpClient) {

  }

   refreshList() {
    this.http.get(this.rootURl + '/Address/GetAddressList')
    .toPromise().then(res => this.list = res as Address[]);
  }

  postAddress(formData: Address) {
    return this.http.post(this.rootURl + '/Address/AddressInsert', formData);
   }

  getAddress() {
    return this.http.get(this.rootURl + '/Address/GetAddressList');
  }

  getAddressID(id: number) {
    return this.http.get(this.rootURl + '/Address/GetAddressListById/' + id);
  }


  putAddress(formData: Address) {
    return this.http.put(this.rootURl + '/Address/UpdateAddress/' + formData.AddressID, formData);
   }

   deleteAddress(id: number) {
    return this.http.delete(this.rootURl + '/Address/CancelAddress/' + id);

   }

}
