import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MyDayComponent } from './my-day.component';

describe('MyDayComponent', () => {
  let component: MyDayComponent;
  let fixture: ComponentFixture<MyDayComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MyDayComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MyDayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
