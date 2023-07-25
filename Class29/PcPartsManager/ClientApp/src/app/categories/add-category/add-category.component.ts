import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.scss']
})
export class AddCategoryComponent {
  name: string = '';

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  save() {
    this.http.post(this.baseUrl + 'category/post', { name: this.name }).subscribe(result => { });
  }

}
