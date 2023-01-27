using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCanvas : MonoBehaviour
{
    public Text text;
    // public gameObject canvas;

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            text.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other){
        if(other.CompareTag("Player")){
            text.enabled = false;
        }
    }
}
