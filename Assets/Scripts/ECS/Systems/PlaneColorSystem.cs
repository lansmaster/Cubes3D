using Leopotam.Ecs;

sealed class PlaneColorSystem : IEcsRunSystem
{
    private readonly EcsFilter<PlaneDataComponent, IsAccessiblePlane> _accessiblePlanesFilter;

    private readonly EcsFilter<PlaneDataComponent>.Exclude<IsAccessiblePlane> _otherPlanesFilter;

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
