using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        Debug.Log("teste");
        SceneManager.LoadScene(sceneName);
    }
}
