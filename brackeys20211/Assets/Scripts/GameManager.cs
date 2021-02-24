using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.SingleTones;
using Utils;

public class GameManager : MonoSingleton<GameManager>
{
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
            
    }

    public Range GetCameraViewYRange(float z)
    {
        Camera MainCam = Camera.main;
        float range = (z - MainCam.gameObject.transform.position.z) * Mathf.Tan(Mathf.Deg2Rad * MainCam.fieldOfView / 2);
        return new Range(MainCam.gameObject.transform.position.y - range, MainCam.gameObject.transform.position.y + range);
    }

    public Range GetCameraViewXRange(float z)
    {
        Camera MainCam = Camera.main;
        float range = (z - MainCam.gameObject.transform.position.z) * Mathf.Tan(Mathf.Deg2Rad * MainCam.fieldOfView / 2) * MainCam.aspect;
        return new Range(MainCam.gameObject.transform.position.x - range, MainCam.gameObject.transform.position.x + range);
    }
}
