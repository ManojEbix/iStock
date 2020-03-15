import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from "@angular/router";
import { Router } from '@angular/router';

@Component({
  selector: 'iWatchlistWidget',
  templateUrl: './iWatchlistWidget.component.html',
  styleUrls: ['./iWatchlistWidget.component.scss']

})
export class iWatchlistWidgetComponent {
  public orderDetail:{}={
    OrderNumber:'',
    Name:'',
    Currency:'',
    OrderDate:'',
    Address1:'',
    Address2:'',
    City:'',
    State:'',
    Zip:'',
    Country:''
  };
  public orderProducts:any=[];
  states:any;
  public keyword:any=[];
  public data:string='Name';
  public baseUrlClient: string;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string, private route: ActivatedRoute, private router: Router) {
    this.baseUrlClient = baseUrl;    
    this.orderProducts.push({
      ItemCode:'',
      UnitPrice:'',
      Quantity:'',
      ItemName:'',
    });
    // // this.http.get<any>(this.baseUrlClient + 'api/BP/Search/' + 'M').subscribe(result => {      
    // //   console.log('Success: ' + JSON.stringify(result));
    // //   this.keyword = result;
    // // }, error => console.error(error));
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

addProduct(){
  this.orderProducts.push({
    ItemCode:'',
    UnitPrice:'',
    Quantity:'',
    ItemName:'',
  });
}

 
  selectEvent(item) {
    // do something with selected item
  }
 
  onChangeSearch(val: string) {
    // fetch remote data from here
    // And reassign the 'data' which is binded to 'data' property.
    if(val!='' && val!= undefined){
    this.http.get<any>(this.baseUrlClient + 'api/BP/Search/'+val).subscribe(result => {
      this.keyword = result;
      console.log('Success: ' + JSON.stringify(result));
    }, error => console.error(error));
  }
  }
  
  onFocused(e){
    // do something when input is focused
  }

}
