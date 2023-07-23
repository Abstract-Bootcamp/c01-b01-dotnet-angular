import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent implements OnInit {
  public forecasts: WeatherForecast[] = [];
  displayedColumns: string[] = ['date', 'temperatureC', 'temperatureF', 'summary', 'actions'];

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }

  ngOnInit(): void {
    const forecasts$ = this.http.get<WeatherForecast[]>(this.baseUrl + 'weatherforecast');
    forecasts$.subscribe(result => {
      this.forecasts = result;
    });
  }
}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
