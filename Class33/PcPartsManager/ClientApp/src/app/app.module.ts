import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatTableModule } from '@angular/material/table';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { AddCategoryComponent } from './categories/add-category/add-category.component';
import { CategoriesListComponent } from './categories/categories-list/categories-list.component';
import { DeleteCategoryComponent } from './categories/delete-category/delete-category.component';
import { CounterComponent } from './counter/counter.component';
import { HighlightDirective } from './directives/highlight.directive';
import { HasPermissionGuard } from './has-permission.guard';
import { HomeComponent } from './home/home.component';
import { AuthorizationInterceptor } from './interceptors/authorization.interceptor';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import {
  AddSubCategoriesComponent
} from './sub-categories/add-sub-categories/add-sub-categories.component';
import {
  SubCategoriesListComponent
} from './sub-categories/sub-categories-list/sub-categories-list.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    CategoriesListComponent,
    AddCategoryComponent,
    DeleteCategoryComponent,
    SubCategoriesListComponent,
    AddSubCategoriesComponent,
    HighlightDirective,
    LoginComponent,
    RegisterComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MatTableModule,
    MatPaginatorModule,
    MatProgressSpinnerModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatCheckboxModule,
    MatSnackBarModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      {
        path: 'categories',
        component: CategoriesListComponent,
        canActivate: [HasPermissionGuard],
        data: { permissions: ['category', 'category.view'] }
      },
      { path: 'add-category', component: AddCategoryComponent },
      { path: 'edit-category/:id', component: AddCategoryComponent },
      { path: 'counter', component: CounterComponent },
      { path: 'subcategories', component: SubCategoriesListComponent },
      { path: 'add-subcategory', component: AddSubCategoriesComponent },
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegisterComponent },
    ]),
    BrowserAnimationsModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizationInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
