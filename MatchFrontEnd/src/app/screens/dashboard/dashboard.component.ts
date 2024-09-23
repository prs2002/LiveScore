import { Component, OnInit } from '@angular/core';
import { Event } from 'src/app/models/event';
import { Match } from 'src/app/models/match';
import { Score } from 'src/app/models/score';
import { EventService } from 'src/app/services/event.service';
import { MatchService } from 'src/app/services/match.service';
import { ScoreService } from 'src/app/services/score.service';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  ongoingMatches: Match[] = [];
  scores: Score[] = [];
  events: Event[] = [];
  isScoreFormVisible: boolean = false;
  isEventFormVisible: boolean = false;
  newScore: Score = {
    scoreID: '',
    matchID: '',
    team1Score: 0,
    team2Score: 0,
    lastUpdated: new Date(),
  };
  newEvent: Event = {
    eventID: '',
    matchID: '',
    eventType: '',
    description: '',
    timestamp: new Date(),
  };

  constructor(
    private matchService: MatchService,
    private scoreService: ScoreService,
    private eventService: EventService
  ) {}

  ngOnInit(): void {
    this.loadOngoingMatches();
    this.loadScores();
    this.loadEvents();
  }

  loadOngoingMatches(): void {
    this.matchService.getMatches().subscribe((data: Match[]) => {
      this.ongoingMatches = data.filter(match => match.status === 'Ongoing');
    });
  }

  loadScores(): void {
    this.scoreService.getScores().subscribe((data: Score[]) => {
      this.scores = data;
    });
  }

  loadEvents(): void {
    this.eventService.getEvents().subscribe((data: Event[]) => {
      this.events = data;
    });
  }

  getScoresByMatch(matchID: string): Score[] {
    return this.scores.filter(score => score.matchID === matchID);
  }

  getEventsByMatch(matchID: string): Event[] {
    return this.events.filter(event => event.matchID === matchID);
  }

  toggleScoreForm(): void {
    this.isScoreFormVisible = !this.isScoreFormVisible;
  }

  toggleEventForm(): void {
    this.isEventFormVisible = !this.isEventFormVisible;
  }

  addScore(): void {
    this.scoreService.addScore(this.newScore).subscribe((score: Score) => {
      this.scores.push(score);
      this.resetScoreForm();
    });
  }

  addEvent(): void {
    this.eventService.addEvent(this.newEvent).subscribe((event: Event) => {
      this.events.push(event);
      this.resetEventForm();
    });
  }

  resetScoreForm(): void {
    this.newScore = {
      scoreID: '',
      matchID: '',
      team1Score: 0,
      team2Score: 0,
      lastUpdated: new Date(),
    };
    this.isScoreFormVisible = false;
  }

  resetEventForm(): void {
    this.newEvent = {
      eventID: '',
      matchID: '',
      eventType: '',
      description: '',
      timestamp: new Date(),
    };
    this.isEventFormVisible = false;
  }
}