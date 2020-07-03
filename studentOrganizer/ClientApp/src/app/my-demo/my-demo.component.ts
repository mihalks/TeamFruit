import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-my-demo',
  templateUrl: './my-demo.component.html',
  styleUrls: ['./my-demo.component.css']
})
export class MyDemoComponent implements OnInit {

  days = [
    {name: 'Понедельник', color: 'red'},
    {name: 'Вторник', color: 'blue' },
    {name: 'Среда', color: 'yellow'},
    {name: 'четверг', color: 'green'}
  ];

  constructor() { }

  ngOnInit() {
  }

}
