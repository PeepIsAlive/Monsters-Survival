using Application = MonstersSurvival.Application;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;

namespace UI
{
    public class PopupViewBase : MonoBehaviour
    {
        [Header("Base")]
        [SerializeField] private RectTransform _rootRect;
        [SerializeField] private Button _overlayButton;

        private readonly float _durationTween = 0.4f;

        public virtual void Show()
        {
            gameObject.SetActive(true);

            AddListeners();
            DoShow();
        }

        public virtual void Hide()
        {
            RemoveListeners();
            DoHide();
        }

        private void DoShow()
        {
            _rootRect ??= gameObject.GetComponent<RectTransform>();

            var startOffset = Vector3.down.normalized * Application.MainCanvasRect.sizeDelta.y;
            var targetPosition = _rootRect.localPosition;

            if (Mathf.Abs(startOffset.sqrMagnitude) - Mathf.Abs(Vector2.zero.sqrMagnitude) > Mathf.Epsilon)
            {
                _rootRect.localPosition += startOffset;
                _rootRect.DOAnchorPos(targetPosition, _durationTween)
                    .SetEase(Ease.OutBack)
                    .OnComplete(() => _overlayButton.gameObject.SetActive(true));
            }
        }

        private void DoHide()
        {
            var targetPosition = Vector3.down.normalized * Application.MainCanvasRect.sizeDelta.y;

            if (Mathf.Abs(targetPosition.sqrMagnitude) - Mathf.Abs(Vector2.zero.sqrMagnitude) > Mathf.Epsilon)
            {
                _overlayButton.gameObject.SetActive(false);
                _rootRect.DOAnchorPos(targetPosition, _durationTween)
                    .SetEase(Ease.InBack)
                    .OnComplete(() => Destroy(gameObject));
            }
        }

        private void AddListeners()
        {
            _overlayButton?.onClick.AddListener(Hide);
        }

        private void RemoveListeners()
        {
            _overlayButton?.onClick?.RemoveListener(Hide);
        }
    }
}
