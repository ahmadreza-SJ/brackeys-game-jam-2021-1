using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class BackgroundGenerator : MonoBehaviour
{
    public GameObject StarPrefab;

    public float GenerateRatio = 0.5f;
    public float Depth = 10;
    public float MinDistance = 5;

    //private Camera camera;

    private Vector3 GetRandomPosInCameraView()
    {
        float z = Random.Range(MinDistance, MinDistance + Depth);

        Range xRange = GameManager.Instance.GetCameraViewXRange(z);
        Range yRange = GameManager.Instance.GetCameraViewYRange(z);
        float y = Random.Range(yRange.Min - 100, yRange.Max + 100);
        float x = Random.Range(xRange.Min, xRange.Max);

        return new Vector3(x, y, z);
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i <100; i++)
        {
            Instantiate(StarPrefab, GetRandomPosInCameraView(), StarPrefab.transform.rotation, gameObject.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
