namespace ExempleStrategy
{
    public interface IRouteStrategy // C'est notre interface : que des déclarations pour spécifier un contrat
    {
        public string BuildRoute(string A, string B);
    }
}