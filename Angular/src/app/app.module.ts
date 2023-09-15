  import { NgModule } from '@angular/core';
  import { BrowserModule } from '@angular/platform-browser';
  import { AppRoutingModule } from './app-routing.module';
  import { AppComponent } from './app.component';
  import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
  import { SharedModule } from './components/shared/shared.module';
  import { FooterComponent } from './components/footer/footer.component';
  import { MainComponent } from './components/main/main.component';
  import { NavbarComponent } from './components/navbar/navbar.component';
  import { ShippersComponent } from './components/shippers/shippers.component';
  import { CustomersComponent } from './components/customers/customers.component';
  import { HomeComponent } from './components/home/home.component';



  @NgModule({
    declarations: [
      AppComponent,
      FooterComponent,
      MainComponent,
      NavbarComponent,
      ShippersComponent,
      CustomersComponent,
      HomeComponent,
    ],
    imports: [
      BrowserModule,
      AppRoutingModule,
      BrowserAnimationsModule,
      SharedModule,
    ],
    providers: [],
    bootstrap: [AppComponent]
  })
  export class AppModule { }
