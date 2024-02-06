using Leopotam.Ecs;
using UnityEngine;

sealed class PlanesDetectorSystem : IEcsRunSystem
{
    private readonly EcsFilter<CubeDataComponent, IsActiveCube> _activeCubeFilter = null;
    private readonly EcsFilter<CubeDataComponent>.Exclude<IsActiveCube> _notActiveCubeFilter = null;

    public void Run()
    {
        foreach (var i in _activeCubeFilter)
        {
            ref var cube = ref _activeCubeFilter.Get1(i);

            cube.accessiblePlanes = Physics.OverlapBox(cube.transform.position, cube.transform.localScale);

            foreach (var plane in cube.accessiblePlanes)
            {
                if (plane.gameObject.TryGetComponent(out PlaneView planeView))
                {
                    planeView.entity.Get<IsAccessiblePlane>();
                }
            }
        }

        foreach (var i in _notActiveCubeFilter)
        {
            ref var cube = ref _notActiveCubeFilter.Get1(i);

            cube.accessiblePlanes = Physics.OverlapBox(cube.transform.position, cube.transform.localScale);

            foreach (var plane in cube.accessiblePlanes)
            {
                if (plane.gameObject.TryGetComponent(out PlaneView planeView))
                {
                    planeView.entity.Del<IsAccessiblePlane>();
                }
            }
        }

    }
}
