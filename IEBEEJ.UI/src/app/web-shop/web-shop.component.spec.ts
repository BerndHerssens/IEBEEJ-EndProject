import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WebShopComponent } from './web-shop.component';

describe('WebShopComponent', () => {
  let component: WebShopComponent;
  let fixture: ComponentFixture<WebShopComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [WebShopComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(WebShopComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
