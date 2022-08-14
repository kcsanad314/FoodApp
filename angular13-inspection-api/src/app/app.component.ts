import { Component, NgModule, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subject } from 'rxjs';
import { AuthenticationService } from './services/authentication.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'angular13-inspection-api';
  isCollapsed: boolean = false;
  isUserAuthenticated: boolean;
  userRole = localStorage.getItem("role");
  private authChangeSub = new Subject<boolean>()
  public authChanged = this.authChangeSub.asObservable();

  constructor(private authService: AuthenticationService, private router: Router) { }

  ngOnInit(): void {
    this.authService.authChanged
    .subscribe(res => {
      this.isUserAuthenticated = res;
      this.userRole = localStorage.getItem("role");
      this.isLogged();
    })
    
  }

  public logout = () => {
    this.authService.logout();
    this.router.navigate(["/"]);
    this.isLogged();
  }

  getObject(item: string | null) {
    try {
      if(item != null){
        return JSON.parse(item);
      }
    } catch (e) {
      return item;
    }
  }

  getToken() {
    try {
      const item = localStorage.getItem('token');
      return this.getObject(item);
    } catch (e) {
      return false;
    }
	}

  isLogged() {
		const token = this.getToken();
		if (token !== null && token !== false && token !== undefined) {
      this.isUserAuthenticated = true;
			return true;
		}
    //this.isUserAuthenticated = false;
		return false;
    
	}

}
