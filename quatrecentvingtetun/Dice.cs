using System;

namespace quatrecentvingtetun
{
    public class Dice
    {
        Random _rnd = new Random();
        int _nbFaces;
        public int Face;

        public Dice(int nbFaces = 6)
        {
            _nbFaces = nbFaces;
        }

        public override string ToString()
        {
            return Face.ToString();
        }

        public virtual int Roll()
        {
            return Face = _rnd.Next(1, _nbFaces+1);
        }
    }
}