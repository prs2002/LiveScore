import { Component, OnInit } from '@angular/core';
import { MatchService } from '../../services/match.service'; // Adjust the path if needed
import { Match } from '../../models/match'; // Adjust the path if needed

@Component({
  selector: 'app-matches',
  templateUrl: './matches.component.html',
  styleUrls: ['./matches.component.css']
})
export class MatchesComponent implements OnInit {
  matches: Match[] = [];
  newMatch: Match = {
    matchID: '',
    team1: '',
    team2: '',
    sport: '',
    startTime: new Date(),
    status: 'Scheduled'
  };
  
  // Add a boolean to control the visibility of the form
  isFormVisible: boolean = false;

  constructor(private matchService: MatchService) {}

  ngOnInit(): void {
    this.loadMatches();
  }

  loadMatches(): void {
    this.matchService.getMatches().subscribe((data: Match[]) => {
      this.matches = data;
    });
  }

  addMatch(): void {
    this.matchService.addMatch(this.newMatch).subscribe((match: Match) => {
      this.matches.push(match);
      this.resetForm();
      this.isFormVisible = false; // Hide the form after adding a match
    });
  }

  resetForm(): void {
    this.newMatch = {
      matchID: '',
      team1: '',
      team2: '',
      sport: '',
      startTime: new Date(),
      status: 'Scheduled'
    };
  }
  
  // Method to toggle the visibility of the form
  toggleForm(): void {
    this.isFormVisible = !this.isFormVisible;
  }
}
