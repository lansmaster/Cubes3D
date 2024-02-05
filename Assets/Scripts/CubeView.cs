using Leopotam.Ecs;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CubeView : MonoBehaviour
{
    private bool isActive = false;

    private void OnMouseDown()
    {
        if (isActive)
        {
            DelEntityForPlanes();
        }
        else
        {
            SetEntityForAccessiblePlanes();
        }
    }

    private List<Collider> GetAccessiblePlanes()
    {
        Collider[] hits = Physics.OverlapBox(transform.position, transform.localScale);

        List<Collider> result = new List<Collider>();

        foreach (Collider hit in hits)
        {
            result.Add(hit);
        }

        return result;
    }

    private void SetEntityForAccessiblePlanes()
    {
        var planes = GetAccessiblePlanes();

        foreach (var plane in planes)
        {
            if (plane.gameObject.TryGetComponent(out PlaneView planeView))
            {
                planeView.entity.Get<IsAccessiblePlane>();
            }
        }

        isActive = true;
    }

    private void DelEntityForPlanes()
    {
        var planes = GetAccessiblePlanes();

        foreach (var plane in planes)
        {
            if (plane.gameObject.TryGetComponent(out PlaneView planeView))
            {
                planeView.entity.Del<IsAccessiblePlane>();
            }
        }

        isActive = false;
    }
}
