using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticRadio : MonoBehaviour
{
    public GameObject intText;
    public GameObject walkie;
    public GameObject walkie2;
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
            intText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            intText.SetActive(false);
        }
    }

    void Update()
    {

        if (inReach && Input.GetButtonDown("Interact"))
        {
            walkie.SetActive(false);
            walkie2.SetActive(true);
            intText.SetActive(false);

        }


    }
}

