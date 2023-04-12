using UnityEngine;
using Systems;
using Events;

namespace MonstersSurvival
{
    public sealed class Starter : MonoBehaviour
    {
        [SerializeField] private GameProcessingEcs _gameProcessingEcs;

        [Header("Game objects")]
        [SerializeField] private GameObject _ground;
        [SerializeField] private GameObject _character;

        private Transform _parent;

        private void Awake()
        {
            _parent = transform.parent.transform;
        }

        private void Start()
        {
            if (_parent == null)
                return;

            Instantiate(_gameProcessingEcs, _parent).OnSystemsInit += () =>
            {
                EventSystem.Send<CharacterCreationEvent>();
            };

            Instantiate(_ground, Vector3.zero, Quaternion.identity);
            Instantiate(_character, Vector3.zero, Quaternion.identity);

            DestroyStarter();
        }

        private void DestroyStarter()
        {
            Destroy(gameObject);
        }
    }
}
