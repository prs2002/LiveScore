import { Component, OnInit } from '@angular/core';
import { Score } from 'src/app/models/score';
import { ScoreService } from 'src/app/services/score.service';

@Component({
  selector: 'app-scores',
  templateUrl: './scores.component.html',
  styleUrls: ['./scores.component.css']
})
export class ScoresComponent implements OnInit {
  scores: Score[] = [];
  newScore: Score = {
    scoreID: '',
    matchID: '',
    team1Score: 0,
    team2Score: 0,
    lastUpdated: new Date(),
  };

  isFormVisible: boolean = false;

  constructor(private scoreService: ScoreService) {}

  ngOnInit(): void {
    this.loadScores();
  }

  loadScores(): void {
    this.scoreService.getScores().subscribe((data: Score[]) => {
      this.scores = data;
    });
  }

  addScore(): void {
    this.scoreService.addScore(this.newScore).subscribe((score: Score) => {
      this.scores.push(score);
      this.resetForm();
      this.isFormVisible = false;
    });
  }

  resetForm(): void {
    this.newScore = {
      scoreID: '',
      matchID: '',
      team1Score: 0,
      team2Score: 0,
      lastUpdated: new Date(),
    };
  }

  toggleForm(): void {
    this.isFormVisible = !this.isFormVisible;
  }
}
