using Leopotam.Ecs;
using TMPro;
using UnityEngine;

public class CoinsAmountView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _valueText;

    private void Start()
    {
        var entity = EcsStartup.world.NewEntity();
        ref var view = ref entity.Get<CoinsAmountViewComponent>();
        view.valueText = _valueText;
    }
} 