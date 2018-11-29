import { Component, OnInit } from '@angular/core';
import { PersonService } from '../../services/person.service';
import { SavePerson } from '../../models/save-person';
import { Router, ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/forkJoin';
import * as moment from 'moment';

@Component({
  selector: 'app-person-form',
  templateUrl: './person-form.component.html',
  styleUrls: ['./person-form.component.css']
})
export class PersonFormComponent implements OnInit {
  savePerson: SavePerson = {
    id: undefined,
    lastName: "",
    firstName: "",
    birthdate: new Date(),
    cityId: 0,
    companyId: 0,
    companyBranchId: 0
  };

  cities: string[];
  companies: any[];
  companyBranches: string[];
  isEditMode: boolean = false;

  constructor(private personService: PersonService, private route: ActivatedRoute, private router: Router) {
    moment.locale('pl');

    route.params.subscribe(p => {
      if (p['id']) {
        this.savePerson.id = p['id'];
        this.isEditMode = true;
      }
    });
  }

  ngOnInit() {
    let observables = [
      this.personService.getCities(),
      this.personService.getCompanies()
    ];

    if (this.isEditMode) 
      observables.push(this.personService.getPerson(this.savePerson.id));

    Observable.forkJoin(observables).subscribe(data => {
      this.cities = data[0];
      this.companies = data[1];

      if (this.isEditMode) {
        this.savePerson = data[2];
        this.savePerson.birthdate = new Date(this.savePerson.birthdate);
        this.onCompanyChange();
      }
    });
  }

  onCompanyChange() {
    let selectedCompany = this.companies.find(c => c.id == this.savePerson.companyId);
    this.companyBranches = selectedCompany ? selectedCompany.branches : [];
  }

  submit() {
    // dodanie jednego dnia do daty urodzenia,
    // gdyż z jakiegoś powodu po wyborze na widoku zapisuje się z jednym dniem wstecz
    this.savePerson.birthdate.setDate(this.savePerson.birthdate.getDate() + 1);

    let observable$ = this.isEditMode ? this.personService.updatePerson(this.savePerson)
      : this.personService.createPerson(this.savePerson);

    observable$.subscribe(person => {
      this.router.navigate(['/view-persons/']);
    });
  }
}
