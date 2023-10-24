using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace quatrecentvingtetun
{
    public class Game
    {
        readonly int _nbOfRound;
        readonly int _nbOfDice;
        List<Dice> _diceList = new List<Dice>();

        public Game(int nbOfRound = 5, int nbOfDice = 5, int nbOfRiggedDice = 0)
        {
            _nbOfRound = nbOfRound;
            _nbOfDice = nbOfDice + nbOfRiggedDice;

            for (int i = 0; i < nbOfDice; i++)
            {
                _diceList.Add(new Dice());
            }

            for (int i = 0; i < nbOfRiggedDice; i++)
            {
                _diceList.Add(new RiggedDice());
            }

            foreach (Dice dice in _diceList)
            {
                dice.Roll();
            }
        }

        public override string ToString()
        {
            string toString = "";
            
            foreach (Dice dice in _diceList)
            {
                toString += "+---+ ";
            }
            
            toString += "\n";
            
            foreach (Dice dice in _diceList)
            {
                toString += $"| {dice.ToString()} | ";
            }
            
            toString += "\n";
            
            foreach (Dice dice in _diceList)
            {
                toString += "+---+ ";
            }
            
            return toString;
        }

        public int Reroll(int diceIndex)
        {
            return _diceList[diceIndex].Roll();
        }

        public int Score()
        {
            int score = 0;
            foreach (Dice dice in _diceList)
            {
                score += dice.Face;
            }
            
            return score;
        }

        public int Run()
        {
            Console.WriteLine(ToString());
            
            for (int currentRound = 1; currentRound < _nbOfRound; currentRound++)
            {
                bool wrongInput = true;
                
                while (wrongInput)
                {
                    Console.Write($"Tour {currentRound} : Quels sont les dés que vous souhaitez relancer ?\n> ");
                    string stringNumber = Console.ReadLine();
                    foreach (var charNumber in stringNumber)
                    {
                        Int32.TryParse(charNumber.ToString(), out int index);
                        if (index > 0 && index <= _nbOfDice)
                        {
                            Reroll(index-1);
                            wrongInput = false;
                        }
                    }
                    
                    if (wrongInput) Console.WriteLine("Aucun numéro valide détecté !");
                }
                
                Console.WriteLine(ToString());
            }

            return 0;
        }
    }
}