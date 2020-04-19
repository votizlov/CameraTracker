using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public void LoadScene(string name) => UnityEngine.SceneManagement.SceneManager.LoadScene(name);
}
