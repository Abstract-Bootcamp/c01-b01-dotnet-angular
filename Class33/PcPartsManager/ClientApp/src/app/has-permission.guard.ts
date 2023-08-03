import { Observable } from 'rxjs';

import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRouteSnapshot, Router, RouterStateSnapshot, UrlTree } from '@angular/router';

import { AuthService } from './auth/auth.service';

@Injectable({
  providedIn: 'root'
})
export class HasPermissionGuard {

  constructor(private authService: AuthService, private router: Router, private snackBar: MatSnackBar) { }
  canActivate(route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot):
    | Observable<boolean | UrlTree>
    | Promise<boolean | UrlTree>
    | boolean
    | UrlTree {

    console.log(route.data);
    if (!this.authService.hasPermission(route.data.permissions)) {
      this.snackBar.open('You do not have permission to view this page', 'OK');
      return false;
    }
    // logged in, so return true
    return true;
  }
}
