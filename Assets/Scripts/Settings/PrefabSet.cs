using System.Collections.Generic;
using Core.Monobehaviour;
using UnityEngine;
using UI.Views;
using UI;

namespace Settings
{
    [CreateAssetMenu(fileName = "PrefabSet", menuName = "Settings/PrefabSet", order = 52)]
    public sealed class PrefabSet : ScriptableObject
    {
        [field: SerializeField] public List<EnemyMonobehaviour> EnemiesPrefabs { get; private set; }
        [field: SerializeField] public List<PopupViewBase> Popups { get; private set; }
        [field: SerializeField] public List<ButtonView> Buttons { get; private set; }
    }
}
