using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.SingleTones;

public class GameManager : MonoSingleton<GameManager>
{
    public float screenHalfHeight;
    public float screenHalfWidth;
    // Start is called before the first frame update
    void Start()
    {
        Camera MainCam = Camera.main;
        screenHalfHeight = MainCam.orthographicSize;
        screenHalfWidth = MainCam.aspect * screenHalfHeight;
    }
}
