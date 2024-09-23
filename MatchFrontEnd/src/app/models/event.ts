export interface Event {
    eventID: string;
    matchID: string;
    eventType: string; // e.g., Goal, Foul, Timeout
    description: string;
    timestamp: Date;
  }  