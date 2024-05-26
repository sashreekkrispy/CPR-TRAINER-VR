using System.Collections;
using UnityEngine;
using Unity.VisualScripting;

public class SineWaveMovement : MonoBehaviour
{
    public float amplitude = 2f; // Amplitude of the sine wave.
    public float frequency = 0.05f; // Frequency of the sine wave.
    public GameObject startpos;
    public communication c = new communication();
    public GameObject parent;
    public GameObject pointer;
    public float distance;
    //public GameObject player;

    


    void Update()
    {
        
        float x = transform.localPosition.x - frequency * Time.deltaTime;
        float y;
        
        {
            y = startpos.transform.localPosition.y + (-amplitude)*Mathf.Sin((float.Parse(c.datos_recibidos[0]) - 12) * Mathf.PI/14);

        }
        float z = startpos.transform.localPosition.z;

        // Update the GameObject's position.
        transform.localPosition = new Vector3(x, y, z);
        if (transform.position.x < startpos.transform.position.x - 2)
        {
            
            Instantiate(pointer, new Vector3(startpos.transform.position.x, transform.position.y, startpos.transform.position.z), startpos.transform.rotation,parent.transform);
            //this.gameObject.transform.SetParent(parent.transform);
            Destroy(pointer);

        }
        distance = 13 - float.Parse(c.datos_recibidos[0]);
        //Debug.Log(distance);

    }

}
