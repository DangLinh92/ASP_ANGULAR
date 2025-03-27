import { Component,inject } from '@angular/core';
import { ActivatedRoute ,RouterOutlet} from '@angular/router';

@Component({
  selector: 'app-detail',
  standalone: true,
  imports: [],
  templateUrl: './detail.component.html',
  styleUrl: './detail.component.css'
})
export class DetailComponent {
route: ActivatedRoute = inject(ActivatedRoute);
  id = '';
constructor() { 
  this.id = this.route.snapshot.params['id'];
}

}
