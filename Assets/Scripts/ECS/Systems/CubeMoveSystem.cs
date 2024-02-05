using Leopotam.Ecs;
using UnityEngine;

sealed class CubeMoveSystem : IEcsRunSystem
{
    private readonly EcsFilter<InputComponent> _inputFilter = null;
    private readonly EcsFilter<CubeDataComponent> _cubeFilter = null;

    public void Run()
    {
        foreach (var i in _inputFilter)
        {
            ref var entity = ref _inputFilter.GetEntity(i);
            ref var input = ref _inputFilter.Get1(i);

            foreach (var j in _cubeFilter)
            {
                ref var cube = ref _cubeFilter.Get1(i);

                cube.transform.position = new Vector3(input.inputPosition.x, cube.transform.position.y, input.inputPosition.z);
            }

            entity.Del<InputComponent>();
        }
    }
}
