using Leopotam.Ecs;
using UnityEngine;

sealed class InputSystem : IEcsRunSystem
{
    private readonly EcsFilter<InputComponent> _filter;

    public void Run()
    {
        foreach (var i in _filter)
        {
            ref var input = ref _filter.Get1(i);
        }
    }
}
