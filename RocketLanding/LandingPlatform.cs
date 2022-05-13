namespace RocketLanding
{
    internal class LandingPlatform
    {
        public LandingPlatform(int size, Position startingPoint)
        {
            if (size < 1)
                throw new ArgumentOutOfRangeException(nameof(size));

            Size = size;
            StartingPoint = startingPoint;
        }

        public int Size { get; set; }
        public Position StartingPoint { get; set; }

        public bool IsInside(Position position)
        {
            if (position.X < StartingPoint.X ||
                position.Y < StartingPoint.Y ||
                position.X >= StartingPoint.X + Size ||
                position.Y >= StartingPoint.Y + Size)
                return false;

            return true;
        }
    }
}
