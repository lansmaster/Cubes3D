using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CubeTester : MonoBehaviour
{
    //private bool isActive = false;

    //private void OnMouseDown()
    //{
    //    if (isActive)
    //    {
    //        SetDefaultForPlanes();
    //    }
    //    else
    //    {
    //        SetEmissionForAccessiblePlanes();
    //    }
    //}

    //private List<Collider> GetAccessiblePlanes()
    //{
    //    Collider[] hits = Physics.OverlapBox(transform.position, transform.localScale);

    //    List<Collider> result = new List<Collider>();

    //    foreach (Collider hit in hits)
    //    {
    //        result.Add(hit);
    //    }

    //    return result;
    //}

    //private void SetEmissionForAccessiblePlanes()
    //{
    //    var planes = GetAccessiblePlanes();

    //    foreach (var plane in planes)
    //    {
    //        if(plane.gameObject.TryGetComponent(out PlaneView planeTester))
    //        {
    //            planeTester.SetEmission();
    //            planeTester.positionPointMarked += MoveToNewPosition;
    //        }
    //    }

    //    isActive = true;
    //}

    //private void SetDefaultForPlanes()
    //{
    //    var planes = GetAccessiblePlanes();

    //    foreach (var plane in planes)
    //    {
    //        if (plane.gameObject.TryGetComponent(out PlaneView planeTester))
    //        {
    //            planeTester.SetDefault();
    //            planeTester.positionPointMarked -= MoveToNewPosition;
    //        }
    //    }

    //    isActive= false;
    //}

    //private void MoveToNewPosition(Vector3 planePosition)
    //{
    //    SetDefaultForPlanes();
    //    transform.position = new Vector3(planePosition.x, transform.position.y, planePosition.z);
    //    SetEmissionForAccessiblePlanes();
    //}
}
