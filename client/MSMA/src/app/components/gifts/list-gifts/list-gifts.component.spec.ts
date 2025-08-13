import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListGiftsComponent } from './list-gifts.component';

describe('ListGiftsComponent', () => {
  let component: ListGiftsComponent;
  let fixture: ComponentFixture<ListGiftsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ListGiftsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListGiftsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
