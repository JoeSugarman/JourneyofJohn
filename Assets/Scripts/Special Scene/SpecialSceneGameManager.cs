using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialSceneGameManager : MonoBehaviour
{
    private int collectibleCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        collectibleCount = 0;
    }

    public void IncrementCounter()
    {
        collectibleCount++;
        Debug.Log("Collectible count: " + collectibleCount);
    }
}
