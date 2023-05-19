using UI.Settings;
using UnityEngine;
using TMPro;

namespace UI.Views
{
    public sealed class DefaultPopupView : PopupView<DefaultPopup>
    {
        [Header("Popup data")]
        [SerializeField] private TMP_Text _headerLabel;

        public override void Setup(DefaultPopup settings)
        {
            base.Setup(settings);
            InitializeButtons(settings.ButtonSettings);

            _headerLabel.text = settings.HeaderText;
        }

        public override void Show()
        {
            base.Show();
        }

        public override void Hide()
        {
            base.Hide();
        }
    }
}
