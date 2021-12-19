using System;

namespace ExempleStrategy
{
    class Program
    {
        static void Main(string[] args)
        {
            var navigator = new Navigator();
            navigator.SetStrategy(new WalkingStrategy());
            var my_way1 = navigator.BuildRoute("A", "B");
            Console.WriteLine(my_way1);

            navigator.SetStrategy(new RoadStrategy());
            var my_way2 = navigator.BuildRoute("C", "D");
            Console.WriteLine(my_way2);
        }
    }
}

