using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string myScene = "MainGame";

    public void LoadLevel()
    {
        SceneManager.LoadScene(myScene);
    }
}
