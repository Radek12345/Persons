import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { ViewPersonsComponent } from './components/view-persons/view-persons.component';
import { PersonService } from './services/person.service';
import { HttpModule } from '@angular/http';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    ViewPersonsComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    HttpModule,
    RouterModule.forRoot([
      { path: '', component: ViewPersonsComponent, pathMatch: 'full' },
      { path: 'view-persons', component: ViewPersonsComponent }
    ])
  ],
  providers: [PersonService],
  bootstrap: [AppComponent]
})
export class AppModule { }
