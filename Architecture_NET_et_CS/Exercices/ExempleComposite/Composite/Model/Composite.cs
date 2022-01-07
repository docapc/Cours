namespace Ipme.ExoComposite.Model
{
    public class Composite : IComponent
    {
        public string Name { get; private set; } // fait partie du pattern car dans le contrat IComponent

        protected List<IComponent> _components; // fait partie du pattern :liste de tt les éléments d'un composite

        public Composite(string name)
        {
            Name = name;
            _components = new List<IComponent>();
        }

        public virtual void AddComponent(IComponent component) // ne fait pas partie du pattern
        {
            _components.Add(component);
        }

        public virtual void RemoveComponent(IComponent component) // ne fait pas partie du pattern
        {
            _components.Remove(component);
        }

        public void LoadLeafs(List<IComponent> leafs) // fait partie du pattern car dans le contrat IComponent
        {
            foreach (var component in _components)
            {
                component.LoadLeafs(leafs);
            }
        }

    }
}