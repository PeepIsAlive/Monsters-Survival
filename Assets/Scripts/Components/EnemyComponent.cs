using Core.Monobehaviour;
using System;
using Core;

namespace Components
{
    [Serializable]
    public struct EnemyComponent
    {
        public Enemy Enemy;
        public EnemyMonoBehaviour Monobehaviour;
    }
}
