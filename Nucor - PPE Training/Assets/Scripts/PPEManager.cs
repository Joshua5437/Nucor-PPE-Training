using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PPEManager : MonoBehaviour
{
    private int counter = 0;
    public GameObject[] CorrectPPE;

    public GameObject CurrentScene, NextScene;

    private void Update() {
        for (int i = 0; i < CorrectPPE.Length; i++) {
            if(CorrectPPE[i].activeSelf == false) { counter = counter + 1; }
        }

        if(counter == CorrectPPE.Length) {  // Switches user to next scene. 
            NextScene.active = true;
            CurrentScene.active = false;

            if(NextScene.name == "Hazard Scenario 1") {
                NextScene.GetComponent<SceneTeleport>().TeleportUser();
            } else {
                CurrentScene.GetComponent<SceneTeleport>().TeleportUser();
            }
        }
        else { counter = 0; }
    }
}
