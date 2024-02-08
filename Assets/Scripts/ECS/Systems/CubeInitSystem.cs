using Leopotam.Ecs;
using UnityEngine;

sealed class CubeInitSystem : IEcsInitSystem
{
    private readonly EcsWorld _world = null;
    private readonly StaticData staticData;
    private readonly SceneData sceneData;

    public void Init()
    {
        var cubeEntity = _world.NewEntity();

        ref var cube = ref cubeEntity.Get<CubeDataComponent>();

        GameObject cubeGameObject = Object.Instantiate(staticData.CubeData.cubePrefab, sceneData.cubeSpawnPoint.position, Quaternion.identity);
        cube.transform = cubeGameObject.transform;

        cubeGameObject.GetComponent<CubeView>().entity = cubeEntity;
    }
}