import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ManageRestaurantComponent } from './components/manage-restaurant/manage-restaurant.component';
import { RestaurantDetailsComponent } from './components/restaurant-details/restaurant-details.component';
import { RestaurantsComponent } from './components/restaurants/restaurants.component';
import { InspectionComponent } from './inspection/inspection.component';

const routes: Routes = [
  { path: 'restaurants', component: RestaurantsComponent },
  { path: 'inspection', component: InspectionComponent },
  { path: 'manage-restaurant', component: ManageRestaurantComponent },
  { path: 'restaurant/:id', component: RestaurantDetailsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
