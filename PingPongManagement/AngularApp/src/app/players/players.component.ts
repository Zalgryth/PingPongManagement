import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-players',
  templateUrl: './players.component.html',
  styleUrls: ['./players.component.css']
})
export class PlayersComponent implements OnInit {
  players: any;
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.http.get('/api/player').subscribe(data => {
      this.players = data;
    });
  }

}
