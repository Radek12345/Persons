import { Injectable } from "@angular/core";
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import { SavePerson } from "../models/save-person";

@Injectable()
export class PersonService {
  private readonly personsEndpoint = '/api/persons';
  private readonly citiesEndpoint = '/api/cities';
  private readonly companiesEndpoint = '/api/companies';

  constructor(private http: Http) {

  }

  getPersons() {
    return this.http.get(this.personsEndpoint).map(r => r.json());
  }

  getCities() {
    return this.http.get(this.citiesEndpoint).map(c => c.json());
  }

  getCompanies() {
    return this.http.get(this.companiesEndpoint).map(c => c.json());
  }

  createPerson(person: SavePerson) {
    return this.http.post(this.personsEndpoint, person).map(p => p.json());
  }
}
