import { Component } from '@angular/core';

@Component({
  selector: 'app-chat-component',
  templateUrl: './chat.component.html'
})
export class chatComponent {
  public currentCount = 0;

  public incrementchat() {
    this.currentCount++;
  }
}
