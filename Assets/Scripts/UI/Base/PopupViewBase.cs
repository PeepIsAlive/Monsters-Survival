using Application = MonstersSurvival.Application;
using UnityEngine;
using Components;

namespace UI
{
    public class PopupViewBase : MonoBehaviour
    {
        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            Application.Model.Send(new HidePopupComponent());
        }
    }
}
