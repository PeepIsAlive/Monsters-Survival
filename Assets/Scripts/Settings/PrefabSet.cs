using System.Collections.Generic;
using UnityEngine;
using UI;

namespace Settings
{
    [CreateAssetMenu(fileName = "PrefabSet", menuName = "Settings/PrefabSet", order = 52)]
    public sealed class PrefabSet : ScriptableObject
    {
        [field: SerializeField] public List<PopupViewBase> Popups { get; private set; }
    }
}
