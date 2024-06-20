using UnityEngine;
using UnityEngine.SceneManagement;

public class HideSceneOnStart : MonoBehaviour
{
    public int[] scenesToHide;

    void Start()
    {
        foreach (int sceneIndex in scenesToHide)
        {

                SceneManager.UnloadSceneAsync(sceneIndex);
        }
    }
}