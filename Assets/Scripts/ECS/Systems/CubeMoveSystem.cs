using Leopotam.Ecs;
using UnityEngine;

sealed class CubeMoveSystem : IEcsRunSystem
{
    private readonly EcsFilter<CubeDataComponent, InputComponent> _filter;

    public void Run()
    {
        foreach (var i in _filter)
        {
            ref var cube = ref _filter.Get1(i);
            ref var input = ref _filter.Get2(i);

            Vector3 direction = (Vector3.forward * input.direction.z + Vector3.right * input.direction.x).normalized;
            cube.rigidbody.velocity = direction * cube.cubeSpeed;
        }
    }
}