using UnityEngine;
using UnityEngine.SceneManagement;

public class startAnotherScene : MonoBehaviour
{
    
    public void Play() 
    {
        SceneManager.LoadScene("CutScene");
    }
}