using UnityEngine;
using Leopotam.Ecs;

sealed class CubeInitSystem : IEcsInitSystem
{
    private EcsWorld _world = null;
    private StaticData staticData;
    private SceneData sceneData;

    public void Init()
    {
        var cubeEntity = _world.NewEntity();

        ref var cube = ref cubeEntity.Get<CubeDataComponent>();

        GameObject cubeGameObject = Object.Instantiate(staticData.CubeData.cubePrefab, sceneData.cubeSpawnPoint.position, Quaternion.identity);
        cube.transform = cubeGameObject.transform;
    }
}