using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeController : MonoBehaviour {

    public static GameObject promptBox;

    public void Start()
    {
        promptBox = GameObject.FindGameObjectWithTag("promptBox"); // returns 'promptBox' which allows for dropped items to refrence it.
        promptBox.SetActive(false);


    }
}
