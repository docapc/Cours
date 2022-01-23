import {ITypeSlot} from "./i-type-slot";

export interface IPokemon {
  id: number;
  name: string;
  height: number;
  weight: number;
  order: number;
  types: ITypeSlot[];
  sprites: {
    other: {
      home: {
        front_default: string;
        front_shiny: string;
      }
      /* guillemet pour protéger la variable qui conteitn un tiret (-) */
      'official-artwork': {
        front_default: string;
      }
    }
  }
}
