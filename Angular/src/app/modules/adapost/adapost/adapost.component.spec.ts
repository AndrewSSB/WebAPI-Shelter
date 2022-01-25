import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdapostComponent } from './adapost.component';

describe('AdapostComponent', () => {
  let component: AdapostComponent;
  let fixture: ComponentFixture<AdapostComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdapostComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdapostComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
