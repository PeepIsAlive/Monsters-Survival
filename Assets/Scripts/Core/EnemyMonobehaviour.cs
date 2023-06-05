using Application = MonstersSurvival.Application;
using System.Threading.Tasks;
using Leopotam.Ecs;
using UnityEngine;
using Components;

namespace Core.Monobehaviour
{
    public sealed class EnemyMonobehaviour : MonoBehaviour
    {
        [field: Header("For component")]
        [field: SerializeField] public Transform Transform { get; private set; }
        [field: SerializeField] public SpriteRenderer Renderer { get; private set; }
        public Enemy Enemy { get; private set; }

        [field: Header("Preferences")]
        [field: SerializeField] public EnemyType Type { get; private set; }
        [SerializeField] private LayerMask _damagableLayers;

        public void SetEnemy(Enemy enemy)
        {
            Enemy ??= enemy;
        }
    }
}
