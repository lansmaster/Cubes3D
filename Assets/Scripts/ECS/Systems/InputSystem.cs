using Leopotam.Ecs;

sealed class InputSystem : IEcsRunSystem
{
    private readonly EcsFilter<InputComponent, IsAccessiblePlane> _inputFilter = null;

    private readonly EcsFilter<CubeDataComponent, IsActiveCube>.Exclude<IsMovingCube> _cubeFilter = null;

    public void Run()
    {
        foreach (var i in _inputFilter)
        {
            ref var planeEntity = ref _inputFilter.GetEntity(i);
            ref var input = ref _inputFilter.Get1(i);

            foreach (var j in _cubeFilter)
            {
                ref var cubeEntity = ref _cubeFilter.GetEntity(j);
                ref var cube = ref _cubeFilter.Get1(j);

                cube.targetPosition = input.inputPosition;

                cubeEntity.Get<IsMovingCube>();
            }

            planeEntity.Del<InputComponent>();
        }
    }
}
