import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IPagination } from './models/pagination';
import { IProduct } from './models/product';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Acara';
  products: IProduct[] | undefined;

  constructor(private http: HttpClient) {

  }

  ngOnInit(): void {
    this.http.get<IPagination>("https://localhost:5001/api/Products/products?pageSize=50").subscribe(
      (response: IPagination) => {
        this.products = response.data;
        console.log(response);
      }, error => { console.log(error); });
  }
}
