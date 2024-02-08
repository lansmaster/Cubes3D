using Leopotam.Ecs;
using UnityEngine;

public sealed class EcsStartup : MonoBehaviour
{
    [SerializeField] public StaticData configuration;
    public SceneData sceneData;

    public static EcsWorld world;
    private EcsSystems updateSystems;
    private EcsSystems fixedUpdateSystems;

    private void Awake()
    {
        world = new EcsWorld();
        updateSystems = new EcsSystems(world);
        fixedUpdateSystems = new EcsSystems(world);

        AddSystems();
        AddInjections();
    }

    private void Start()
    {
        updateSystems.Init();
        fixedUpdateSystems.Init();
    }

    private void AddInjections()
    {
        updateSystems.
            Inject(configuration).
            Inject(sceneData);
    }

    private void AddSystems()
    {
        updateSystems.
            Add(new CubeInitSystem()).
            Add(new CoinInitSystem()).
            Add(new PlanesDetectorSystem()).
            Add(new PlaneColorSystem()).
            Add(new CoinSpawnSystem()).
            Add(new CoinsAmountViewInitSystem());

        fixedUpdateSystems.
            Add(new CubeMoveSystem());
    }

    private void Update()
    {
        updateSystems?.Run();
    }

    private void FixedUpdate()
    {
        fixedUpdateSystems?.Run();        
    }

    private void OnDestroy()
    {
        updateSystems?.Destroy();
        updateSystems = null;
        fixedUpdateSystems?.Destroy();
        fixedUpdateSystems = null;
        world?.Destroy();
        world = null; 
    }
}
