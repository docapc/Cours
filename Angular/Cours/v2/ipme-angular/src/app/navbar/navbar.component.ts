import { Component } from '@angular/core';
import {Router} from "@angular/router";

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent {

  static pathHeroes: string = 'heroes';
  urlHeroes: string = '/' + NavbarComponent.pathHeroes;

  static pathPokemonList: string = 'pokemons';
  urlPokemonList: string = '/' + NavbarComponent.pathPokemonList;

  // private router: Router;
  //
  // constructor(router: Router) {
  //   this.router = router;
  // }
  /* avec le private dans la déclaration du constructeur c'est comme si on déclarait un 
  attribut router de type Router. Injection de dépendance d'un objet de type router
  dans l'objet courant que l'on affecte à l'attribut router avec la visibilité private*/
  constructor(private router: Router) { }

  hideButton(url: string): boolean {
    return this.router.url === url;
  }

  sliceUrl(url: string): string {
    return url.slice(1, url.length);
  }

}
