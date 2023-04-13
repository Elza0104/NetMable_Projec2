using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class St1_Arrow : MonoBehaviour
{
    [SerializeField] GameObject Arrow_Prefab;
    [SerializeField] Transform MPos;
    [SerializeField] TextMeshProUGUI text;
    private bool isshoot = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isshoot)
        {
            Shoot();
        }
    }
    void Shoot()
    {
        GameObject Arrow = Instantiate(Arrow_Prefab);
        Arrow.transform.position = new Vector3(MPos.position.x, 10, MPos.position.z);
        isshoot = false;
        StartCoroutine("Shootis");
    }
    IEnumerator Shootis()
    {
        text.text = "Arrow - Loading";
        yield return new WaitForSeconds(0.5f);
        text.text = "Arrow - Load";
        isshoot = true;
    }
}
