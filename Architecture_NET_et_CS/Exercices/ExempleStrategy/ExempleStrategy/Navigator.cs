namespace ExempleStrategy
{
    public class Navigator // c'est notre Context
    {
        private IRouteStrategy _routeStrategy; //
        // Constructeur non obligatoire (C# en provide 1 par défaut comme en c++)
        public Navigator()
        {
        }

        public string BuildRoute(string A, string B)
        {
            return _routeStrategy.BuildRoute(A, B);
        }

        public void SetStrategy(IRouteStrategy strategy)
        {
            _routeStrategy = strategy;
        }
    }
}