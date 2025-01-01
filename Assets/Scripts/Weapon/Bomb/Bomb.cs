using Unity.Entities;
using UnityEngine;

class Bomb : MonoBehaviour
{
    public float duration = 3.0f;
}

class BombBaker : Baker<Bomb>
{
    public override void Bake(Bomb authoring)
    {
        //None because bomb doesn't move
        var entity = GetEntity(TransformUsageFlags.Dynamic);

        AddComponent(entity, new BombComponent { duration = authoring.duration });
    }
}
