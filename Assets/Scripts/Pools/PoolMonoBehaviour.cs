using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Pools
{
    public sealed class PoolMonoBehaviour<T> where T : MonoBehaviour
    {
        public IEnumerable<T> PoolObjects => _pool;

        private readonly List<T> _pool;
        private readonly T _prefab;
        private Vector2 _spawnPoint;

        private bool _isAutoExpand;
        private const int DEFAULT_OBJECTS_AMOUNT = 3; // to do: edit this

        public PoolMonoBehaviour(T prefab, Vector2 spawnPoint, bool isAutoExpand = false)
        {
            _pool = new List<T>();

            _prefab = prefab;
            _spawnPoint = spawnPoint;
            _isAutoExpand = isAutoExpand;

            FillPool();
        }

        public bool TryGetObject(out T obj)
        {
            obj = null;

            if (_pool.Any(x => !x.gameObject.activeInHierarchy))
            {
                obj = _pool.First(x => !x.gameObject.activeInHierarchy);

                return true;
            }
            else
            {
                if (_isAutoExpand)
                {
                    obj = CreateObject();
                    AddToPool(obj);

                    return true;
                }
            }

            return false;
        }

        private void FillPool()
        {
            for (var i = 0; i < DEFAULT_OBJECTS_AMOUNT; ++i)
            {
                var obj = CreateObject();
                AddToPool(obj);
            }
        }

        private void AddToPool(T obj)
        {
            obj.gameObject.SetActive(false);
            _pool.Add(obj);
        }

        private T CreateObject()
        {
            _spawnPoint.x += Random.Range(2, 21); // to do remove this
            return Object.Instantiate(_prefab, _spawnPoint, Quaternion.identity);
        }
    }
}
