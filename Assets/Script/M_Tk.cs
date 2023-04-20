using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Tk : MonoBehaviour
{
    void Update()
    {
        Vector2 MPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = MPos;
    }
}
