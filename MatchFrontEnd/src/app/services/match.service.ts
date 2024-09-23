import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Match } from '../models/match'; // Adjust the path if needed

@Injectable({
  providedIn: 'root'
})
export class MatchService {
  private apiUrl = 'https://localhost:7156/api/Matches'; // Adjust the URL to your API

  constructor(private http: HttpClient) {}

  getMatches(): Observable<Match[]> {
    return this.http.get<Match[]>(this.apiUrl);
  }

  addMatch(match: Match): Observable<Match> {
    return this.http.post<Match>(this.apiUrl, match);
  }
}
