using Leopotam.Ecs;
using System.Collections.Generic;

namespace MonstersSurvival
{
    public sealed class Model : IEcsSystem
    {
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
