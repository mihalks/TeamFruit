import { Injectable, Inject } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { RatingModel } from '../models/rating-model';
import { Group } from '../models/timetable-model';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  private base = window.location.origin;

  @Inject('BASE_URL') baseUrl: string; // по сути не нужно, но пусть будет =)

  constructor(private http: HttpClient) { }

  public getRating(studnumber: string, paspnumber: string) {
    return this.http.get<RatingModel[]>(this.base + "/Rating?studnumber=" + studnumber + "&paspnumber=" + paspnumber);
  }
  public getTimetable(course: number, group: number) {
    return this.http.get<Group>(this.base + "/Rasp?gr=" + course + "/" + group);
  }
}
