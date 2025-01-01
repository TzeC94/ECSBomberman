using System.Diagnostics;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

partial struct BombSystem : ISystem
{
    NativeList<Entity> destroyEntity;

    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        destroyEntity = new NativeList<Entity>(Allocator.Persistent);
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        foreach (var (bomb, entity) in SystemAPI.Query<RefRW<BombComponent>>().WithEntityAccess())
        {
            bomb.ValueRW.counter += SystemAPI.Time.DeltaTime;
            if(bomb.ValueRW.counter > bomb.ValueRW.duration)
            {
                destroyEntity.Add(entity);
            }
        }

        if (destroyEntity.Length > 0)
        {
            state.EntityManager.DestroyEntity(destroyEntity.AsArray());
            destroyEntity.Clear();
        }
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
        destroyEntity.Dispose();
    }
}
