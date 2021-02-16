using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkGenerator : MonoBehaviour
{

    public GameObject positive;
    public GameObject negative;
    public GameObject comet;

    private int XSIZE = 7;
    private int YSIZE = 10;
    private int XDIFF = 4;
    private int YDIFF = 3;
    private int[,] BOARD;

    void Awake()
    {
        BOARD = new int[XSIZE, YSIZE];
        
        Generate();
    }

    void Update()
    {
        
    }

    void Generate()
    {
        for (int y=0; y<YSIZE; y++)
        {
            for (int x=0; x<XSIZE; x++)
            {
                Instantiate(positive, new Vector3(x-XDIFF, y-YDIFF, 0), Quaternion.identity);
            }
        }
    }
}
