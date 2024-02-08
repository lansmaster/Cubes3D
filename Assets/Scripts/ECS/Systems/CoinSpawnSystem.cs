using Leopotam.Ecs;
using UnityEngine;

sealed class CoinSpawnSystem : IEcsRunSystem
{
    private readonly StaticData _staticData;

    private readonly EcsFilter<CoinDataComponent>.Exclude<IsActiveCoin> _coinFilter = null;

    private readonly EcsFilter<ResourcesFeatureComponent> _featureFilter = null;

    public void Run()
    {
        foreach (var i in _coinFilter)
        {
            ref var entity = ref _coinFilter.GetEntity(i);
            ref var coin = ref _coinFilter.Get1(i);

            Object.Destroy(coin.coinGameObject);
            //

            foreach (var j in _featureFilter)
            {
                ref var feature = ref _featureFilter.Get1(j);

                feature.resourcesFeature.AddResource(ResourceType.Coin, 1);
            }

            //
            var gameObject = Object.Instantiate(_staticData.CoinData.coinPrefab, RandomPosition(), Quaternion.identity);
            gameObject.GetComponent<CoinView>().entity = entity;

            coin.coinGameObject = gameObject;

            entity.Get<IsActiveCoin>();
        }
    }

    private Vector3 RandomPosition()
    {
        var XAxis = Random.Range((int)-3, (int)12);
        var YAxis = -0.5f;
        var ZAxis = Random.Range((int)-3, (int)8);

        return new Vector3(XAxis, YAxis, ZAxis);
    }
}