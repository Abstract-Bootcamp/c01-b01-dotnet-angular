import { Observable } from 'rxjs';

import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';

import { AuthService } from './auth/auth.service';

@Injectable({
  providedIn: 'root'
})
export class PermissionGuard {

  constructor(private authService: AuthService, private _snackBar: MatSnackBar) { }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {

    if (!this.authService.hasPermission(route.data.permissions)) {
      this._snackBar.open("You do not have a permission to view this page", "Ok");
      return false;
    }

    return true;
  }

}
