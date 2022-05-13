namespace RocketLanding
{
    public class Position
    {
        public Position(int x, int y)
        {
            if (x < 0)
                throw new ArgumentOutOfRangeException("x", "Position X should be greater than 0");

            if (y < 0)
                throw new ArgumentOutOfRangeException("y", "Position Y should be greater than 0");

            X = x;
            Y = y;
        }

        public int X { get; init; }
        public int Y { get; init; }

        public bool IsAdjacentTo(Position position)
        {
            return Math.Abs(X - position.X) <= 1
                && Math.Abs(Y - position.Y) <= 1;
        }
    };
}
