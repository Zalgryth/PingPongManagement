import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http'

@Component({
  selector: 'app-edit-player',
  templateUrl: './edit-player.component.html',
  styleUrls: ['./edit-player.component.css']
})
export class EditPlayerComponent implements OnInit {
  player: any = {};
  skillLevels: any;
  constructor(private http: HttpClient, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    let id = this.route.snapshot.params['id'];
    this.http.get('/api/skillLevel').subscribe(data => {
      this.skillLevels = data;
    });
    this.http.get('/api/player/' + id).subscribe(data => {
      this.player = data;
    });
  }

  updatePlayer(id) {
    this.http.put('/api/player/' + id, this.player)
      .subscribe(res => {
        //let id = res['Id'];
        //this.router.navigate(['/details', id]);
        this.router.navigate(['/players']);
      }, (err) => {
        console.log(err);
      }
      );
  }
}
