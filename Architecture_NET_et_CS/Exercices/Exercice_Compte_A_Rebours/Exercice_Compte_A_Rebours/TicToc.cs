namespace Exercice_Compte_A_Rebours
{
    internal class TicToc
    {
        public TicToc()
        {
        }

        public void DecompteAToB(int a, int b)
        {
            if (a > b)
            {
                Swap(ref a, ref b); // ref en arguement est obligatoire si les arguments ont été déclarés en ref
                //Swap(a, b);
            }
            for (int i = a; i<=b; i++)
            {
                System.Console.WriteLine(i);
            }
        }

        private void Swap(ref int a,ref int b)
        {
            int tt = a;
            a = b;
            b = tt;
        }

    }
}