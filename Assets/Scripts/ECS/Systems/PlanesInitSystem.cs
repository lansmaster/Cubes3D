using UnityEngine;
using Leopotam.Ecs;
using System.Collections.Generic;

sealed class PlanesInitSystem : IEcsInitSystem
{
    private EcsWorld _world;
    private StaticData _staticData;
    private SceneData _sceneData;

    public void Init()
    {
        foreach (var i in _sceneData.planesGameObjects)
        {
            var planeEntity = i.GetComponent<PlaneView>().planeEntity;

            ref var plane = ref planeEntity.Get<PlaneDataComponent>();
            plane.meshRenderer = i.GetComponent<MeshRenderer>();
            plane.materials = plane.meshRenderer.materials;
            plane.defaultMaterial = plane.materials[0];
            plane.emissionMaterial = plane.materials[1];
        }
    }
}
