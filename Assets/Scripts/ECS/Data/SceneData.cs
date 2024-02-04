using System.Collections.Generic;
using UnityEngine;

public class SceneData : MonoBehaviour
{
    public Transform cubeSpawnPoint;
    public GameObject[] planesGameObjects;

    private void Start()
    {
        var planeViews = FindObjectsOfType<PlaneView>();

        planesGameObjects = new GameObject[planeViews.Length];

        for (int i = 0; i < planeViews.Length; i++)
        {
            planesGameObjects[i] = planeViews[i].gameObject;
        }
    }
}
