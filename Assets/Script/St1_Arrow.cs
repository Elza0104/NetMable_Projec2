using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class St1_Arrow : MonoBehaviour
{
    [SerializeField] GameObject Arrow_Prefab;
    [SerializeField] Transform MPos;
    [SerializeField] TextMeshProUGUI text_arrow;
    public static bool isshoot = true;
    public static St1_Arrow Instance;
    public int Arrow_y;
    public float Arrow_cooltime;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        isshoot = true;
    }
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
        Arrow.transform.position = new Vector3(MPos.position.x, Arrow_y, MPos.position.z);
        isshoot = false;
        StartCoroutine("Shootis");
    }
    IEnumerator Shootis()
    {
        text_arrow.text = "Arrow - Loading";
        yield return new WaitForSeconds(Arrow_cooltime);
        text_arrow.text = "Arrow - Load";
        isshoot = true;
    }
    public static void isOff()
    {
        isshoot = false;
    }
    public static void isOn()
    {
        isshoot = true;
    }
}
