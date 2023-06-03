namespace Core
{
    public readonly struct PathNode
    {
        public readonly Vector2 Position;
        public readonly double EstimatedCost;
        public readonly double TraverseDistance;

        public PathNode(Vector2 position, Vector2 target, double traverseDistance)
        {
            Position = position;
            TraverseDistance = traverseDistance;
            EstimatedCost = (position - target).DistanceEstimate();
        }
    }
}
