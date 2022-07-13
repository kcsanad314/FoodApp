import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RestaurantsComponent } from './components/restaurants/restaurants.component';
import { InspectionComponent } from './inspection/inspection.component';

const routes: Routes = [
  { path: 'restaurants', component: RestaurantsComponent },
  { path: 'inspection', component: InspectionComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
