using System;
using UnityEngine;

class TerrainConfig : MonoBehaviour
{
    public int TreeRenderDist = 10000;
    public Terrain terrain;
    void Start()
    {

        terrain.treeDistance = TreeRenderDist;
        Debug.Log(terrain.treeDistance);
    }
}
