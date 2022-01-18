import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent 
{
  title : string = 'Hello IPME';

  private getUpperTitle(): string {
    return this.title.toUpperCase();
  }

  Coucou(): void {
    this.title = "Coucou"+" Ipme";
  }
}
