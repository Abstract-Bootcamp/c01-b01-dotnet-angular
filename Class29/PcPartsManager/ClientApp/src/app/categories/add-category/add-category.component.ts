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

  addCategory() {
    const body = {
      name: this.name
    };

    this.http.post(this.baseUrl + 'category/post', body).subscribe();
  }
}
