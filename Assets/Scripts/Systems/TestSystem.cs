#if UNITY_EDITOR
using Application = MonstersSurvival.Application;
using System.Collections.Generic;
using Leopotam.Ecs;
using UI.Settings;
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
                        HeaderText = "Default popup",
                        ButtonSettings = new List<ButtonSettings>
                        {
                            new DefaultButtonSettings
                            {
                                Title = "button 1",
                                Action = () =>
                                {
                                    _world.NewEntity().Replace(new HidePopupComponent());
                                }
                            },
                            new DefaultButtonSettings
                            {
                                Title = "button 2",
                                Action = () =>
                                {
                                    _world.NewEntity().Replace(new HidePopupComponent());
                                }
                            }
                        }
                    })
                });
            });

            PerformAction(KeyCode.H, KeyCode.K, () =>
            {
                Application.Model.GetCharacterEntity().Replace(new HealthDecComponent
                {
                    Value = 50f
                });
            });

            PerformAction(KeyCode.H, KeyCode.L, () =>
            {
                Application.Model.GetCharacterEntity().Replace(new HealthIncComponent
                {
                    Value = 15f
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
