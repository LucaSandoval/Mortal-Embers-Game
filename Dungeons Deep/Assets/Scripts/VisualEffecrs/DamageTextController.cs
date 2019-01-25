using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageTextController : MonoBehaviour {


    private static DamageText damageText;

    private static GameObject canvas;


    public static void Initialize()
    {

        canvas = GameObject.Find("Canvas");
        if (!damageText)
        {
            
                damageText = Resources.Load<DamageText>("hitEffects/DamageTextParent");

            
        }

    }

   
       
    public static void CreateDamageText(string text, Transform location, string color)
    {

        Initialize();
        DamageText instance = Instantiate(damageText);
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(new Vector2(location.position.x + Random.Range(-.5f, .5f), location.position.y + Random.Range(-.5f, .5f)));

        instance.SetColor(color);
        instance.transform.SetParent(canvas.transform, false);
        instance.transform.position = screenPosition;
        instance.SetText(text);        
    }
}
