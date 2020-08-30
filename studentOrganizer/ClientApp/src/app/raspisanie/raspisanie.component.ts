import { Component, Inject } from '@angular/core';
import { DataService } from '../services/data.service';
import { Group } from '../models/timetable-model';

@Component({
  selector: 'app-raspisanie',
  templateUrl: './raspisanie.component.html',
  styleUrls: ['./style.css'],
  providers: [DataService]
})
export class raspisanieComponent {

  public course: number = 3; // это должен вводить пользователь
  public group: number = 147; // и это
  public timetable: Group;

  constructor(private dataService: DataService) { }

  rasp() {
    this.dataService.getTimetable(this.course, this.group).subscribe(result => {
      this.timetable = result;
      console.log(this.timetable); // лог в консоль браузера, потом можно удалить
    }
    );
  }
  ngOnInit() {
  }
}