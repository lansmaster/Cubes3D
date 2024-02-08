using Leopotam.Ecs;
using UnityEngine;

public class PlaneView : MonoBehaviour
{ 
    public EcsEntity entity;

    private void Start()
    {
        SetEntity();
    }

    private void OnMouseDown()
    {    
        entity.Get<InputComponent>().inputPosition = transform.position;
    }

    private void SetEntity()
    {
        entity = EcsStartup.world.NewEntity();

        ref var plane = ref entity.Get<PlaneDataComponent>();

        plane.meshRenderer = GetComponent<MeshRenderer>();
        plane.defaultMaterial = plane.meshRenderer.materials[0];
        plane.emissionMaterial = plane.meshRenderer.materials[1];
    }
}