using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseController : MonoBehaviour
{
    public static bool gamePaused;
    public InventoryUI inven;
    public GameObject pauseMenu;

    public void Update(){

        if (Input.GetKeyDown(KeyCode.Escape)){
            gamePaused = !gamePaused;
            inven.triggerInventory();
            pauseMenu.SetActive(!pauseMenu.activeSelf);
        }

        if (gamePaused == true){
            Time.timeScale = 0;
        } else {
            Time.timeScale = 1;
        }
    }

    public void Resume(){
        gamePaused = !gamePaused;
        inven.triggerInventory();
        pauseMenu.SetActive(!pauseMenu.activeSelf);
    }

    public void Quit(){
        Application.Quit();
    }
}
