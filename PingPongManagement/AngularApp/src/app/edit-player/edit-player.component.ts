import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http'
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-edit-player',
  templateUrl: './edit-player.component.html',
  styleUrls: ['./edit-player.component.css']
})
export class EditPlayerComponent implements OnInit {
  @Input() id;
  player: any = {};
  skillLevels: any;
  constructor(public activeModal: NgbActiveModal, private http: HttpClient, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.http.get('/api/skillLevel').subscribe(data => {
      this.skillLevels = data;
    });
    this.http.get('/api/player/' + this.id).subscribe(data => {
      this.player = data;
    });
  }

  updatePlayer(id) {
    this.activeModal.close('Submitted');
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
