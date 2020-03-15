import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-bplist',
  templateUrl: './bplist.component.html'
})
export class BPComponent {
  public bplist: any;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private router: Router) {
    http.get<any>(baseUrl + 'api/BP/GetBPList').subscribe(result => {
      this.bplist = result;
      console.log('Success: ' + JSON.stringify(result));
    }, error => console.error(error));
  }

  RowSelected(u: number) {
    this.router.navigate(['/bp-detail', u])
    console.log(u);
  }

  getStatus(status: boolean) {
    console.log(status);
    return status ? 'active' : 'inactive';
  }

  getClass(status: boolean) {
    return status ? 'label label-success' : 'label label-warning';
  }

  getText(status: boolean) {
    return status ? 'Active' : 'Inactive';
  }
}

interface BPList {
  firstName: string;
  lastName: string;
  gender: string;
  email: string;
  mobile: string;
}
