import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-raiting',
  templateUrl: './raiting.component.html',
  styleUrls: ['./style.css']
})
export class ratingComponent {
  public currentCount = 0;

  private connection;
  name: string = '';

  public incrementchat() {
    this.currentCount++;
  }
}

