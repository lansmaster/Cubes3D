using Leopotam.Ecs;
using UnityEngine;

sealed class CoinInitSystem : IEcsInitSystem
{
    private readonly EcsWorld _world = null;
    private readonly StaticData _staticData;

    public void Init()
    {
        var coinEntity = _world.NewEntity();

        ref var coin = ref coinEntity.Get<CoinDataComponent>();

        var gameObject = Object.Instantiate(_staticData.CoinData.coinPrefab, RandomPosition(), Quaternion.identity);
        gameObject.GetComponent<CoinView>().entity = coinEntity;

        coin.coinGameObject = gameObject;

        coinEntity.Get<IsActiveCoin>();
    }

    private Vector3 RandomPosition()
    {
        var XAxis = Random.Range((int) -3, (int) 12);
        var YAxis = -0.5f;
        var ZAxis = Random.Range((int)-3, (int)8);

        return new Vector3(XAxis, YAxis, ZAxis);
    }
}
