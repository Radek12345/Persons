import { Component, OnInit } from '@angular/core';
import { ViewPerson } from '../../models/view-person';
import { PersonService } from '../../services/person.service';

@Component({
  selector: 'view-persons',
  templateUrl: './view-persons.component.html',
})
export class ViewPersonsComponent implements OnInit { 
  persons: ViewPerson[];

  constructor(private personService: PersonService) {

  }

  ngOnInit(): void {
    this.personService.getPersons().subscribe(persons => this.persons = persons);
  }
}
