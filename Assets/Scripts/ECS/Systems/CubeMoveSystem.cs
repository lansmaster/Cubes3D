using Leopotam.Ecs;
using UnityEngine;

sealed class CubeMoveSystem : IEcsRunSystem
{
    private readonly EcsFilter<CubeDataComponent, IsActiveCube, IsMovingCube> _cubeFilter = null;

    public void Run()
    {
        foreach (var i in _cubeFilter)
        {
            ref var cubeEntity = ref _cubeFilter.GetEntity(i);
            ref var cube = ref _cubeFilter.Get1(i);

            var targetPosition = new Vector3(cube.targetPosition.x, cube.transform.position.y, cube.targetPosition.z);
            cube.transform.position = Vector3.MoveTowards(cube.transform.position, targetPosition, Time.deltaTime);
                
            foreach (var plane in cube.accessiblePlanes)
            {
                if (plane.gameObject.TryGetComponent(out PlaneView planeView))
                {
                    planeView.entity.Del<IsAccessiblePlane>();
                }
            }

            if (cube.transform.position != targetPosition)
                return;

            cubeEntity.Del<IsMovingCube>();
        }
    }
}
