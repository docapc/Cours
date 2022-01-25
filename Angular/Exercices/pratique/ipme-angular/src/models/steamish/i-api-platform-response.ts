/* interface générique d'un body dans l'api */
export interface IApiPlatformResponse<T> {
  /* guillemet pour protéger la variable hydra:member ()
  A cause du ':' au milieu du nom */
  "hydra:member": T[];
}
