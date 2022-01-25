import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormSteamAccountComponent } from './form-steam-account.component';

describe('FormSteamAccountComponent', () => {
  let component: FormSteamAccountComponent;
  let fixture: ComponentFixture<FormSteamAccountComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormSteamAccountComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FormSteamAccountComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
