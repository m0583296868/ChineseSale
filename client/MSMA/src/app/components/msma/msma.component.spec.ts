import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MsmaComponent } from './msma.component';

describe('MsmaComponent', () => {
  let component: MsmaComponent;
  let fixture: ComponentFixture<MsmaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MsmaComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MsmaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
