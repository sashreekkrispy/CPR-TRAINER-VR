using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Rendering;
using UnityEngine;

public class error : MonoBehaviour
{

    public SineWaveMovement c = new SineWaveMovement();
    public float duration = 0;
    float maximum = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("upper"))
        {
            duration += Time.deltaTime;
            if(maximum <= c.distance)
            {
                maximum = c.distance;
            }
        }
        if (other.gameObject.CompareTag("below"))
        {
            duration = 0;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(maximum <= 5.5 && maximum>= 2)
        {
            if (duration >= 0.2f && duration <= 0.4f)
            {
                Debug.Log("goodcompression.");
            }
            else
            {
                Debug.Log("spike compression.");
            }
            maximum = 0;
        }
        else if(maximum < 2 && duration <= 0.15)
        {
            Debug.Log("Low compression.");
            maximum = 0;
        }
        else
        {
            Debug.Log("Too much compression");
            maximum = 0;
        }
    }

}
