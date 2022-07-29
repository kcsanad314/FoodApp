import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { RestaurantApiService } from 'src/app/services/restaurant-api.service';

@Component({
  selector: 'app-restaurant-details',
  templateUrl: './restaurant-details.component.html',
  styleUrls: ['./restaurant-details.component.scss']
})
export class RestaurantDetailsComponent implements OnInit {

  restaurantList$!:Observable<any[]>;
  restaurantId?: string | null = "";
  foodList$!:Observable<any[]>;


  constructor(private service:RestaurantApiService, private activatedRoute: ActivatedRoute) { }
  
  @Input() restaurant:any;
  rid: number = 0;
  rname: string = "";
  rcity: string = "";
  rstreet: string = "";
  rhousenumber: string = "";
  rdescription: string = "";

  @Input() food:any;
  fid: number = 0;
  fname: string = "";
  fprice: number = 0;
  fpreparationTime: number = 0;
  fallergenes: string = "";
  fdiscountMultiplier: number = 1;

  ngOnInit(): void {
    this.foodList$ = this.service.getFoodList();
    this.restaurantId = this.activatedRoute.snapshot.paramMap.get('id');
    this.restaurant = this.service.getRestaurantById(this.restaurantId).subscribe((data:any) =>{
      this.restaurant.id = data.id;
      this.restaurant.name = data.name;
      this.restaurant.city = data.city;
      this.restaurant.street = data.street;
      this.restaurant.houseNumber = data.houseNumber;
      this.restaurant.description = data.description;
    });

  }

}

