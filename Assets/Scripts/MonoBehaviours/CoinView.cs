using Leopotam.Ecs;
using UnityEngine;

public class CoinView : MonoBehaviour
{
    public EcsEntity entity;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube"))
            entity.Del<IsActiveCoin>();
    }
}
