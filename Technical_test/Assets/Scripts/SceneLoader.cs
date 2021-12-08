using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    // Choose in Editor the scene to be loaded
    [SerializeField] int sceneToLoad;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(SceneLoad);
    }

    public void SceneLoad()
    {
        SceneManager.LoadSceneAsync(sceneToLoad);
        print("Scène Load");
    }
}
