import { ComponentFixture, TestBed } from '@angular/core/testing';
import { LoadBalancerFormComponent } from './load-balancer-form.component';

describe('LoadBalancerFormComponent', () => {
  let component: LoadBalancerFormComponent;
  let fixture: ComponentFixture<LoadBalancerFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LoadBalancerFormComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(LoadBalancerFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
