using Leopotam.Ecs;
using UnityEngine;

public class CubeView : MonoBehaviour
{
    private bool isActive = false;

    public EcsEntity entity;

    private void OnMouseDown()
    {
        if (isActive)
        {
            entity.Del<IsActiveCube>();
            isActive = false;
        }
        else
        {
            entity.Get<IsActiveCube>();
            isActive = true;
        }
    }
}
