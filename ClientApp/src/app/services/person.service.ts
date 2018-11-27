import { Injectable } from "@angular/core";
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class PersonService {
  private readonly personsEndpoint = '/api/persons';
  private readonly citiesEndpoint = '/api/cities';

  constructor(private http: Http) {

  }

  getPersons() {
    return this.http.get(this.personsEndpoint).map(r => r.json());
  }

  getCities() {
    return this.http.get(this.citiesEndpoint).map(c => c.json());
  }
}
