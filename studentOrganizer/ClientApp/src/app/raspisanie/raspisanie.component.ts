import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-raspisanie',
  templateUrl: './raspisanie.component.html'
})
export class raspisanieComponent {
  public forecasts: OrganizerForecast[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<OrganizerForecast[]>(baseUrl + 'organizerforecast').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }
}

interface OrganizerForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
