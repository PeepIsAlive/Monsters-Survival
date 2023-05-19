using UnityEngine;

namespace MonstersSurvival
{
    public static class Application
    {
        public static Model Model { get; private set; }
        public static RectTransform MainCanvasRect { get; private set; }

        static Application()
        {
            Model = new Model();
            MainCanvasRect = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<RectTransform>();
        }
    }
}
