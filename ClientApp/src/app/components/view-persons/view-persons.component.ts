import { Component, OnInit } from '@angular/core';
import { ReadPerson } from '../../models/read-person';
import { PersonService } from '../../services/person.service';

@Component({
  selector: 'view-persons',
  templateUrl: './view-persons.component.html',
})
export class ViewPersonsComponent implements OnInit { 
  persons: ReadPerson[];

  constructor(private personService: PersonService) {

  }

  ngOnInit(): void {
    this.personService.getPersons().subscribe(persons => this.persons = persons);
  }

  deletePerson(id: number) {
    this.personService.deletePerson(id).subscribe(p => {
      this.persons.splice(this.persons.map(p => p.id).indexOf(id), 1);
    });
  }
}
