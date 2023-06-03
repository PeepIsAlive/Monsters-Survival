using System.Collections.Generic;
using System.Linq;
using Extentions;
using Core;

namespace AI
{
    public sealed class Path
    {
        private const int MAX_NEIGHBOURS = 8;

        private readonly PathNode[] _neighbours;
        private readonly List<PathNode> _frontiers;
        private readonly HashSet<Vector2> _ignoredPositions;
        private readonly Dictionary<Vector2, Vector2> _links;

        public Path()
        {
            _links = new Dictionary<Vector2, Vector2>();
            _neighbours = new PathNode[MAX_NEIGHBOURS];
            _frontiers = new List<PathNode>();
            _ignoredPositions = new HashSet<Vector2>();
        }

        public bool Calculate(Vector2 startPosition, Vector2 targetPosition, out List<Vector2> path)
        {
            if (!TryGetGenerateNodes(startPosition, targetPosition))
            {
                path = null;
                return false;
            }

            path = new List<Vector2>();

            while (_links.TryGetValue(targetPosition, out targetPosition))
            {
                path.Add(targetPosition);
            }

            return true;
        }

        private bool TryGetGenerateNodes(Vector2 startPosition, Vector2 targetPosition)
        {
            _links.Clear();
            _frontiers.Clear();
            _ignoredPositions.Clear();

            _frontiers.Add(new PathNode(startPosition, targetPosition, 0));

            while (_frontiers.Any())
            {
                double lowest = _frontiers.Min(x => x.EstimatedCost);
                PathNode current = _frontiers.First(x => x.EstimatedCost == lowest);

                _ignoredPositions.Add(current.Position);

                if (current.Position.Equals(targetPosition))
                    return true;

                GenerateFrontiersNodes(current, targetPosition);
            }

            return false;
        }

        private void GenerateFrontiersNodes(PathNode pathNode, Vector2 targetPosition)
        {
            _neighbours.Fill(pathNode, targetPosition);

            foreach (PathNode node in _neighbours)
            {
                if (_ignoredPositions.Contains(node.Position))
                    continue;

                if (!_frontiers.Any(x => x.Position == node.Position))
                {
                    _frontiers.Add(node);
                    _links[node.Position] = pathNode.Position;
                }
                else if (node.EstimatedCost < _frontiers.Find(x => x.Position == node.Position).EstimatedCost)
                {
                    _frontiers[_frontiers.IndexOf(_frontiers.First(x => x.Position == node.Position))] = node;
                    _links[node.Position] = pathNode.Position;
                }
            }
        }
    }
}
