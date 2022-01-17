namespace EventDemo
{
    public class Counter
    {
        public event EventHandler<CounterEventArgs> CounterEvent; // event  -> type Event, EventHandler -> le pointeur sur la méthode
		// Notes : Il est possible également d'utiliser des Actions qui sont des event handler particuliers
		public event Action<int> CounterEvent2;	
			
			
        public int CountNumber { get; set; }

        public void Count()
        {
            while (true)
            {
                CountNumber++; 
                CounterEvent?.Invoke(this, new CounterEventArgs() { CounterNumber = CountNumber});
				CounterEvent2(CounterNumber);
                Thread.Sleep(1000);
            }
        }
    }
}
