import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ManageRestaurantComponent } from './components/manage-restaurant/manage-restaurant.component';
import { RestaurantDetailsComponent } from './components/restaurant-details/restaurant-details.component';
import { RestaurantsComponent } from './components/restaurants/restaurants.component';
import { InspectionComponent } from './inspection/inspection.component';
import { AuthGuard } from './services/auth-guard.service';
//import { AuthenticationComponent } from './components/authentication/authentication.component';

const routes: Routes = [
  { path: 'restaurants', component: RestaurantsComponent, canActivate: [AuthGuard] },
  { path: 'inspection', component: InspectionComponent },
  { path: 'manage-restaurant', component: ManageRestaurantComponent, canActivate: [AuthGuard] },
  { path: 'restaurant/:id', component: RestaurantDetailsComponent, canActivate: [AuthGuard] },
  { path: 'authentication', loadChildren: () => import('./components/authentication/authentication.module').then(m => m.AuthenticationModule) },
  //{ path: '404', component : NotFoundComponent},
  //{ path: '', redirectTo: '/home', pathMatch: 'full' },
  //{ path: '**', redirectTo: '/404', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
