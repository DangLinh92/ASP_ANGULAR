import { Component, Input, Output ,EventEmitter} from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { HeaderLayoutComponent } from '../header-layout/header-layout.component';
import { FormsModule } from '@angular/forms';
import { CurrencyPipe } from '../pipes/CurrencyPipe.pipe';
import { UpperCasePipe } from '../pipes/UpperCasePipe.pipe';
import { CommonModule } from '@angular/common';
import { ProductItem } from '../types/productItem';

@Component({
  selector: 'app-product-item',
  standalone: true,
  imports: [RouterOutlet,HeaderLayoutComponent,FormsModule,CurrencyPipe,UpperCasePipe,CommonModule,RouterLink],
  templateUrl: './productItem.component.html',
  styleUrl: './productItem.component.css'
})
export class ProductItemComponent {
    @Input() products: ProductItem[] = [];
    @Output() dataEvent = new EventEmitter<number>();

    handleDelete = (id: number) => {
        console.log('delete', id);
        this.dataEvent.emit(id); // pass data to parent
    }

    get totalPrice(): string {
        const total = this.products.reduce((sum, product) => sum + product.price, 0);
        return `Total Price: ${new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(total)}`;
      }
}