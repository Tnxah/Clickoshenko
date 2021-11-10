using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSorter : MonoBehaviour
{
    private void FixedUpdate()
    {
        GetComponent<SpriteRenderer>().sortingOrder = -(int)transform.localPosition.y;
    }
}
