namespace SnakeLadderLLD
{
    public class Jump
    {
        public int Start { get; set; }
        public int End { get; set; }

        public Jump(int start, int end)
        {
            Start = start;
            End = end;
        }
    }
}
