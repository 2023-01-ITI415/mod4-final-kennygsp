using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public Animator door;
    public GameObject openText;
    public GameObject closeText;
    public GameObject intText;

    public AudioSource doorSound;


    public bool inReach;




    void Start()
    {
        inReach = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            
            if(!door.GetBool("open"))
            {
                openText.SetActive(true);
                intText.SetActive(true);
            }
            else
            {
                closeText.SetActive(true);
                intText.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            openText.SetActive(false);
            closeText.SetActive(false);
            intText.SetActive(false);
        }
    }

    void Update()
    {

        if (inReach && Input.GetButtonDown("Interact"))
        {
            if(!door.GetBool("open"))
            {
                DoorOpens();
            }
            else
            {
                DoorCloses();
            }
        }

    }
    void DoorOpens ()
    {
        Debug.Log("It Opens");
        door.SetBool("open", true);
        doorSound.Play();
    }

    void DoorCloses()
    {
        Debug.Log("It Closes");
        door.SetBool("open", false);
    }


}
