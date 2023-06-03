using System;
using Core;

namespace Extentions
{
    internal static class NodeExtentions
    {
        private static readonly (Vector2 position, double cost)[] _neighboursTemplates =
        {
            (new Vector2(1, 0), 1),
            (new Vector2(0, 1), 1),
            (new Vector2(-1, 0), 1),
            (new Vector2(0, -1), 1),
            (new Vector2(1, 1), Math.Sqrt(2)),
            (new Vector2(1, -1), Math.Sqrt(2)),
            (new Vector2(-1, 1), Math.Sqrt(2)),
            (new Vector2(-1, -1), Math.Sqrt(2))
        };


        public static void Fill(this PathNode[] neighbours, PathNode pathNode, Vector2 targetPosition)
        {
            int i = -1;

            foreach ((Vector2 position, double cost) in _neighboursTemplates)
            {
                Vector2 nodePosition = position + pathNode.Position;
                double traverseDistance = pathNode.TraverseDistance + cost;

                neighbours[++i] = new PathNode(nodePosition, targetPosition, traverseDistance);
            }
        }
    }
}
