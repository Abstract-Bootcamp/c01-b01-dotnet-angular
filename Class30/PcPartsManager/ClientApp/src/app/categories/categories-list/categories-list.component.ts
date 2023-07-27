import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';

import { Category } from '../interfaces/category';
import { CategoryPagination } from '../interfaces/categoryPagination';

@Component({
  selector: 'app-categories-list',
  templateUrl: './categories-list.component.html',
  styleUrls: ['./categories-list.component.scss']
})
export class CategoriesListComponent implements OnInit {
  resultsLength = 0;
  pageSize = 2;
  pageIndex = 0;

  items: CategoryPagination;
  displayedColumns: string[] = ['name'];

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
    this.http.get<CategoryPagination>(
      `${this.baseUrl}category/get?pageIndex=${this.pageIndex}&pageSize=${this.pageSize}`)
      .subscribe(result => {
        this.items = result;
        this.resultsLength = result.total;
      });
  }

  handlePageEvent(e: PageEvent) {
    // this.pageEvent = e;
    // this.length = e.length;
    this.pageSize = e.pageSize;
    this.pageIndex = e.pageIndex;
    this.refresh();
  }


}
