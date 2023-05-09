using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    public GameObject Walkie;
    public GameObject Walkie2;
    public GameObject WalkieIcon;
    public AudioSource WalkiePickUp;


    public AudioSource WalkieOn;
    public AudioSource WalkieCoolDown;


    // Start is called before the first frame update
    void Start()
    {   
        WalkiePickUp.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Walkie.activeSelf)
        {
            WalkieIcon.SetActive(true);
        }

        if (Input.GetButtonDown("Radio"))
        {
            if (Walkie2.activeSelf)
            {
                Walkie2.SetActive(false);
            }
            else
            {
                Walkie2.SetActive(true);
                WalkieOn.Play();
            }
        }
    }
}
