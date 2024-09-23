import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Score } from '../models/score'; // Adjust the path if necessary

@Injectable({
  providedIn: 'root'
})
export class ScoreService {
  private apiUrl = 'https://localhost:7156/api/Scores'; // Replace with your actual API URL

  constructor(private http: HttpClient) {}

  getScores(): Observable<Score[]> {
    return this.http.get<Score[]>(this.apiUrl);
  }

  addScore(score: Score): Observable<Score> {
    return this.http.post<Score>(this.apiUrl, score);
  }
}
