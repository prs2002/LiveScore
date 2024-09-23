import { Component, OnInit } from '@angular/core';
import { Event } from 'src/app/models/event';
import { EventService } from 'src/app/services/event.service';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.css']
})
export class EventsComponent implements OnInit {
  events: Event[] = [];
  newEvent: Event = {
    eventID: '',
    matchID: '',
    eventType: '',
    description: '',
    timestamp: new Date(),
  };

  isFormVisible: boolean = false;

  constructor(private eventService: EventService) {}

  ngOnInit(): void {
    this.loadEvents();
  }

  loadEvents(): void {
    this.eventService.getEvents().subscribe((data: Event[]) => {
      this.events = data;
      console.log(this.events);
    });
  }

  addEvent(): void {
    this.eventService.addEvent(this.newEvent).subscribe((event: Event) => {
      this.events.push(event);
      this.resetForm();
      this.isFormVisible = false;
    });
  }

  resetForm(): void {
    this.newEvent = {
      eventID: '',
      matchID: '',
      eventType: '',
      description: '',
      timestamp: new Date(),
    };
  }

  toggleForm(): void {
    this.isFormVisible = !this.isFormVisible;
  }
}