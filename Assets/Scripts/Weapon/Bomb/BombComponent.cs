using Unity.Entities;

public struct BombComponent : IComponentData
{
    public float duration;

    public float counter;
}
