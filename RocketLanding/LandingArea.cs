namespace RocketLanding
{
    public class LandingArea
    {
        private readonly int _size;
        private readonly LandingPlatform _platform;
        private Position? _lastCheckedPosition;

        public LandingArea(int size, int platformSize, Position platformPosition)
        {
            if (size < 1)
                throw new ArgumentOutOfRangeException(nameof(size));

            if (platformSize < 1)
                throw new ArgumentNullException(nameof(platformSize));

            if (platformSize > size)
                throw new ArgumentOutOfRangeException(nameof(platformSize), "Platform size cannot be greater than landing area");

            if (platformPosition.X + platformSize > size ||
                platformPosition.Y + platformSize > size)
                throw new ArgumentOutOfRangeException(nameof(platformSize), "Platform exceeds the landing area");

            _size = size;
            _platform = new LandingPlatform(platformSize, platformPosition);
        }

        public LandingQueryResult QueryPosition(Position position)
        {
            if (!IsInside(position))
                throw new ArgumentException("Position outside landing area", nameof(position));

            if (!_platform.IsInside(position))
                return LandingQueryResult.OutOfPlatform;

            if (IsClashing(position))
                return LandingQueryResult.Clash;

            _lastCheckedPosition = position;

            return LandingQueryResult.Okay;
        }

        private bool IsInside(Position position)
        {
            if (position.X < 0 ||
                position.Y < 0 ||
                position.X >= _size ||
                position.Y >= _size)
                return false;

            return true;
        }

        private bool IsClashing(Position positionToCheck)
        {
            if (_lastCheckedPosition?.IsAdjacentTo(positionToCheck) ?? false)
                return true;

            return false;
        }
    }
}