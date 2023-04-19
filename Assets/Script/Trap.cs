using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Trap : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        trapUp();
    }
    public void trapUp()
    {
        Debug.Log("sssss");
        transform.Translate(2, 0, 0);
    }
    public void trapDown()
    {
        Debug.Log("wwwww");
        transform.Translate(-2, 0, 0);
    }
    
}
