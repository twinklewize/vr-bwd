using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public static bool PickItem()
    {
        return (Input.GetKey(KeyCode.E) || OVRInput.Get(OVRInput.Button.One));
    }

    public static int GetAnswer(bool withSecondAnswer = true)
    {
        if (Input.GetKey(KeyCode.E) || OVRInput.Get(OVRInput.Button.One)) return 0;
        else if (withSecondAnswer && (Input.GetKey(KeyCode.R) || OVRInput.Get(OVRInput.Button.Two))) return 1;
        return -1;

    }

    public static bool StartDialogue()
    {
        return (Input.GetKey(KeyCode.E) || OVRInput.Get(OVRInput.Button.One));
    }
}
