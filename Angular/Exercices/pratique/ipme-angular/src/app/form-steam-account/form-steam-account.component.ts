import { Component, OnInit } from '@angular/core';
import {AbstractControl, FormControl, FormGroup, Validators} from "@angular/forms";
import {Account} from "../../models/steamish/account";

@Component({
  selector: 'app-form-steam-account',
  templateUrl: './form-steam-account.component.html',
  styleUrls: ['./form-steam-account.component.scss']
})
export class FormSteamAccountComponent implements OnInit {

  constructor() { }
  account = new Account();

  ngOnInit(): void {
/* normalement avec FormGroup et accompagné d'un onSubmit pour gérer le subscribe à la requête post */
    this.account.email = ''
  }

}
