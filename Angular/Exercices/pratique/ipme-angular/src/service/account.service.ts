import { Observable } from 'rxjs';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Account} from "../models/steamish/account";

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  rawUrl: string = 'https://steam-ish.test-02.drosalys.net/api/accounts';
  headers: {headers: HttpHeaders} = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
      Authorization: 'my-auth-token'
    })
  };

  constructor(private httpClient: HttpClient) { }

  getAccountsFromPage(pageId: number): Observable<Account> {
    return this.httpClient.get<Account>(this.rawUrl+"?page="+pageId);
  }

  /* est sensé renvoyé un observable de la requete (pour pouvoir subscribe) */
  postAccount(account: Account): Observable<Account> {
    /*JSON.stringify permet de convertir directement un objet TS en string.
    Cela fonctionnera si l'objet stringifié correspond à ce qui est attendue dans le post */
    /* const body = JSON.stringify(account); */
    const body : string = JSON.stringify({
      "name": account.name,
      "email": account.email,
      "nickname": account.nickname,
      "libraries": [
      ],
      "wallet": account.wallet
    })
    /* + '/accounts', */ /*  a été mis dans l'url */
    return this.httpClient.post<Account>(
      this.rawUrl,
      body,
      this.headers);

    }
}
