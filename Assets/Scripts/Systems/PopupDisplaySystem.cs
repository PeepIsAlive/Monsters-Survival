using Leopotam.Ecs;
using Components;
using UI;

namespace Systems
{
    public sealed class PopupDisplaySystem : IEcsRunSystem
    {
        private EcsFilter<ShowPopupComponent> _showPopupFilter;
        private EcsFilter<HidePopupComponent> _hidePopupFilter;

        private readonly PopupViewManager _popupViewManager;

        public void Run()
        {
            foreach (var i in _showPopupFilter)
            {
                var entity = _showPopupFilter.GetEntity(i);
                var component = _showPopupFilter.Get1(i);

                component.PopupToShow.Show(_popupViewManager);
                entity.Destroy();
            }

            foreach (var i in _hidePopupFilter)
            {
                _popupViewManager.HideCurrentPopup();
                _hidePopupFilter.GetEntity(i).Destroy();
            }
        }
    }
}
