using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskmanagerScript : MonoBehaviour
{


    float startCameraLocalY;
    bool FlaglookLeft, FlaglookRight;
    bool FlagCollisionDetected;
    public GameObject Shoulder, Hand,Neck;
    public Button emergencyButton;
    Collider shoulderCollider, handCollider,neckCollider;
    public Toggle tooltip1, tooltip2, tooltip3, tooltip4;
    public AudioSource emergencyAudio;
    


    
    
    
    
    enum Tasks
    {
        InitializeCamera,
        LookAround,
        CheckForResponse,
        CheckPulse,
        ButtonToCallEmergency
    }

    Tasks currentTask = Tasks.InitializeCamera;

    Transform cameraTransform;
    

    
  


    void Start()
    {
        cameraTransform = Camera.main.transform;

        //so here basically we check if the game object has been set in unity and fetch its collider
        if (Shoulder != null)
           shoulderCollider = Shoulder.GetComponent<Collider>();
        if (Hand != null)
            handCollider = Hand.GetComponent<Collider>();

        if(Neck != null)
            neckCollider = Neck.GetComponent<Collider>();


        emergencyButton.enabled = false;
    }
    
    void Update()
    {
        switch (currentTask)
        {
            case Tasks.InitializeCamera:
                startCameraLocalY = cameraTransform.localEulerAngles.y;
                currentTask = Tasks.LookAround;
                break;


                //First task where player has to look around

            case Tasks.LookAround:

                tooltip1.enabled = true;
                if (cameraTransform.localEulerAngles.y> startCameraLocalY + 95)
                {   

                   FlaglookRight = true;

                }

                if(cameraTransform.localEulerAngles.y < startCameraLocalY - 95)
                {

                    FlaglookLeft = true;
                }



                if (FlaglookLeft && FlaglookRight)
                {
                   

                    tooltip1.isOn = true;
                    StartCoroutine(wait());
                    tooltip1.enabled = false;

                }

                currentTask = Tasks.CheckForResponse;
                break;


                //Second task where player taps the patients shoulder to check for response


            case Tasks.CheckForResponse:

                tooltip2.enabled = true;

                if(handCollider.bounds.Intersects(shoulderCollider.bounds))
                {
                    FlagCollisionDetected = true;
                }

                if (FlagCollisionDetected)
                {
                    

                    tooltip2.isOn = true;
                    StartCoroutine(wait());
                    tooltip2.enabled = false;
                }


                currentTask = Tasks.CheckPulse;

                break;

              
            

                case Tasks.CheckPulse:

                tooltip4.enabled = true;

                if (handCollider.bounds.Intersects(neckCollider.bounds))
                {

                    tooltip4.isOn = true;
                    StartCoroutine (wait());
                    tooltip4.enabled = false;
                }

                currentTask = Tasks.ButtonToCallEmergency;

                    break;





            
            
            
            
            
            case Tasks.ButtonToCallEmergency:
                //pop out the emergency button once this prompt is reached till then it is not visible
                emergencyButton.enabled = true;

                tooltip3.enabled = true;
                
                if (emergencyButton.onClick.Equals(true))
                {
                    emergencyAudio.Play();
                    StartCoroutine(wait());
                    tooltip3.isOn = true;
                    StartCoroutine(wait());
                    tooltip3.enabled = false;
                    StartCoroutine(wait());
                    emergencyButton.enabled = false;


                    // code for background voice to be activated when button is pressed

                }


                break;




        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(3);
    }
}
