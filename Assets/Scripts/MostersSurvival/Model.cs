using System.Collections.Generic;
using Leopotam.Ecs;

namespace MonstersSurvival
{
    public sealed class Model : IEcsSystem
    {
        private readonly EcsWorld _world;

        public void Send<T>(T component) where T : struct
        {
            _world.NewEntity().Replace(component);
        }

        private static List<EcsEntity> GetEntities<T>(EcsFilter<T> filter) where T : struct
        {
            var entities = new List<EcsEntity>();

            if (filter == null)
                return entities;

            foreach (var i in filter)
            {
                entities.Add(filter.GetEntity(i));
            }

            return entities;
        }
    }
}
