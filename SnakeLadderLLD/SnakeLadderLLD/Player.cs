namespace SnakeLadderLLD
{
    public class Player
    {
        public string Id { get; set; }
        public int CurrentPosition { get; set; }

        public Player(string id, int currentPosition)
        {
            Id = id;
            CurrentPosition = currentPosition;
        }
    }
}
