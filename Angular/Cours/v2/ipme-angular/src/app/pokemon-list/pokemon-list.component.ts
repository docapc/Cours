import { Component, OnInit } from '@angular/core';
import {PokemonService} from "../../service/pokemon.service";
import {IPokemonList} from "../../models/pokemon/i-pokemon-list";
import {IPokemon} from "../../models/pokemon/i-pokemon";

@Component({
  selector: 'app-pokemon-list',
  templateUrl: './pokemon-list.component.html',
  styleUrls: ['./pokemon-list.component.scss']
})
export class PokemonListComponent implements OnInit {

  iPokemonList: IPokemonList|undefined;
  iPokemonArray: IPokemon[] = [];
  offset: number = 0;

  constructor(public pokemonService: PokemonService) { }

  ngOnInit(): void {
    this.callPage(0);
  }

  getImageFromUrl(url: number): string {
    return 'https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/'+url+'.png';
  }

  callPage(number: number) {
    this.offset += number;
    this.iPokemonArray = [];
    this.pokemonService.getPokemonsByOffsetLimit(this.offset)
      // Fonction anonyme en JS / TS
      /* on abonne la iPokemonList à l'observable renvoyé par la requete Get */
      .subscribe((iPokemonList: IPokemonList) => {
        this.iPokemonList = iPokemonList;
        /* puis on rempli la iPokemonArray en abonnant chaque pokemon 
        a l'url contenue dans result du iPokemonList  */
        for(let result of iPokemonList.results) {
          this.pokemonService.getUrlResult(result.url).subscribe((pokemon: IPokemon) => {
            this.iPokemonArray.push(pokemon);
            // sort attend un number pour trier : si négatif alors plus petit devant 
            // , sinon plus grand devant -> a creuser sa c'est vraiment contre intuitif
            /* enfin on trie la liste par ordre croissant au niveau de id dans
            l'interface iPokemon */
            this.iPokemonArray.sort((p1, p2) => p1.id - p2.id);
          });
        }
      });
  }
}
