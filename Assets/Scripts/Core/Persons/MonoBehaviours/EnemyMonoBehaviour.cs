using UnityEngine;

namespace Core.Monobehaviour
{
    public sealed class EnemyMonoBehaviour : MonoBehaviour
    {
        [field: Header("For component")]
        [field: SerializeField] public Transform Transform { get; private set; }
        [field: SerializeField] public SpriteRenderer Renderer { get; private set; }

        [field: Header("Preferences")]
        [field: SerializeField] public EnemyType Type { get; private set; }
    }
}
