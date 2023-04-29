using Leopotam.Ecs;
using Components;
using UI;

namespace Systems
{
    public sealed class PopupDisplaySystem : IEcsRunSystem
    {
        private readonly EcsFilter<ShowPopupComponent> _showPopupFilter;

        private PopupViewManager _popupViewManager;

        public void Run()
        {
            foreach (var i in _showPopupFilter)
            {

            }
        }
    }
}
