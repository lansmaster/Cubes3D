using UnityEngine;
using Leopotam.Ecs;

sealed class PlaneColorSystem : IEcsRunSystem
{
    private readonly EcsFilter<PlaneDataComponent> _filter;

    public void Run()
    {
        foreach (var i in _filter)
        {
            ref var plane = ref _filter.Get1(i);

            plane.meshRenderer.material = plane.emissionMaterial;
        }
    }
}
