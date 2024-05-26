using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class exitGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void button_exit()
    {

        Application.Quit();
        EditorApplication.isPlaying = false;

    }
}
