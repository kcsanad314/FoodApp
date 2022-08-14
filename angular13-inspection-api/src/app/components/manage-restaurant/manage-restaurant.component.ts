import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { RestaurantApiService } from 'src/app/services/restaurant-api.service';

@Component({
  selector: 'app-manage-restaurant',
  templateUrl: './manage-restaurant.component.html',
  styleUrls: ['./manage-restaurant.component.css']
})
export class ManageRestaurantComponent implements OnInit {

  restaurantList$!: Observable<any[]>;
  foodList$!: Observable<any[]>;
  

  constructor(private service:RestaurantApiService, private authService: AuthenticationService) { }

  @Input() restaurant:any;
  rid: number = 0;
  rname: string = "";
  rcity: string = "";
  rstreet: string = "";
  rhousenumber: string = "";
  rdescription: string = "";
  userId: string|null = localStorage.getItem("userId");

  @Input() food:any;
  fid: number = 0;
  fname: string = "";
  fprice: number = 0;
  fpreparationTime: number = 0;
  fallergenes: string = "";
  fdiscountMultiplier: number = 1;
  restid: string= "";


  ngOnInit(): void {
    this.restid = this.restaurant.rid;
    this.rname = this.restaurant.rname;
    this.rcity = this.restaurant.rcity;
    this.rstreet = this.restaurant.rstreet;
    this.rhousenumber = this.restaurant.rhousenumber;
    this.rdescription = this.restaurant.rdescription;
    this.userId = this.restaurant.userId;
    this.restaurantList$ = this.service.getRestaurantList();

    this.fid = this.food.fid;
    this.fname = this.food.fname;
    this.fprice = this.food.fprice;
    this.fpreparationTime = this.food.fpreparationTime;
    this.fallergenes = this.food.fallergenes;
    this.fdiscountMultiplier = this.food.fdiscountMultiplier;
    this.foodList$ = this.service.getFoodList();    
  }

  addRestaurant(){
    var restaurant ={
      name:this.rname,
      city:this.rcity,
      street:this.rstreet,
      housenumber:this.rhousenumber,
      description:this.rdescription,
      userId:this.userId //make it dynamic
    }
    this.service.addRestaurant(restaurant).subscribe();
  }

  addFood(){
    var food ={
      name:this.fname,
      price:this.fprice,
      preparationTime:this.fpreparationTime,
      allergenes:this.fallergenes,
      discountMultiplier:this.fdiscountMultiplier,
      restaurantId: this.restid //make it dynamic
    }
    this.service.getRestaurantByUserId(localStorage.getItem("userId")).subscribe(data =>{
      console.log(data.id);
      food.restaurantId = data.id;
      this.service.addFood(food).subscribe();
    });
  }

}
