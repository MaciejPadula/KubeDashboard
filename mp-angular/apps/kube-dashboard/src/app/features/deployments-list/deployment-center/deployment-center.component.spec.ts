import { ComponentFixture, TestBed } from '@angular/core/testing';
import { DeploymentCenterComponent } from './deployment-center.component';

describe('DeploymentCenterComponent', () => {
  let component: DeploymentCenterComponent;
  let fixture: ComponentFixture<DeploymentCenterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DeploymentCenterComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(DeploymentCenterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
