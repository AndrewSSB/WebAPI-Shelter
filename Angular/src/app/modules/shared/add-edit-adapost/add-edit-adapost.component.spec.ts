import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditAdapostComponent } from './add-edit-adapost.component';

describe('AddEditAdapostComponent', () => {
  let component: AddEditAdapostComponent;
  let fixture: ComponentFixture<AddEditAdapostComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditAdapostComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditAdapostComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
