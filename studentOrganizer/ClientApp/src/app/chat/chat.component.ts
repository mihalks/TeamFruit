import { Component, OnInit } from '@angular/core';
import { HubConnectionBuilder } from '@aspnet/signalr';
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-chat-component',
  templateUrl: './chat.component.html',
  styleUrls: ['./style.css']
})
export class chatComponent implements OnInit {
  public currentCount = 0;

  private connection;
  name: string = '';

  public incrementchat() {
    this.currentCount++;
  }

  sendMessage() {
    this.connection.invoke('Send', this.name);
  }

  async ngOnInit() {
    this.connection = new HubConnectionBuilder().withUrl('/mychat').build();

    this.connection.on('Send', (data) => {
      console.log(data);
    });
    await this.connection.start();
    this.connection.invoke('Send', 'Hello');
  }
}
