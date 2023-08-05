import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';

@Component({
  selector: 'app-sub-categories-list',
  templateUrl: './sub-categories-list.component.html',
  styleUrls: ['./sub-categories-list.component.scss']
})

export class SubCategoriesListComponent implements OnInit {
  items: any[] = [];
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  ngOnInit(): void {
    this.http.get<any>(this.baseUrl + 'subcategory/get').subscribe(result => {
      this.items = result;
    });
  }

}
