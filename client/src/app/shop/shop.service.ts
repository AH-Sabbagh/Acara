import { HttpClient, HttpParams, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IBrand } from '../shared/models/brand';
import { IPagination } from '../shared/models/pagination';
import { IType } from '../shared/models/type';
import { delay, map } from 'rxjs/operators';
import { ShopParams } from '../shared/models/shopParams';
import { IProduct } from '../shared/models/product';

@Injectable({
  providedIn: 'root',
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/Products/';

  constructor(private http: HttpClient) {}

  getProducts(shopParams: ShopParams) {
    let params = new HttpParams();

    if (shopParams.brandId !== 0) {
      params = params.append('brandId', shopParams.brandId.toString());
    }
    if (shopParams.typeId !== 0) {
      params = params.append('typeId', shopParams.typeId.toString());
    }
    if(shopParams.search){
      params=params.append('search',shopParams.search);
    }
    params = params.append('sort', shopParams.sort);
    params=params.append('pageIndex',shopParams.pageNumber.toString());
    params=params.append('pageSize',shopParams.pageSize.toString());


    return this.http
      .get<IPagination>(this.baseUrl + 'products', {
        observe: 'response',
        params,
      })
      .pipe(
        map((response) => {
          return response.body!;
        })
      );
  }

  getProduct(id:number){
    return this.http.get<IProduct>(this.baseUrl + id);
  }

  getBrands() {
    return this.http.get<IBrand[]>(this.baseUrl + 'brands');
  }

  getTypes() {
    return this.http.get<IType[]>(this.baseUrl + 'types');
  }
}
