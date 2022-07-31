import {Injectable} from '@angular/core';
import {CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router} from '@angular/router';


import { Observable } from 'rxjs';
import {AuthenticationService} from './authentication.service';


@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
	constructor(private router: Router,
				private _authService: AuthenticationService,
				private _router: Router) {
	}
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | Observable<boolean> | Promise<boolean> {
    if (this._authService.isLogged()) {
      return true;
    } else {
      this.goLoginPage();
    }
    return false;
  }

 
  goLoginPage() {
    this._router.navigate(['login']);
  }

  goMainpage() {
    this._router.navigate(['dashboard']);
  }


}
