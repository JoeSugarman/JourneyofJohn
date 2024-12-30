using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodChecker : MonoBehaviour
{
    public int woodCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void CollectWood() 
    { 
        woodCount++;

    }
        
}
