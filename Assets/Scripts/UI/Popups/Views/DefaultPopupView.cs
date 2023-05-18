using UnityEngine.UI;
using UnityEngine;

namespace UI.Views
{
    public sealed class DefaultPopupView : PopupView<DefaultPopup>
    {
        [SerializeField] private Button _overlayButton;

        public override void Setup(DefaultPopup settings)
        {
            base.Setup(settings);
        }

        public override void Show()
        {
            base.Show();
        }

        public override void Hide()
        {
            base.Hide();
        }

        private void SetOverlayButtonState(bool state)
        {
            _overlayButton?.gameObject.SetActive(state);
        }

    }
}
