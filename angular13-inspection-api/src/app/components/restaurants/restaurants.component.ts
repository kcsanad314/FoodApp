import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { InspectionApiService } from 'src/app/services/inspection-api.service';
import { RestaurantApiService } from 'src/app/services/restaurant-api.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-restaurants',
  templateUrl: './restaurants.component.html',
  styleUrls: ['./restaurants.component.css']
})
export class RestaurantsComponent implements OnInit {

  
  restaurantList$!:Observable<any[]>;

  constructor(private service:RestaurantApiService) { }

  ngOnInit(): void {
    this.restaurantList$ = this.service.getRestaurantList();
  }

}
