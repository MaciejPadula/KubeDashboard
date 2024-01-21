import { ComponentFixture, TestBed } from '@angular/core/testing';
import { SelectNamespaceComponent } from './select-namespace.component';

describe('SelectNamespaceComponent', () => {
  let component: SelectNamespaceComponent;
  let fixture: ComponentFixture<SelectNamespaceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SelectNamespaceComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(SelectNamespaceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
