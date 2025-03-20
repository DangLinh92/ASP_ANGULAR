import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderLayoutComponent } from './shared/header-layout/header-layout.component';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,HeaderLayoutComponent,FormsModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = {
    name: 'basic-app',
    old:2024
  }

  // property
  isDisable = true;

  // atrribute
  contentImage = 'https://angular.io/assets/images/logos/angular/angular.png';

  nameBtn = 'Click Me!';
  clickMessage = '';

  handleClickMe() : void {
    this.clickMessage = 'You are my hero!';
  }

  updateField():void {
    alert('You are my hero!');
  }

  bindingMessage = '';
}
