using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AreaManager : MonoBehaviour {

    public int areaID = 1;
    private string areaName = "null";

    private Text areNameText;

    private void Start()
    {
        areNameText = GameObject.FindGameObjectWithTag("areaText").GetComponent<Text>();

        switch (areaID)
        {
            case 1:
                areaName = "Stonefall Tower";
                break;
            case 2:
                areaName = "Mortal Garden";
                break;
            default:
                areaName = "null";
                break;
        }

        areNameText.text = areaName;

    }
}
