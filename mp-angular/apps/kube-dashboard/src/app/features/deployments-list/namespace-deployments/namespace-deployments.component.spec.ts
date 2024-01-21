import { ComponentFixture, TestBed } from '@angular/core/testing';
import { NamespaceDeploymentsComponent } from './namespace-deployments.component';

describe('NamespaceDeploymentsComponent', () => {
  let component: NamespaceDeploymentsComponent;
  let fixture: ComponentFixture<NamespaceDeploymentsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NamespaceDeploymentsComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(NamespaceDeploymentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
