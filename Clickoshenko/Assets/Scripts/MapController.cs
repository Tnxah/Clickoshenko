using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public static MapController instance;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    public Map currentMap;

}
