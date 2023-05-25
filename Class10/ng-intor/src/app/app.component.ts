import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  title = 'ng-intor';
  textPlaceholder = 'Enter your username';
  passwordPlaceholder = 'Enter your password';

  username = 'Mohammad';
  password = '';

  welcomeMessage = '';

  login() {
    this.welcomeMessage = `Welcome ${this.username}`;
  }
}
