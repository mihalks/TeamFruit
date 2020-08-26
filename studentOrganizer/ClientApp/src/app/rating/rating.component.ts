import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-rating',
  templateUrl: './rating.component.html',
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

