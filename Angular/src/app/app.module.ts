  import { NgModule } from '@angular/core';
  import { BrowserModule } from '@angular/platform-browser';
  import { AppRoutingModule } from './app-routing.module';
  import { AppComponent } from './app.component';
  import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
  import { SharedModule } from './components/shared/shared.module';
  import { FooterComponent } from './components/dashboard/footer/footer.component';
  import { MainComponent } from './components/dashboard/main/main.component';
  import { NavbarComponent } from './components/dashboard/navbar/navbar.component';
  import { ShippersComponent } from './components/dashboard/shippers/shippers.component';
  import { CustomersComponent } from './components/dashboard/customers/customers.component';
  import { HomeComponent } from './components/dashboard/home/home.component';
  import { HttpClientModule } from '@angular/common/http';



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
      HttpClientModule,
    ],
    providers: [],
    bootstrap: [AppComponent]
  })
  export class AppModule { }
