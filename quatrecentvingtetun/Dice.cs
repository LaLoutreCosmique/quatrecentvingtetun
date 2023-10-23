using System;

namespace quatrecentvingtetun
{
    public class Dice
    {
        public Random _rnd = new Random();
        public int NbFaces;
        public int Face { get; private set; }

        public Dice(int nbFaces = 6)
        {
            NbFaces = nbFaces;
        }

        public override string ToString()
        {
            return $"Face courante : {Face}";
        }

        public int Lancer()
        {
            return Face = _rnd.Next(1, NbFaces);
        }
    }
}