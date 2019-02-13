import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { PlayersComponent } from './players/players.component';
import { AddPlayerComponent } from './add-player/add-player.component';

const routes: Routes = [
  {
    path: '',
    component: PlayersComponent,
    data: { title: 'Players' }
  },
  {
    path: 'players',
    component: PlayersComponent,
    data: { title: 'Players' }
  },
  {
    path: 'players/create',
    component: AddPlayerComponent,
    data: { title: 'Add Player' }
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
