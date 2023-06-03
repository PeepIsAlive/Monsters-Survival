using UnityEngine;

namespace Core.Monobehaviour
{
    public sealed class EnemyMonobehaviour : MonoBehaviour
    {
        [field: SerializeField] public EnemyType Type { get; private set; }
        [field: SerializeField] public Transform Transform { get; private set; }
        [field: SerializeField] public SpriteRenderer Renderer { get; private set; }
        public Enemy Enemy { get; private set; }

        public void SetEnemy(Enemy enemy)
        {
            Enemy ??= enemy;
        }
    }
}
