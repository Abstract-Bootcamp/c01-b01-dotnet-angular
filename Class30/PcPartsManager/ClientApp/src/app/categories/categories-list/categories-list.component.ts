import { tap } from 'rxjs';

import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';

import { Category } from '../interfaces/category';
import { Pagination } from '../interfaces/pagination';

@Component({
  selector: 'app-categories-list',
  templateUrl: './categories-list.component.html',
  styleUrls: ['./categories-list.component.scss']
})
export class CategoriesListComponent implements OnInit {
  items: Pagination;
  displayedColumns: string[] = ['name'];

  length: number = 3;
  pageIndex: number = 0;
  pageSize: number = 5;

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
    this.http.get<Pagination>(
      `${this.baseUrl}category/getPagination?pageIndex=${this.pageIndex}&pageSize=${this.pageSize}`)
      .pipe(
      // tap(result => { console.log(result) })
    )
      .subscribe(result => {
        this.length = result.length;
        this.items = result;
      });
  }

  handlePageEvent(event: PageEvent) {
    this.pageIndex = event.pageIndex;
    this.pageSize = event.pageSize;
    this.refresh();
  }
}
