import { Component } from '@angular/core';

@Component({
  templateUrl: './home.component.html',
  styleUrls: ['./style.css']
})
export class HomeComponent {

  currentDate: Date;

  constructor() {
    this.currentDate = new Date();
   }

  ngOnInit() {
  }
}
