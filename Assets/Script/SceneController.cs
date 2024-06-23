using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void SceneNetWorkCableScene()
    {
        SceneManager.LoadScene("NetWorkCableScene");
    }    

    public void SceneFirstPlace()
    {
        SceneManager.LoadScene("FirstPlace");
    }    

    public void SceneGamePlay(){
        SceneManager.LoadScene("Màn 1");
    }

    public void ApplicationQuit()
    {
        Application.Quit();
    }    
}
