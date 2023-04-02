using UnityEngine;

namespace MonstersSurvival
{
    public sealed class Starter : MonoBehaviour
    {
        [SerializeField] private GameProcessingEcs _gameProcessingEcs;

        [Header("Game objects")]
        [SerializeField] private GameObject _ground;

        private Transform _parent;

        private void Awake()
        {
            _parent = transform.parent.transform;
        }

        private void Start()
        {
            if (_parent == null)
                return;

            Instantiate(_gameProcessingEcs, _parent);
            Instantiate(_ground, Vector3.zero, Quaternion.identity);

            DestroyStarter();
        }

        private void DestroyStarter()
        {
            Destroy(gameObject);
        }
    }
}
