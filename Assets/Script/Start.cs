using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Start : MonoBehaviour
{
    public void StageStart()
    {
        SceneManager.LoadScene("Stage_1");
    }
    public void End()
    {
        Application.Quit();
    }
}
