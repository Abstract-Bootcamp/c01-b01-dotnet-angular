import jwt_decode from 'jwt-decode';

import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';

import { Register } from './auth/interfaces/register';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private accessTokenKey = 'access_token';
  baseUrl = '';

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string
  ) {
    this.baseUrl = baseUrl + 'auth/';
  }

  login(username: string, password: string) {
    return this.http.post<any>(this.baseUrl + 'login', { username, password })
      .subscribe(res => {
        this.setSession(res.token);
      });
  }

  register(data: Register) {
    return this.http.post<any>(this.baseUrl + 'register', data)
      .subscribe(token => {
        this.setSession(token);
      });
  }


  logout() {
    localStorage.removeItem("token");
  }

  isLoggedOut() {
    return !this.isLoggedIn();
  }

  setSession(token: string) {
    localStorage.setItem(this.accessTokenKey, token);
  }

  getAccessToken() {
    return jwt_decode<unknown>(localStorage.getItem(this.accessTokenKey) || '');
  }

  isLoggedIn() {
    return !!this.getAccessToken();
  }

  clearAccessToken() {
    localStorage.removeItem(this.accessTokenKey);
  }

  hasPermission(permission: string): boolean {
    const token = this.getAccessToken();
    if (token) {
      // const decodedToken = jwt_decode(token);
      // Assuming your JWT contains a property called 'permissions' which is an array of strings
      // const permissions: string[] = decodedToken.permissions || [];
      // return permissions.includes(permission);
    }
    return false;
  }
}
