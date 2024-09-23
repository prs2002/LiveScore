import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  credentials = {
    email: '',
    password: ''
  };

  errorMessage: string = '';

  constructor(private authService: AuthService, private router: Router) {}
  navigateTo(route: string) {
    this.router.navigate([route]);
  }
  onLogin(): void {
    this.authService.login(this.credentials).subscribe(
      (response) => {
        // Assuming the API sends back a token and username
        const { token, userName } = response;
        this.authService.saveUserData(token, userName);
        this.router.navigate(['/dashboard']);
      },
      (error) => {
        this.errorMessage = 'Invalid login credentials. Please try again.';
      }
    );
  }
}