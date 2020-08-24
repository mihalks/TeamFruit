import { Component, OnInit, Input } from '@angular/core';
import { logging } from 'protractor';

@Component({
  selector: 'app-my-day',
  templateUrl: './my-day.component.html',
  styleUrls: ['./my-day.component.css']
})
export class MyDayComponent implements OnInit {
  @Input() day: StringConstructor;

  constructor() { }

  ngOnInit() {
  }

}
