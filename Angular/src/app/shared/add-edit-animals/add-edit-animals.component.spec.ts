import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditAnimalsComponent } from './add-edit-animals.component';

describe('AddEditAnimalsComponent', () => {
  let component: AddEditAnimalsComponent;
  let fixture: ComponentFixture<AddEditAnimalsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditAnimalsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditAnimalsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
