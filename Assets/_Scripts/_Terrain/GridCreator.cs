using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCreator : MonoBehaviour {
    public GameObject gameGridCube;
    public int intLength, intWidth;
    public float floHillClustering, floHillHeight;
    public Transform tformStartPos;

    void Start() {
        GenerateGrid();
    }

    public void GenerateGrid() {
        Vector3 v3NewPos;
        GameObject gamoNewObj;
        float floNewHeight;
        float floPx;
        float floPy;
        float floRndm;

        //Clamp Hill Controls
        floRndm = Random.Range(-5f, 5f);

        floHillClustering = Mathf.Clamp(floHillClustering + floRndm, 20, 200);

        floHillHeight = Mathf.Clamp(floHillHeight + floRndm, 1, 60);
        for (int x = 0; x < intLength; x++) {
            for (int z = 0; z < intWidth; z++) {
                floPx = Mathf.PerlinNoise((float)x / floHillClustering, .76f * (float)intLength);
                floPy = Mathf.PerlinNoise((float)z / floHillClustering, .22f * (float)intWidth);
                floNewHeight = floPx * floHillHeight * floPy;
                v3NewPos = new Vector3(z - 10, floNewHeight, x - 10);

                gamoNewObj = Instantiate(gameGridCube, tformStartPos);
                gamoNewObj.transform.position = v3NewPos;
                gamoNewObj.transform.localScale = new Vector3(1f, 5f, 1f);
            }//End y For Loop
        }//End x For Loop
    }//End GenerateGrid Method
}