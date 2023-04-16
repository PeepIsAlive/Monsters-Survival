using UnityEngine;
using Extensions;
using System;

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

        protected virtual void RegenerateParameters() { }

        [ContextMenu("Regenerate parameters")]
        private void SetNewParameters()
        {
            RegenerateParameters();
        }

        [ContextMenu("Reset id")]
        private void SetNewId()
        {
            _id = Guid.NewGuid().ToString();
        }
    }
}
