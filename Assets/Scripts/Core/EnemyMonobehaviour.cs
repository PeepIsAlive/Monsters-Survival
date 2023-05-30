using UnityEngine;

namespace Core.Monobehaviour
{
    public sealed class EnemyMonobehaviour : MonoBehaviour
    {
        [field: SerializeField] public EnemyType Type { get; private set; }

        [SerializeField] private Enemy _enemy;

        public void SetEnemy(Enemy enemy)
        {
            _enemy ??= enemy;
        }
    }
}
