import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'https://localhost:7156/api/User'; // Adjust the URL to your API's authentication endpoints

  constructor(private http: HttpClient) {}

  // Register user
  register(user: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/register`, user);
  }

  // Login user
  login(credentials: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/login`, credentials, { withCredentials: true });
  }

  // Store the JWT token and username in localStorage
  saveUserData(token: string, userName: string): void {
    localStorage.setItem('token', token);
    localStorage.setItem('userName', userName);
  }

  // Check if the user is authenticated
  isAuthenticated(): boolean {
    return !!localStorage.getItem('token');
  }

  // Get the username
  getUserName(): string {
    return localStorage.getItem('userName') || '';
  }

  // Log out the user by removing token and user data from localStorage
  logout(): void {
    localStorage.removeItem('token');
    localStorage.removeItem('userName');
  }
}