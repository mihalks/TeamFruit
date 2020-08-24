import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MyDemoComponent } from './my-demo.component';

describe('MyDemoComponent', () => {
  let component: MyDemoComponent;
  let fixture: ComponentFixture<MyDemoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MyDemoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MyDemoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
