import { Component, OnInit } from '@angular/core';
import { PersonService } from '../../services/person.service';

@Component({
  selector: 'app-person-form',
  templateUrl: './person-form.component.html',
  styleUrls: ['./person-form.component.css']
})
export class PersonFormComponent implements OnInit {
  cities: string[];

  constructor(private personService: PersonService) { }

  ngOnInit() {
    this.personService.getCities().subscribe(cities => this.cities = cities);
  }

}
