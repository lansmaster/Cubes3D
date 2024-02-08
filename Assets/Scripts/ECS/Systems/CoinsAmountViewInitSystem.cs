using Leopotam.Ecs;
using UnityEngine;

sealed class CoinsAmountViewInitSystem : IEcsInitSystem
{
    private readonly EcsFilter<ResourcesFeatureComponent> _featureFilter = null;

    private readonly EcsFilter<CoinsAmountViewComponent> _viewFilter = null;

    public void Init()
    {
        foreach (var i in _featureFilter)
        {
            ref var feature = ref _featureFilter.Get1(i);

            foreach (var j in _viewFilter)
            {
                ref var view = ref _viewFilter.Get1(j);

                view.valueText.text = feature.resourcesFeature.GetResourceValueString(ResourceType.Coin);
            }

            feature.resourcesFeature.ResourceChanged += UpdateViews;
        }
    }

    private void UpdateViews(ResourceType resourceType, int oldValue, int newValue)
    {
        foreach (var j in _viewFilter)
        {
            ref var view = ref _viewFilter.Get1(j);

            view.valueText.text = newValue.ToString();
        }
    }
}
