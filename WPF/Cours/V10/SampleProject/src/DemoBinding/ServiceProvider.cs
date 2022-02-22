using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBinding
{
    public class ServiceProvider : IServiceProvider
    {
        private Dictionary<Type, object> Services { get; set; } = new Dictionary<Type, object>();
        public void RegisterService<T>(T impl) where T : class
        {
            Services.Add(typeof(T), impl);
        }

        public T GetService<T>() where T : class
        {
            return Services.GetValueOrDefault(typeof(T)) as T; 
        }
    }
}
