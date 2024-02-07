using Leopotam.Ecs;
using UnityEngine;

sealed class CoinSpawnSystem : IEcsRunSystem
{
    private readonly EcsFilter<CoinDataComponent> _coinFilter = null;

    public void Run()
    {
        foreach (var i in _coinFilter)
        {

        }
    }
}