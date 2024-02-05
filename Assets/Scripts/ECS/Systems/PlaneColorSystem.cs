using Leopotam.Ecs;

sealed class PlaneColorSystem : IEcsRunSystem
{
    private readonly EcsFilter<PlaneDataComponent, IsAccessiblePlane> _accessiblePlanesFilter = null;

    private readonly EcsFilter<PlaneDataComponent>.Exclude<IsAccessiblePlane> _otherPlanesFilter = null;

    public void Run()
    {
        foreach (var i in _accessiblePlanesFilter)
        {
            ref var plane = ref _accessiblePlanesFilter.Get1(i);

            plane.meshRenderer.material = plane.emissionMaterial;
        }

        foreach (var i in _otherPlanesFilter)
        {
            ref var plane = ref _otherPlanesFilter.Get1(i);

            plane.meshRenderer.material = plane.defaultMaterial;
        }
    }
}
