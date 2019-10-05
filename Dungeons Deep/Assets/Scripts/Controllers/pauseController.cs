using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseController : MonoBehaviour
{
    public static bool gamePaused;
    public InventoryUI inven;

    public void Update(){

        if (Input.GetKeyDown(KeyCode.Escape)){
            gamePaused = !gamePaused;
            inven.triggerInventory();
        }

        if (gamePaused == true){
            Time.timeScale = 0;
        } else {
            Time.timeScale = 1;
        }
    }
}
