using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class St1_Arrow : MonoBehaviour
{
    [SerializeField] GameObject Arrow_Prefab;
    [SerializeField] Transform MPos;
    [SerializeField] TextMeshProUGUI text_arrow;
    [SerializeField] TextMeshProUGUI text_trap;
    [SerializeField] GameObject Trap_Prefab;
    public static bool isshoot = true;
    public static bool istrap = true;
    public static St1_Arrow Instance;
    
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isshoot)
        {
            Shoot();
        }
        if (Input.GetMouseButtonDown(1) && istrap)
        {
            TrapOn();
        }
    }
    void Shoot()
    {
        GameObject Arrow = Instantiate(Arrow_Prefab);
        Arrow.transform.position = new Vector3(MPos.position.x, 15, MPos.position.z);
        isshoot = false;
        StartCoroutine("Shootis");
    }
    IEnumerator Shootis()
    {
        text_arrow.text = "Arrow - Loading";
        yield return new WaitForSeconds(0.5f);
        text_arrow.text = "Arrow - Load";
        isshoot = true;
    }
    public static void isOnOff()
    {
        isshoot = false;
    }
    void TrapOn()
    {
        if (istrap)
        {
            Debug.Log("qwd");
            Trap_Prefab.GetComponent<Trap>().trapUp();
            StartCoroutine("_trap");
            StartCoroutine("down_trap");
            istrap = false;
        }
    }
    IEnumerator _trap()
    {
        text_trap.text = "Trap_Loading";
        yield return new WaitForSeconds(3f);
        text_trap.text = "Trap_Load";
        istrap = true;
    }
    IEnumerator down_trap()
    {
        yield return new WaitForSeconds(0.5f);
        Trap_Prefab.GetComponent<Trap>().trapDown();
    }
    public static void trapOff()
    {
        istrap = false;
    }
}
