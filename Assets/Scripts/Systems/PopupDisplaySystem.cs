using Leopotam.Ecs;
using Components;
using UI;

namespace Systems
{
    public sealed class PopupDisplaySystem : IEcsRunSystem
    {
        private readonly EcsFilter<ShowPopupComponent> _showPopupFilter;
        private readonly EcsFilter<HidePopupComponent> _hidePopupFilter;

        private PopupViewManager _popupViewManager;

        public void Run()
        {
            foreach (var i in _showPopupFilter)
            {

            }

            foreach (var i in _hidePopupFilter)
            {
                _popupViewManager.HideCurrentPopup();
                _hidePopupFilter.GetEntity(i).Destroy();
            }
        }
    }
}
