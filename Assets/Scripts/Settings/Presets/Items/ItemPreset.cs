using UnityEngine;
using Core;

namespace Settings
{
    [CreateAssetMenu(fileName = "ItemPreset", menuName = "Settings/Presets/ItemPreset", order = 0)]
    public sealed class ItemPreset : Preset
    {
        [field: SerializeField] public ItemType Type { get; private set; }
        [field: SerializeField] public GameObject Prefab { get; private set; }
    }
}
