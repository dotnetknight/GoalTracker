import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AutosizeModule } from 'ngx-autosize';
import { HeaderComponent } from './navigation/header/header.component';
import { SidenavComponent } from './navigation/side-nav/side-nav.component';
import { EmployeeModule } from './users/users.module';
import { SharedModule } from './shared.module';
import { SnackbarMessageComponent } from './_shared/snackbar-message/snackbar-message.component';
import { HttpClientModule } from '@angular/common/http';
import { TrackerModule } from './tracker/tracker.module';
import { WelcomeComponent } from './welcome/welcome.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    SidenavComponent,
    SnackbarMessageComponent,
    WelcomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    AutosizeModule,
    EmployeeModule,
    SharedModule,
    HttpClientModule,
    TrackerModule
  ],
  providers: [],

  bootstrap: [AppComponent],

  entryComponents: [
    SnackbarMessageComponent,
  ],

})
export class AppModule { }
