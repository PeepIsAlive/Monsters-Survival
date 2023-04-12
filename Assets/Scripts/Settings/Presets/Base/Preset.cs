using Extensions;
using System;
using UnityEngine;

namespace Settings
{
    public class Preset : ScriptableObject
    {
#if UNITY_EDITOR
        [ReadOnly]
#endif
        [SerializeField] private string _id;

        private void OnEnable()
        {
            if (string.IsNullOrEmpty(_id))
                SetNewId();
        }

        [ContextMenu("Reset id")]
        private void SetNewId()
        {
            _id = Guid.NewGuid().ToString();
        }
    }
}
