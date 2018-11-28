import { Component, OnInit } from '@angular/core';
import { PersonService } from '../../services/person.service';
import { SavePerson } from '../../models/save-person';
import { Router } from '@angular/router';

@Component({
  selector: 'app-person-form',
  templateUrl: './person-form.component.html',
  styleUrls: ['./person-form.component.css']
})
export class PersonFormComponent implements OnInit {
  savePerson: SavePerson = {
    lastName: "",
    firstName: "",
    birthdate: "",
    cityId: 0,
    companyId: 0,
    companyBranchId: 0
  };

  cities: string[];
  companies: any[];
  companyBranches: string[];

  constructor(private personService: PersonService, private router: Router) { }

  ngOnInit() {
    this.personService.getCities().subscribe(cities => this.cities = cities);
    this.personService.getCompanies().subscribe(companies => this.companies = companies);
  }

  onCompanyChange() {
    let selectedCompany = this.companies.find(c => c.id == this.savePerson.companyId);
    this.companyBranches = selectedCompany ? selectedCompany.branches : [];
  }

  submit() {
    this.personService.createPerson(this.savePerson).subscribe(person => {
      this.router.navigate(['/view-persons/']);
    });
  }
}
