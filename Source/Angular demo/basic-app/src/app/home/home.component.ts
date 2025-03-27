import { Component } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { HeaderLayoutComponent } from '../shared/header-layout/header-layout.component';
import { FormsModule } from '@angular/forms';
import { CurrencyPipe } from '../shared/pipes/CurrencyPipe.pipe';
import { UpperCasePipe } from '../shared/pipes/UpperCasePipe.pipe';
import { CommonModule } from '@angular/common';
import { ProductItem } from '../shared/types/productItem';
import { ProductItemComponent } from '../shared/product-item/productItem.component';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [RouterOutlet,HeaderLayoutComponent,FormsModule,CurrencyPipe,UpperCasePipe,CommonModule,RouterLink,ProductItemComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

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

  isActive = true;

  isVisible = true;

  products :ProductItem[] = [
    { id: 1, name: 'product 1', price: 1000,image:'assets/images/samba-og.jpg' },
    { id: 2, name: 'product 2', price: 2000,image:'assets/images/samba-og.jpg' },
    { id: 3, name: 'product 3', price: 3000,image:'assets/images/samba-og.jpg' },
    { id: 4, name: 'product 4', price: 4000,image:'assets/images/samba-og.jpg' },
    { id: 5, name: 'product 5', price: 5000,image:'assets/images/samba-og.jpg' },
  ]

  handleDelete = (event: number) => {
    console.log('delete parent', event);
    const index = this.products.findIndex((product) => product.id === event);

    if(index !== -1) {
      this.products.splice(index, 1);
    }
  }
}
