import { Component, Inject } from '@angular/core';
import { DataService } from '../services/data.service';
import { RatingModel } from '../models/rating-model';
import { style } from '@angular/animations';
import { inject } from '@angular/core/testing';

@Component({
  selector: 'app-rating',
  templateUrl: './rating.component.html',
  styleUrls: ['./style.css'],
  providers: [DataService],
  styles: [`h2, p {position:relative;}`] // нужно удалить, чтобы стили были из файла style.css
})
export class ratingComponent {

  public rating: RatingModel[];
  public studnum: string = "3180435"; // должно вводиться юзером
  public paspnum: string = "732022"; // это тоже

  constructor(private dataservice: DataService) { }

  public getRating() {
    this.dataservice.getRating(this.studnum, this.paspnum).subscribe(result => this.rating = result);
  }
}