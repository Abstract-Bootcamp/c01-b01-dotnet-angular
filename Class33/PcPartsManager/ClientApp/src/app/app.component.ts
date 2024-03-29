import { Component } from '@angular/core';

import { AuthService } from './auth/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';


  constructor(private authService: AuthService) { }


  hasPermission(permissions: string[]): boolean {
    return this.authService.hasPermission(permissions);
  }

}
