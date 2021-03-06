import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {IPokemon} from "../../models/pokemon/i-pokemon";
import {PokemonService} from "../../service/pokemon.service";

@Component({
  selector: 'app-pokemon-detail',
  templateUrl: './pokemon-detail.component.html',
  styleUrls: ['./pokemon-detail.component.scss']
})
export class PokemonDetailComponent implements OnInit {

  /* déclaration d'attribut de type IPokemon ou Undefined */
  iPokemon: IPokemon|undefined;

  // ActivatedRoute => récupère les paramètres de la route
  constructor(private activatedRoute: ActivatedRoute, public pokemonService: PokemonService) { }

  ngOnInit(): void {
    /* activatedRoute.param est le paramètre donné dans approuting après le : (:namePkmon).
    On s'en sert pour faire une requête par nom sur le pokemon correspondant et on abonne notre iPokemon
    à celui renvoyé par cette requête (en plus d'abonner le params au nom). */
    this.activatedRoute.params.subscribe((param) => {
      // ici param n'autocomplete pas le nom des paramètres de votre route !!!!!
      // Il faut "simplement" reprendre le nom que l'on a définit dans le app-routing.module
      this.pokemonService.getPokemonByName(param.namePkmn).subscribe((iPokemon: IPokemon) => {
        this.iPokemon = iPokemon;
      });
    });
  }

}
