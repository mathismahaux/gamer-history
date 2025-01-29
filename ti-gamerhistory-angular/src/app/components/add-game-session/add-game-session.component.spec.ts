import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddGameSessionComponent } from './add-game-session.component';

describe('AddGameSessionComponent', () => {
  let component: AddGameSessionComponent;
  let fixture: ComponentFixture<AddGameSessionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddGameSessionComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddGameSessionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
