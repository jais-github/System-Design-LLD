using System;

namespace SnakeLadderLLD
{
    public class Board
    {
        public int Size { get; private set; }
        private Cell[,] cells;
        private Random rand = new Random();

        public Board(int boardSize, int snakeCount, int ladderCount)
        {
            Size = boardSize;
            InitializeCells(boardSize);
            AddSnakesAndLadders(snakeCount, ladderCount);
        }

        private void InitializeCells(int size)
        {
            cells = new Cell[size, size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    cells[i, j] = new Cell();
        }

        private void AddSnakesAndLadders(int snakeCount, int ladderCount)
        {
            int maxPosition = Size * Size;

            while (snakeCount > 0)
            {
                int start = rand.Next(2, maxPosition); // head
                int end = rand.Next(1, start);         // tail

                GetCell(start).Jump = new Jump(start, end);
                snakeCount--;
            }

            while (ladderCount > 0)
            {
                int start = rand.Next(1, maxPosition - 1);
                int end = rand.Next(start + 1, maxPosition);

                GetCell(start).Jump = new Jump(start, end);
                ladderCount--;
            }
        }

        public Cell GetCell(int position)
        {
            int row = (position - 1) / Size;
            int col = (position - 1) % Size;
            return cells[row, col];
        }
    }
}
