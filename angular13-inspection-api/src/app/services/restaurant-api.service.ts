import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RestaurantApiService {
  readonly APIUrl = "https://localhost:7176/api";

  constructor(private http:HttpClient) { }

  getRestaurantList():Observable<any[]> {
    return this.http.get<any>(this.APIUrl + '/Restaurant/GetAllRestaurants');
  }

  getRestaurantById(restaurantId:null|string) {
    return this.http.get<any>(this.APIUrl + `/Restaurant/GetRestaurantById/${restaurantId}`);
  }

  getRestaurantByUserId(userId:null|string) {
    var res = this.http.get<any>(this.APIUrl + `/Restaurant/GetRestaurantByUserId/${userId}`);
    return res;
  }

  addRestaurant(data:any) {
    return this.http.post(this.APIUrl + '/Restaurant/RegisterRestaurant', data);
  }

  addFood(data:any) {
    return this.http.post(this.APIUrl + '/Restaurant/AddFood', data);
  }

  getFoodList():Observable<any[]> {
    return this.http.get<any>(this.APIUrl + '/Restaurant/GetAllFoods');
  }
}
