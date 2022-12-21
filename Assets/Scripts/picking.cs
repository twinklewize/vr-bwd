using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class picking : MonoBehaviour
{

    public Text txt;

    private void OnTriggerStay(Collider other){
        //Debug.Log("sheeeeet");
        if(other.CompareTag("Player")){
            txt.enabled = true;
            if(Input.GetKey(KeyCode.E) || OVRInput.Get(OVRInput.Button.One)){
                if(gameObject.tag == "Key") global.key = true;
                Destroy(gameObject);
                txt.enabled = false;
            }
        }
        
    }

    private void OnTriggerExit(Collider other){
        txt.enabled = false;
    }
}
