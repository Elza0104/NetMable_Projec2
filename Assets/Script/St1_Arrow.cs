using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class St1_Arrow : MonoBehaviour
{
    [SerializeField] GameObject Arrow_Prefab;
    [SerializeField] Transform M_Pos;
    [SerializeField] TextMeshProUGUI text_arrow;
    public bool isshoot = true;
    public int Arrow_y;
    public float Arrow_cooltime;
    private void Awake()
    {
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
        Arrow.transform.position = new Vector2(M_Pos.position.x, Arrow_y);
        isOff();
        StartCoroutine("Shootis");
    }
    IEnumerator Shootis()
    {
        text_arrow.text = "Arrow - Loading";
        yield return new WaitForSeconds(Arrow_cooltime);
        text_arrow.text = "Arrow - Load";
        isOn();
    }
    public void isOff()
    {
        isshoot = false;
    }
    public void isOn()
    {
        isshoot = true;
    }
}
