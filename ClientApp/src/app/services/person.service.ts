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

  getPerson(id: number) {
    return this.http.get(this.personsEndpoint + "/" + id).map(r => r.json());
  }

  getCities() {
    return this.http.get(this.citiesEndpoint).map(r => r.json());
  }

  getCompanies() {
    return this.http.get(this.companiesEndpoint).map(r => r.json());
  }

  createPerson(person: SavePerson) {
    return this.http.post(this.personsEndpoint, person).map(r => r.json());
  }

  updatePerson(person: SavePerson) {
    return this.http.put(this.personsEndpoint + "/" + person.id, person).map(r => r.json());
  }

  deletePerson(id: number) {
    return this.http.delete(this.personsEndpoint + "/" + id).map(r => r.json());
  } 
}
