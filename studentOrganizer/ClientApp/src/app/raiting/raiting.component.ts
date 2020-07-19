import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-raiting',
  templateUrl: './raiting.component.html',
  styleUrls: ['./style.css' 
  // './css/game.css', './css/animate.scss', './css/duck.scss', './css/game.scss', './css/score.scss', './css/style.scss'
]
})
export class raitingComponent {
  public currentCount = 0;

  private connection;
  name: string = '';

  public incrementchat() {
    this.currentCount++;
  }
}

