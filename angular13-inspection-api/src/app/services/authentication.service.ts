import { AuthResponseDto } from './../interfaces/response/authResponseDto.model';
import { Injectable } from '@angular/core';
import { UserForRegistrationDto } from './../interfaces/user/userRegistrationDto.model'; 
import { RegistrationResponseDto } from './../interfaces/response/registrationResponseDto.model';
import { HttpClient } from '@angular/common/http';
import { EnvironmentUrlService } from './environment-url.service';
import { UserForAuthenticationDto } from './../interfaces/user/userAuthenticationDto.model';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private authChangeSub = new Subject<boolean>()
  public authChanged = this.authChangeSub.asObservable();

  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) { }

  public registerUser = (route: string, body: UserForRegistrationDto) => {
    return this.http.post<RegistrationResponseDto> (this.createCompleteRoute(route, this.envUrl.urlAddress), body);
  }

  public loginUser = (route: string, body: UserForAuthenticationDto) => {
    return this.http.post<AuthResponseDto>(this.createCompleteRoute(route, this.envUrl.urlAddress), body);
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

		if (token !== null && token !== false) {
			return true;
		}
		return false;
	}

  public sendAuthStateChangeNotification = (isAuthenticated: boolean) => {
    this.authChangeSub.next(isAuthenticated);
  }

  public logout = () => {
    localStorage.removeItem("token");
    this.sendAuthStateChangeNotification(false);
  }

  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  }
}