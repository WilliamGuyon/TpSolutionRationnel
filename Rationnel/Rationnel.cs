using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rationnel
{
    public readonly struct Rationnel
    {
        private readonly int numerateur;
        private readonly int denominateur;

        public Rationnel(int numerateur, int denominateur)
        {
            if (denominateur == 0)
            {
                throw new ArgumentException("0 impossible au denominateur");
            }

            this.numerateur = numerateur; 
            this.denominateur = denominateur;
        }

        public int Numerateur
        {
            get { return numerateur; }
        }

        public int Denominateur
        {
            get { return denominateur; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (denominateur < 0 )
            {
                sb.Append(-numerateur);
                sb.Append('/');
                sb.Append(-denominateur);
            }
            else
            {
                sb.Append(numerateur);
                sb.Append('/');
                sb.Append(denominateur);
            }
            return sb.ToString();
        }

        public static implicit operator Rationnel(int entier)
        {
            return new Rationnel(entier, 1);
        }

        public static explicit operator double(Rationnel rationnel)
        {
            return (double)rationnel.Numerateur / rationnel.Denominateur;
        }



        public static Rationnel Reduit(Rationnel rationnel)
        {
            int pgcd = MathUtil.PGCD(rationnel.numerateur, rationnel.denominateur);
            return new Rationnel(rationnel.numerateur / pgcd, rationnel.denominateur / pgcd);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Rationnel))
                return false;

            Rationnel other = (Rationnel)obj;
            Rationnel thisReduced = Reduit(this);
            Rationnel otherReduced = Reduit(other);

            return thisReduced.numerateur == otherReduced.numerateur
                && thisReduced.denominateur == otherReduced.denominateur;
        }

        public static bool operator ==(Rationnel rationnel1, Rationnel rationnel2)
        {
            if (ReferenceEquals(rationnel1, rationnel2))
                return true;
            if (ReferenceEquals(rationnel1, null) || ReferenceEquals(rationnel2, null))
                return false;

            return rationnel1.Equals(rationnel2);
        }

        public static bool operator !=(Rationnel rationnel1, Rationnel rationnel2)
        {
            return !(rationnel1 == rationnel2);
        }

        public override int GetHashCode()
        {
            return (int)Math.Pow(numerateur, denominateur);
        }

        public int[] chercheOccurence(Rationnel[] objs)
        {
            List<int> positions = new List<int>();

            for (int i = 0; i < objs.Length; i++)
            {
                if (this.Equals(objs[i]))
                {
                    positions.Add(i);
                }
            }

            return positions.ToArray();
        }

        public delegate void processusRationel(Rationnel r);


        public void processRationnel(processusRationel process, Rationnel[] objs)
        {
            foreach (var r in objs)
            {
                if (this.Equals(r))
                {
                    process(r);
                }
            }
        }
    }
}