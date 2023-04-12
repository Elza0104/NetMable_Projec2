using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class St1_Arrow : MonoBehaviour
{
    [SerializeField] GameObject Arrow_Prefab;
    [SerializeField] Transform MPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        
    }
    void Shoot()
    {
        GameObject Arrow = Instantiate(Arrow_Prefab);
        Arrow.transform.position = MPos.position;
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("wwww");
        if (collision.gameObject.CompareTag("TERRA"))
        {
            Debug.Log("qwd");
            Destroy(gameObject);
        }
    }
}
