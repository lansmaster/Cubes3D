using Leopotam.Ecs;
using UnityEngine;

sealed class CubeMoveSystem : IEcsRunSystem
{
    private readonly EcsFilter<InputComponent, IsAccessiblePlane> _inputFilter = null;
    private readonly EcsFilter<CubeDataComponent, IsActiveCube> _cubeFilter = null;

    public void Run()
    {
        foreach (var i in _inputFilter)
        {
            ref var entity = ref _inputFilter.GetEntity(i);
            ref var input = ref _inputFilter.Get1(i);

            foreach (var j in _cubeFilter)
            {
                ref var cube = ref _cubeFilter.Get1(j);

                cube.transform.position = new Vector3(input.inputPosition.x, cube.transform.position.y, input.inputPosition.z);

                foreach (var plane in cube.accessiblePlanes)
                {
                    if (plane.gameObject.TryGetComponent(out PlaneView planeView))
                    {
                        planeView.entity.Del<IsAccessiblePlane>();
                    }
                }
            }
            
            entity.Del<InputComponent>();
        }
    }
}
