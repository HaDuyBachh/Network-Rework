using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOnStart : MonoBehaviour
{
    public int[] scenesToHide;
    void Start()
    {
        foreach (int sceneIndex in scenesToHide)
        {

                SceneManager.UnloadSceneAsync(sceneIndex);
        }
        if (!SceneManager.GetSceneByName("Persistent").isLoaded)
        {
            SceneManager.LoadScene("Persistent", LoadSceneMode.Additive);
        }
        if (!SceneManager.GetSceneByName("SOICTRoom").isLoaded)
        {
            SceneManager.LoadScene("SOICTRoom", LoadSceneMode.Additive);
        }
        if (SceneManager.GetSceneByName("FlappyBirdScene").isLoaded)
        {
            SceneManager.UnloadSceneAsync("FlappyBirdScene");
        }
        if (SceneManager.GetSceneByName("NetWorkCable").isLoaded)
        {
            SceneManager.UnloadSceneAsync("NetWorkCable");
        }
    }
}