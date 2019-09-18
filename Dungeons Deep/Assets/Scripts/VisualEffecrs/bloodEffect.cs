using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bloodEffect : MonoBehaviour {

    Camera cam;

    public Image img;

    public static float bloodEffectAmmount;


    private void Start()
    {
        cam = GetComponent<Camera>();
        bloodEffectAmmount = 0f;

    }

    private void Update()
    {
        img.rectTransform.sizeDelta = new Vector2(cam.pixelWidth, cam.pixelHeight);


        var newColor = img.color;
        newColor.a = bloodEffectAmmount;

        img.color = newColor;
        
        if (bloodEffectAmmount > 0)
        {
            bloodEffectAmmount = bloodEffectAmmount - 0.01f;
        }


    }

}
