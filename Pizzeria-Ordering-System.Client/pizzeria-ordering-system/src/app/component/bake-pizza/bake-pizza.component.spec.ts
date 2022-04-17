import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BakePizzaComponent } from './bake-pizza.component';

describe('BakePizzaComponent', () => {
  let component: BakePizzaComponent;
  let fixture: ComponentFixture<BakePizzaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BakePizzaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BakePizzaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
