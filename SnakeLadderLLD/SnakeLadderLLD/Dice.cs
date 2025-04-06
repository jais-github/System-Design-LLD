using System;

namespace SnakeLadderLLD
{
    public class Dice
    {
        private int diceCount;
        private Random rand;

        public Dice(int diceCount)
        {
            this.diceCount = diceCount;
            rand = new Random();
        }

        public int RollDice()
        {
            int total = 0;
            for (int i = 0; i < diceCount; i++)
                total += rand.Next(1, 7);
            return total;
        }
    }
}
