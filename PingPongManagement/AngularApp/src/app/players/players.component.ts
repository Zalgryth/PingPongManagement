import { Component, OnInit, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { EditPlayerComponent } from '../edit-player/edit-player.component';

@Component({
  selector: 'app-players',
  templateUrl: './players.component.html',
  styleUrls: ['./players.component.css']
})
export class PlayersComponent implements OnInit {
  players: any;
  playerToDelete: any;
  page: number = 1;
  constructor(private http: HttpClient, private modalService: NgbModal) { }

  ngOnInit() {
    this.http.get('/api/player').subscribe(data => {
      this.players = data;
    });
  }

  setPlayerToDelete(id) {
    this.playerToDelete = id;
  }

  openEditModal(id: number) {
    const modalRef = this.modalService.open(EditPlayerComponent);
    modalRef.componentInstance.id = id;

    modalRef.result.then((result) => {
      if (result === 'Submitted') {
        this.http.get('/api/player').subscribe(data => {
          this.players = data;
        });
      }
    });
  }

  deletePlayer() {
    this.http.delete('/api/player/' + this.playerToDelete)
      .subscribe(res => {
        this.http.get('/api/player').subscribe(data => {
          this.players = data;
        });
      }, (err) => {
        console.log(err);
      }
      );
  }
}
