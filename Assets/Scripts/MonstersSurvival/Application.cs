using UnityEngine;

namespace MonstersSurvival
{
    public static class Application
    {
        public static Model Model { get; private set; }

        public static RectTransform MainCanvasRect
        {
            get
            {
                if (_mainCanvasRect == null)
                    _mainCanvasRect = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<RectTransform>();

                return _mainCanvasRect;
            }
        }

        private static RectTransform _mainCanvasRect;

        static Application()
        {
            Model = new Model();
        }
    }
}
