using System;
using Rationnel;

namespace TestRationnel
{
    class Program
    {
        static void Main()
        {
            try
            {
                Rationnel.Rationnel r1 = new Rationnel.Rationnel(1, 2);
                Rationnel.Rationnel r2 = new Rationnel.Rationnel(3, -4);
                int entier = 4;
                Rationnel.Rationnel r3 = entier;

                Console.WriteLine("Rationnel 1 =" + r1.ToString());
                Console.WriteLine("Rationnel 2 =" + r2.ToString());

                Console.WriteLine("numerateur rationnel1 =" + r1.Numerateur);
                Console.WriteLine("denominateur rationnel1 =" + r1.Denominateur);
                Console.WriteLine("numerateur rationnel2 =" + r2.Numerateur);
                Console.WriteLine("denominateur rationnel2 =" + r2.Denominateur);

                Console.WriteLine("Rationnel 1 conv en double :" + ((double)r1));
                Console.WriteLine("Int en rationnel : " + r3);

                Console.WriteLine("Rationnel r1 réduit : " + Rationnel.Rationnel.Reduit(r1).ToString());
                Console.WriteLine("Rationnel r2 réduit : " + Rationnel.Rationnel.Reduit(r2).ToString());


                Console.WriteLine("r1 == r2 : " + (r1 == r2));
                Console.WriteLine("r1 != r2 : " + (r1 != r2));

                Console.WriteLine("HashCode de r1 : " + r1.GetHashCode());
                Console.WriteLine("HashCode de r2 : " + r2.GetHashCode());

                Rationnel.Rationnel[] tableauRationnels = new Rationnel.Rationnel[]
                {
                    new Rationnel.Rationnel(1, 2),
                    new Rationnel.Rationnel(3, 4),
                    new Rationnel.Rationnel(2, 4),
                    new Rationnel.Rationnel(5, 6),
                    new Rationnel.Rationnel(15, 30)
                };

                Rationnel.Rationnel rationnelRecherche = new Rationnel.Rationnel(1, 2);

                int[] positions = rationnelRecherche.chercheOccurence(tableauRationnels);

                Console.WriteLine("Positions des objets Rationnel égaux à l'objet courant :");
                foreach (int position in positions)
                {
                    Console.WriteLine(position);
                }

                Console.WriteLine("");
                r1.processRationnel(egalite, tableauRationnels);

            }
            catch(ArgumentException)
            {
                Console.WriteLine("0 impossible au dénominateur"); 
            }

            void egalite(Rationnel.Rationnel r)
            {
                Console.WriteLine("Le rationnel est identique a: " + r.ToString());
            }
        }

    }
}
