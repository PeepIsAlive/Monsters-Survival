namespace UI
{
    public sealed class PopupToShow<T> : PopupToShow where T : Popup
    {
        private readonly T _settings;

        public PopupToShow(T settings)
        {
            _settings = settings;
        }

        public override void Show(PopupViewManager popupViewManager)
        {
            popupViewManager.Show(_settings);
        }
    }

    public abstract class PopupToShow
    {
        public abstract void Show(PopupViewManager popupViewManager);
    }
}
