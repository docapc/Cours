namespace Ipme.ExoComposite.Model
{
    public class Composite : IComponent
    {
        public string Name { get; private set; }

        protected List<IComponent> _components;
        
        public Composite(string name)
        {
            Name = name;
            _components = new List<IComponent>();
        }

        public virtual void AddComponent(IComponent component)
        {
            _components.Add(component);
        }

        public virtual void RemoveComponent(IComponent component)
        {
            _components.Remove(component);
        }

        public void LoadLeafs(List<IComponent> leafs)
        {
            foreach (var component in _components)
            {
                component.LoadLeafs(leafs);
            }
        }

        //public virtual IEnumerable<IComponent> GetComponents() // retourner un enumerable ne peut pas fonctionner correction en récursif!
        //{
        //    foreach (var component in _components)
        //        if (component is Leaf)
        //            yield return component;
        //        else
        //        {
        //            component.GetComponents();
        //        }
        //}

        //public virtual IEnumerable<string> GetAllNames()
        //{
        //    foreach (var component in _components)
        //        if (component is Leaf)
        //            yield return component.Name;
        //        else
        //        {
        //            component.GetAllNames();
        //        }
        //}

        //public virtual string GetAllNames()
        //{
        //    foreach (var component in _components)
        //        if (component is Leaf)
        //            yield return component.Name;
        //        else
        //        {
        //            component.GetAllNames();
        //        }
        //}

    }
}