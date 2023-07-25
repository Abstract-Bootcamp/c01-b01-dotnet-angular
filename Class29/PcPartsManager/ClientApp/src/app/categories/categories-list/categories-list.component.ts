import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';

import { Category } from '../interfaces/category';

@Component({
  selector: 'app-categories-list',
  templateUrl: './categories-list.component.html',
  styleUrls: ['./categories-list.component.scss']
})
export class CategoriesListComponent implements OnInit {
  items: Category[] = [];

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  ngOnInit(): void {
    this.refresh();
  }

  delete(id: number) {
    this.http.delete(this.baseUrl + 'category/delete/' + id).subscribe(result => {
      this.refresh();
    });
  }

  refresh() {
    this.http.get<Category[]>(this.baseUrl + 'category/get').subscribe(result => {
      this.items = result;
    });
  }

}
