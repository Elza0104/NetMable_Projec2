using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class St1_Arrow : MonoBehaviour
{
    [SerializeField] GameObject Arrow_Prefab;
    [SerializeField] Transform M_Pos;
    [SerializeField] TextMeshProUGUI text_arrow;
    [SerializeField] bool isShoot;
    [SerializeField] int Arrow_y;
    [SerializeField] float Arrow_cooltime;
    private void Awake()
    {
        isShoot = true;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isShoot)
        {
            Shoot();
        }
    }
    void Shoot()
    {
        GameObject Arrow = Instantiate(Arrow_Prefab);
        Arrow.transform.position = new Vector2(M_Pos.position.x, Arrow_y);
        GetComponent<AudioSource>().Play();
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
        isShoot = false;
    }
    public void isOn()
    {
        isShoot = true;
    }
}
