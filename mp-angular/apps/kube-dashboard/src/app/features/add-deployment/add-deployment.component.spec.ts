import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AddDeploymentComponent } from './add-deployment.component';

describe('AddDeploymentComponent', () => {
  let component: AddDeploymentComponent;
  let fixture: ComponentFixture<AddDeploymentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddDeploymentComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(AddDeploymentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
