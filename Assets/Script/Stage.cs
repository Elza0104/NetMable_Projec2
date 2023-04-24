using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Arrow;
    [SerializeField] GameObject button_Reset;
    [SerializeField] GameObject button_Scene;
    private void Start()
    {
        buttonOff();
    }
    public void EndPage()
    {
        Arrow.GetComponent<St1_Arrow>().isOff();
        button();
    }
    public void ResetPage()
    {
        Arrow.GetComponent<St1_Arrow>().isOn();
        buttonOff();
        Player.SetActive(true);
        Player.GetComponent<P_1>().ReSpawn();
    }
    void buttonOff()
    {
        button_Reset.SetActive(false);
        button_Scene.SetActive(false);
    }
    void button()
    {
        button_Reset.SetActive(true);
        button_Scene.SetActive(true);
    }
    public void To2()
    {
        SceneManager.LoadScene("Stage_2");
    }
    public void To3()
    {
        SceneManager.LoadScene("Stage_3");
    }
    public void To0()
    {
        SceneManager.LoadScene("StartScene");
    }
}
