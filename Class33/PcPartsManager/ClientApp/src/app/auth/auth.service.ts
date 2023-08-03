import jwt_decode from 'jwt-decode';
import { catchError, EMPTY } from 'rxjs';

import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';

import { Register } from './interfaces/register';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  accessToken: string = 'access-token';

  constructor(private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) { }

  login(username: string, password: string) {
    this.http.post<any>(this.baseUrl + 'auth/login', { username, password }).
      pipe(
        catchError(err => {
          console.log(err);
          return EMPTY;
        })
      )
      .subscribe(res => {
        this.setSession(res.token);
        const decodedToken = jwt_decode(res.token);
        console.log(decodedToken);
      });
  }

  register(data: Register) {
    this.http.post<any>(this.baseUrl + 'auth/register', data).
      pipe(
        catchError(err => {
          console.log(err);
          return EMPTY;
        })
      )
      .subscribe(res => {
        console.log(res);
      });
  }

  logout() {
    localStorage.removeItem(this.accessToken);
  }

  isLoggedIn() {
    return !!localStorage.getItem(this.accessToken);
  }

  setSession(token: string) {
    localStorage.setItem(this.accessToken, token);
  }

  getAuthorizationToken(): string {
    return localStorage.getItem(this.accessToken) || '';
  }

  hasPermission(permissions: string[]): boolean {
    if (!this.isLoggedIn()) {
      return false;
    }

    if (permissions.length === 0) {
      return true;
    }

    let token = jwt_decode<any>(localStorage.getItem(this.accessToken) ?? '');

    if (!token) {
      return false;
    }

    let hasPermission = true;

    for (let index = 0; index < permissions.length; index++) {
      const permission = permissions[index];

      if (!token[permission]) {
        hasPermission = false;
        break;
      }
    }

    return hasPermission;
  }
}
