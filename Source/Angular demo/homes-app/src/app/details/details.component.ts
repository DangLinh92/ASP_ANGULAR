import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { HousingService } from '../housing.service';
import { HousingLocation } from '../housing-location';
import { FormControl,FormGroup,ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-details',
  standalone: true,
  imports: [CommonModule,ReactiveFormsModule],
  template: `
    <article>
      <img class="listing-photo" [src]="housingLocation?.photo" alt="Photo of the housing location {{housingLocation?.name}}" />
      <section class="listing-description">
        <h2 class="listing-heading">{{housingLocation?.name}}</h2>
        <p class="listing-location">{{housingLocation?.city}}, {{housingLocation?.state}}</p>
      </section>

      <section class="listing-features">
        <h2 class="section-heading">About this housing location</h2>
        <ul>
          <li *ngIf="housingLocation?.wifi">Wifi available</li>
          <li *ngIf="housingLocation?.laundry">Laundry available</li>
          <li *ngIf="!housingLocation?.wifi && !housingLocation?.laundry">No additional features</li>
        </ul>
      </section>
      <section class="listing-apply">
      <h2 class="section-heading">Apply now to live here</h2>
        <form [formGroup]="applyForm" (submit)="submitApplication()">
          <label for="first-name">First Name</label>
          <input id="first-name" type="text" formControlName="firstName" />
          <label for="last-name">Last Name</label>
          <input id="last-name" type="text" formControlName="lastName" />
          <label for="email">Email</label>
          <input id="email" type="email" formControlName="email" />
          <button type="submit" class="primary">Apply now</button>
        </form>
      </section>
    </article> 
  `,
  styleUrls: ['./details.component.css']
})
export class DetailsComponent {
route: ActivatedRoute = inject(ActivatedRoute);
housingService: HousingService = inject(HousingService);
housingLocation: HousingLocation | undefined;
housingLocationId = 0;
applyForm = new FormGroup({
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    email: new FormControl(''),
});

constructor() {
  this.housingLocationId = Number(this.route.snapshot.params['id']);
  this.housingLocation = this.housingService.getHpusingLocationById(this.housingLocationId);
  this.housingService.submitApplication(this.applyForm.value.firstName??'', this.applyForm.value.lastName??'', this.applyForm.value.email??'');
}

submitApplication() {
    this.housingService.submitApplication(
    this.applyForm.value.firstName ?? '',
    this.applyForm.value.lastName ?? '',
    this.applyForm.value.email ?? ''
  );
}

}
