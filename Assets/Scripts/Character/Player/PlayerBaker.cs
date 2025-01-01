using Unity.Entities;
using UnityEngine;

class PlayerBaker : MonoBehaviour
{
    public float moveSpeed = 2f;
    public GameObject bombPrefab;
}

class PlayerBakerBaker : Baker<PlayerBaker>
{
    public override void Bake(PlayerBaker authoring)
    {
        var entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(entity, new MovementData { moveSpeed = authoring.moveSpeed });
        AddComponent(entity, new PlaceBombData { bombPrefab = GetEntity(authoring.bombPrefab, TransformUsageFlags.Dynamic) });
    }
}