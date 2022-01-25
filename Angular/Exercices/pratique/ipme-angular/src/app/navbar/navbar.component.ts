import { Component } from '@angular/core';
import {Router} from "@angular/router";

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent {

  /* en static car commun à tt les instances de la classe.
  Et de plus on n'a pas besoin d'instancier l'objet pour y accéder */
  static pathHeroes : string = 'heroes';
  urlHeroes: string = '/' + NavbarComponent.pathHeroes;

  static pathPokemonList: string = 'pokemons';
  urlPokemonList: string = '/' + NavbarComponent.pathPokemonList;

  static pathFormUser : string = 'form-user';
  urlFormUser: string = '/' + NavbarComponent.pathFormUser;

  static pathFormAccount : string ='form-steam-account'
  urlFormAccount: string = '/' + NavbarComponent.pathFormAccount;
  // private router: Router;
  //
  // constructor(router: Router) {
  //   this.router = router;
  // }
  constructor(private router: Router) { }

  hideButton(url: string): boolean {
    return this.router.url === url;
  }

  sliceUrl(url: string): string {
    return url.slice(1, url.length);
  }

}
