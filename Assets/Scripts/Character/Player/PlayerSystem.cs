using System.Numerics;
using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

partial struct PlayerSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        UnityEngine.Vector2 moveVector = InputManager.moveVector.Data;

        foreach(var (moveData, placeBomb, transform) in SystemAPI.Query<RefRO<MovementData>, RefRO<PlaceBombData>, RefRW<LocalTransform>>())
        {
            transform.ValueRW.Position.x += moveVector.x * moveData.ValueRO.moveSpeed * SystemAPI.Time.DeltaTime;
            transform.ValueRW.Position.z += moveVector.y * moveData.ValueRO.moveSpeed * SystemAPI.Time.DeltaTime;

            if (InputManager.attackPressed.Data == true)
            {
                var bombEntity = state.EntityManager.Instantiate(placeBomb.ValueRO.bombPrefab);
                SystemAPI.SetComponent(bombEntity, transform.ValueRW);
            }
        }
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
        
    }
}
