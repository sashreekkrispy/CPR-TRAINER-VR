using UnityEngine;
using System.Collections;
using System.IO.Ports;


public class communication : MonoBehaviour
{
    SerialPort stream = new SerialPort("COM5", 9600);
    public string receivedstring;
    //public GameObject carrito;
    public string[] datos;
    public string[] datos_recibidos;
    

    
    private void Start()
    {
        stream.Open();
        StartCoroutine(ReadData());

    }

    IEnumerator ReadData()
    {
        while (true)
        {
            receivedstring = stream.ReadLine(); //Read the information
             //Clear the serial information so we assure we get new information.
            datos_recibidos[0] = receivedstring;
            yield return new WaitForSeconds(0);

            

        }
    }
    

}

