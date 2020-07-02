import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-my-day',
  templateUrl: './my-day.component.html',
  styleUrls: ['./my-day.component.css']
})
export class MyDayComponent implements OnInit {
  @Input() day: string;

  constructor() { }

  ngOnInit() {
  }

}
