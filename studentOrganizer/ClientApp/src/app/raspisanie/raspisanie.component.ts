import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-raspisanie',
  templateUrl: './raspisanie.component.html',
  styleUrls: ['./style.css']
})
export class raspisanieComponent {
  public forecasts: OrganizerForecast[];
private base = "";
private http : HttpClient;
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.base = baseUrl;
    this.http = http;
    // http.get<OrganizerForecast[]>(baseUrl + 'Rasp').subscribe(result => {
    //   this.forecasts = result;
    //   console.log(this.forecasts);
    // }, error => console.error(error));
  }
  rasp(){
     this.http.get<string>(this.base + 'Rasp').subscribe(result => {
    console.log(result);
  }, error => console.error(error));}
}

interface OrganizerForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
