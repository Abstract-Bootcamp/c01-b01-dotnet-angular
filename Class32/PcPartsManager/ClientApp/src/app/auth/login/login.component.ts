import { AuthService } from 'src/app/auth.service';

import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  form: FormGroup;

  constructor(//private fb: FormBuilder,
    private authService: AuthService) {

    // this.form = this.fb.group({
    //   email: ['', Validators.required],
    //   password: ['', Validators.required]
    // });
  }

  login() {
    const val = this.form.value;

    if (val.email && val.password) {
      this.authService.login(val.email, val.password);
    }
  }
}