import { Component } from '@angular/core';

@Component({
  templateUrl: './home.component.html',
  styleUrls: ['./style.css'
  , './css/animate.scss', './css/duck.scss', './css/game.scss', './css/score.scss', './css/style.scss'
]
})
export class HomeComponent {

  currentDate: Date;

  constructor() {
    this.currentDate = new Date();
   }

  ngOnInit() {
  }
}
