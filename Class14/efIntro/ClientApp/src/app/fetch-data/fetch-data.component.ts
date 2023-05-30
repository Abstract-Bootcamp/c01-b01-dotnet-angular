import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public students: Student[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.post<Student[]>(baseUrl + 'student/Create', { id: 1, fullName: 'test' }).subscribe(result => {
      this.students = result;
    }, error => console.error(error));
  }
}

interface Student {
  id: number;
  fullName: string;
}
