import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http'

@Component({
  selector: 'app-add-player',
  templateUrl: './add-player.component.html',
  styleUrls: ['./add-player.component.css']
})
export class AddPlayerComponent implements OnInit {
  player: any = {};
  skillLevels: any;
  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit() {
    this.http.get('/api/skillLevel').subscribe(data => {
      this.skillLevels = data;
    });
  }

  createPlayer() {
    this.http.post('/api/player', this.player)
      .subscribe(res => {
        //let id = res['Id'];
        //this.router.navigate(['/details', id]);
        this.router.navigate(['/players']);
      }, (err) => {
        console.log(err);
      });
  }
}
