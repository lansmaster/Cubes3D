using UnityEngine;
using Leopotam.Ecs;

sealed class CubeInitSystem : IEcsInitSystem
{
    private EcsWorld _world;
    private StaticData staticData;
    private SceneData sceneData;


    public void Init()
    {
        var cubeEntity = _world.NewEntity();

        ref var cube = ref cubeEntity.Get<CubeData>();
        cubeEntity.Get<InputComponent>();

        GameObject cubeGameObject = Object.Instantiate(staticData.cubePrefab, sceneData.transform.position, Quaternion.identity);
        cube.cubeSpeed = staticData.cubeSpeed;
        cube.rigidbody = cubeGameObject.GetComponent<Rigidbody>();
    }
}
