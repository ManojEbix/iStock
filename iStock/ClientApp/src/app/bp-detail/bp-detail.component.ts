import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from "@angular/router";
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-bp-detail',
  templateUrl: './bp-detail.component.html',
  styleUrls: ['./bp-detail.component.scss']

})
export class BPDetailComponent {
  public bpDetail:any;
  states:any;
  public baseUrlClient: string;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string, private route: ActivatedRoute, private router: Router) {
    this.baseUrlClient = baseUrl;
    this.route.params.subscribe(params =>{
      http.get<any>(baseUrl + 'api/BP/detail/' + params.id).subscribe(result => {
        this.bpDetail = result;
        console.log('Success: ' + JSON.stringify(result));
      }, error => console.error(error));

      http.get<any>(baseUrl + 'api/BP/GetStates').subscribe(result => {
        this.states = result;
        console.log('Success: ' + JSON.stringify(result));
      }, error => console.error(error));

      http.get<any>(baseUrl + 'api/Invoice/GetInv').subscribe(result => {
 //       this.states = result;
        console.log('Success: ' + JSON.stringify(result));
      }, error => console.error(error));
    }
      );      
  };
  onSubmit(data, ) {    
    this.http.post<any>(this.baseUrlClient + 'api/BP/UpdateBP/' + data.Personid,data).subscribe(result => {      
      console.log('Success: ' + JSON.stringify(result));
      this.router.navigate(['/bp-list'])
    }, error => console.error(error));
    
    console.log(data);
}
cancel(){
  this.router.navigate(['/bp-list']);
}

}
