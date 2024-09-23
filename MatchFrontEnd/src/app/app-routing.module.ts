import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ScoresComponent } from './screens/scores/scores.component';
import { LoginComponent } from './screens/login/login.component';
import { RegisterComponent } from './screens/register/register.component';
import { authGuard } from './guards/auth.guard';
import { EventsComponent } from './screens/events/events.component';
import { MatchesComponent } from './screens/matches/matches.component';
import { DashboardComponent } from './screens/dashboard/dashboard.component';

const routes: Routes = [
  { path: '', redirectTo: '/dashboard', pathMatch: 'full'},
  { path: 'dashboard', component: DashboardComponent ,canActivate: [authGuard]},
  { path: 'scores', component: ScoresComponent ,canActivate: [authGuard]},
  { path: 'matches', component: MatchesComponent ,canActivate: [authGuard]},
  { path: 'events', component: EventsComponent ,canActivate: [authGuard]},
  { path: 'signin', component: LoginComponent },
  { path: 'signup', component: RegisterComponent },
 
  // { path: 'customers', component: CustomersComponent,canActivate: [authGuard], data: { roles: ['manager','executive'] } },
  // { path: 'executives', component: ExecutivesComponent,canActivate: [authGuard], data: { roles: ['manager'] } },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
