using UnityEngine.UI;
using UnityEngine;
using Extentions;
using Systems;
using Events;
using Core;

namespace UI
{
    [RequireComponent(typeof(Image))]
    public sealed class HealthBarView : MonoBehaviour
    {
        [Header("Main")]
        [SerializeField] private Image _fillImage;

        private void Start ()
        {
            EventSystem.Subscribe<CharacterParameterValueChangedEvent>(OnParameterValueChanged);
        }

        private void OnDestroy()
        {
            EventSystem.Unsubscribe<CharacterParameterValueChangedEvent>(OnParameterValueChanged);
        }

        private void OnParameterValueChanged(CharacterParameterValueChangedEvent e)
        {
            if (e.ParameterType != ParameterType.Health || _fillImage == null)
                return;

            _fillImage.fillAmount = (1f - e.Value.NormalizeValue());
        }
    }
}
