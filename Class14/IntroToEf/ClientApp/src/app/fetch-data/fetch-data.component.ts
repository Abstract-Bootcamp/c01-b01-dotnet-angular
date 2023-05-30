import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public employees: Employee[] = [];

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.http.get<Employee[]>(this.baseUrl + 'employee/GetEmployees').subscribe(result => {
      this.employees = result;
    }, error => console.error(error));
  }

  getEmployees() {
    this.http.get<Employee[]>(this.baseUrl + 'employee/GetEmployees').subscribe(result => {
      this.employees = result;
    }, error => console.error(error));
  }

}

interface Employee {
  id: number;
  name: string;
  age: number;
}
