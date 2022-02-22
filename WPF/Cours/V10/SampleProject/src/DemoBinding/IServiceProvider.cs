using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBinding
{
    public  interface IServiceProvider
    {
        void RegisterService<T>(T impl) where T : class;

        T GetService<T>() where T : class; 
    }
}
