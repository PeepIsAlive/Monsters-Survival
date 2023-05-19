using UnityEngine.UI;
using UI.Settings;
using UnityEngine;
using TMPro;

namespace UI.Views
{
    [RequireComponent(typeof(Button))]
    public class ButtonView : MonoBehaviour
    {
        [Header("Base")]
        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _titleLabel;

        private void OnDestroy()
        {
            RemoveAllListeners();
        }

        public virtual void Setup(ButtonSettings settings)
        {
            _button?.onClick.AddListener(() => settings.Action?.Invoke());

            if (_titleLabel != null)
                _titleLabel.text = settings.Title;
        }

        private void RemoveAllListeners()
        {
            _button?.onClick?.RemoveAllListeners();
        }
    }
}
