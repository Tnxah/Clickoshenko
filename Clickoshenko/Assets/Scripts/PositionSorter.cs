using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSorter : MonoBehaviour
{
    void Start()
    {
        GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y * 1000) * -1);
    }


    //private void FixedUpdate()
    //{
    //    GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y * 1000) * -1);
    //}
}
