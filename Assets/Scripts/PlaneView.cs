using Leopotam.Ecs;
using UnityEngine;

public class PlaneView : MonoBehaviour
{
    public EcsEntity entity;

    private void Start()
    {
        SetEntity();
    }

    private void SetEntity()
    {
        entity = EcsStartup.world.NewEntity();
        ref var plane = ref entity.Get<PlaneDataComponent>();
        plane.transform = GetComponent<Transform>();
        plane.meshRenderer = GetComponent<MeshRenderer>();
        plane.defaultMaterial = plane.meshRenderer.materials[0];
        plane.emissionMaterial = plane.meshRenderer.materials[1];
    }

    //private MeshRenderer _meshRenderer;
    //private Material[] _materials;
    //private Material _default;
    //private Material _emission;

    //public UnityAction<Vector3> positionPointMarked;

    //private void Start()
    //{
    //    _meshRenderer = GetComponent<MeshRenderer>();  
    //    _materials = _meshRenderer.materials;
    //    _default = _materials[0];
    //    _emission = _materials[1];
    //}

    //private void OnMouseDown()
    //{
    //    var positionPoint = transform.position;
    //    positionPointMarked?.Invoke(positionPoint);
    //}

    //public void SetEmission()
    //{
    //    _meshRenderer.material = _emission;
    //}

    //public void SetDefault()
    //{
    //    _meshRenderer.material = _default;
    //}
}
