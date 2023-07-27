import { catchError, EMPTY } from 'rxjs';

import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { Category } from '../interfaces/category';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.scss']
})
export class AddCategoryComponent implements OnInit {
  id: number = 0;
  name: string = '';

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string,
    route: ActivatedRoute,
    private router: Router) {
    this.id = +route.snapshot.params['id'];
  }

  ngOnInit(): void {
    if (this.id) {
      this.http.get<Category>(this.baseUrl + 'category/get/' + this.id).subscribe(result => {
        this.name = result.name;
      });
    }
  }

  addCategory() {
    const body = {
      name: this.name
    };

    let observable = this.http.put(this.baseUrl + 'category/edit/' + this.id, body);
    if (!this.id) {
      observable = this.http.post(this.baseUrl + 'category/post', body);
    }

    observable
      .pipe(
        catchError((err) => {
          console.log(err);
          return EMPTY;
        }))
      .subscribe(() => {
        //navigate to categories list
        this.router.navigateByUrl('/categories');
      });

  }
}
