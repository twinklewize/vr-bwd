using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if ((GameController.state == GameState.call || GameController.state == GameState.game) || DialogueController.state != DialogueState.none)
        {
            return;
        }

        
        if (other.CompareTag("Player"))
        {
            UIController.SetExitText();
            if (InputController.PickItem())
            {
                Application.Quit();
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (DialogueController.state != DialogueState.none || GameController.state == GameState.call)
        {
            return;
        }

        UIController.RemoveText();
    }
}
