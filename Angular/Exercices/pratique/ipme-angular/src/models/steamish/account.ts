
export class Account {

  private _id!: number; /* pas nécessaire pour un poste dans l'api */
  private _name: string = '';
  private _email : string = '';
  private _nickname : string = '';
  private _libraries: string[] = []; /* initialisation d'une liste vide */
  private _wallet : number = 0;


  get id(): number  { return this._id; }
  set id(value: number) { this._id = value; }

  get name(): string  { return this._name; }
  set name(value: string) { this._name = value; }

  get email(): string  { return this._email; }
  set email(value: string) { this._email = value; }

  get nickname(): string  { return this._nickname; }
  set nickname(value: string) { this._nickname = value; }

  get libraries(): string[]  { return this._libraries; }
  set libraries(value: string[]) { this._libraries = value; }

  get wallet(): number  { return this._wallet; }
  set wallet(value: number) { this._wallet = value; }
}
