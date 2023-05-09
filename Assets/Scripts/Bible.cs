using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bible : MonoBehaviour
{
    public GameObject BibleObj;
    public GameObject intText;
    public AudioSource BiblePickUp;
    public AudioSource holy;
    public bool inReach;

    // Start is called before the first frame update
    void Start()
    {
        inReach = false; 
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Reach")
        {
            inReach = true;
            intText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Reach")
        {
            inReach = false;
            intText.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inReach && Input.GetButtonDown("Interact"))
        {
            BiblePickUp.Play();
            BibleObj.SetActive(false);
            intText.SetActive(false);
        }
    }
}
