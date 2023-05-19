#if UNITY_EDITOR
using Leopotam.Ecs;
using UnityEngine;
using Components;
using System;
using UI;

namespace Systems
{
    public sealed class TestSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world;

        public void Run()
        {
            PerformAction(KeyCode.U, KeyCode.I, () =>
            {
                _world.NewEntity().Replace(new ShowPopupComponent
                {
                    PopupToShow = new PopupToShow<DefaultPopup>(new DefaultPopup
                    {
                        HeaderText = "Default popup"
                    })
                });
            });
        }

        private void PerformAction(KeyCode keyPress, KeyCode keyUp, Action action)
        {
            if (!Input.GetKey(keyPress))
                return;

            if (Input.GetKeyUp(keyUp))
                action?.Invoke();
        }
    }
}
#endif
