using System;
using System.Collections.Generic;

namespace SnakeLadderLLD
{
    public class Game
    {
        private Board board;
        private Dice dice;
        private Queue<Player> playerList;
        private Player winner;

        public Game()
        {
            InitializeGame();
        }

        private void InitializeGame()
        {
            board = new Board(10, 5, 4); // 10x10 board, 5 snakes, 4 ladders
            dice = new Dice(1);
            playerList = new Queue<Player>();
            winner = null;
            AddPlayers();
        }

        private void AddPlayers()
        {
            Player p1 = new Player("P1", 0);
            Player p2 = new Player("P2", 0);
            playerList.Enqueue(p1);
            playerList.Enqueue(p2);
        }

        public void StartGame()
        {
            int boardLimit = board.Size * board.Size;

            while (winner == null)
            {
                Player currentPlayer = FindPlayerTurn();
                Console.WriteLine($"\nPlayer turn: {currentPlayer.Id}, Current position: {currentPlayer.CurrentPosition}");

                int roll = dice.RollDice();
                Console.WriteLine($"{currentPlayer.Id} rolled: {roll}");

                int newPosition = currentPlayer.CurrentPosition + roll;

                if (newPosition > boardLimit)
                {
                    Console.WriteLine($"{currentPlayer.Id} rolled too high, staying at {currentPlayer.CurrentPosition}");
                }
                else
                {
                    newPosition = JumpCheck(newPosition);
                    currentPlayer.CurrentPosition = newPosition;
                    Console.WriteLine($"{currentPlayer.Id} moved to: {newPosition}");

                    if (newPosition == boardLimit)
                    {
                        winner = currentPlayer;
                        Console.WriteLine($"\n🏆 WINNER IS: {winner.Id}");
                        break;
                    }
                }

                playerList.Enqueue(currentPlayer);
            }
        }

        private Player FindPlayerTurn()
        {
            return playerList.Dequeue();
        }

        private int JumpCheck(int position)
        {
            if (position > board.Size * board.Size)
                return position;

            Cell cell = board.GetCell(position);
            if (cell.Jump != null && cell.Jump.Start == position)
            {
                string type = cell.Jump.Start < cell.Jump.End ? "Ladder" : "Snake";
                Console.WriteLine($"Hit a {type} from {cell.Jump.Start} to {cell.Jump.End}");
                return cell.Jump.End;
            }

            return position;
        }
    }
}
