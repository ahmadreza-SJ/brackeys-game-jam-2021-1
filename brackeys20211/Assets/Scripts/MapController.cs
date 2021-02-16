using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public GameObject chunkPrefab;
    void Start()
    {
        Instantiate(chunkPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    void Update()
    {
        
    }
}
