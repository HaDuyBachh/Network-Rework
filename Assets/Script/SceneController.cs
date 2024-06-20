using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public List<string> fromScenes;
    public List<string> toScenes;
    void Start()
    {

    }

    void Update()
    {
        // // hiện nút bấm tại index chỉ định
        // for (int i = 0; i < buttons.Length; i++)
        // {
        //     if (currentSceneIndex == i)
        //     {
        //         buttons[i].SetActive(true);
        //     }
        //     else
        //     {
        //         buttons[i].SetActive(false);
        //     }
        // }
    }

    public void SwitchScene(List<string> fromScenes, List<string> toScenes)
    {
        // chuyển đến scene được chọn
        foreach (string scene in fromScenes)
        {
            if (!string.IsNullOrEmpty(scene))
            {
                SceneManager.UnloadSceneAsync(scene);
            }
        }
        foreach (string scene in toScenes)
        {
            if (!string.IsNullOrEmpty(scene))
            {
                SceneManager.LoadScene(scene, LoadSceneMode.Additive);
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("ok");
        SwitchScene(fromScenes, toScenes);
    }
}
