export interface Match {
    matchID: string; // MongoDB ObjectId
    team1: string;
    team2: string;
    sport: string;
    startTime: Date;
    status: string; // e.g., Scheduled, In Progress, Finished
  }  