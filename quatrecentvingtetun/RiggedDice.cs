using System;

namespace quatrecentvingtetun
{
    public class RiggedDice : Dice
    {
        Random rnd = new Random();
        
        public override int Roll()
        {
            int percentThrow = rnd.Next(100);
            
            if (percentThrow < 50)
                Face = 6;
            else if (percentThrow < 67)
                Face = 5;
            else
                Face = rnd.Next(1, 5);

            return Face;
        }
    }
}