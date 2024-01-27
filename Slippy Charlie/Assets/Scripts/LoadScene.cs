using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string sceneName;

    public void Start() {
        if (sceneName == null) {
            throw new System.Exception("Scene name not set");
        }
    }

    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
