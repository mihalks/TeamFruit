import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-my-demo',
  templateUrl: './my-demo.component.html',
  styleUrls: ['./my-demo.component.css']
})
export class MyDemoComponent implements OnInit {

  days = [
    {name: 'sun', color: 'red'},
    {name: 'mon', color: 'blue' }, 
    {name: 'tue', color: 'yellow'}];

  constructor() { }

  ngOnInit() {
  }

}
