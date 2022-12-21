using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpeningDoor : MonoBehaviour
{
    private Animator anim;
    public Text txt;

    void Start(){
        anim = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other){
        Debug.Log(other.CompareTag("Player"));
        if(other.CompareTag("Player")){
            txt.enabled = true;
            if(Input.GetKey(KeyCode.E) || OVRInput.Get(OVRInput.Button.One)){
                anim.enabled = true;
                //anim.Play("Door_Open");
                Debug.Log('a');
            }
        }
    }

    private void OnTriggerExit(Collider other){
        txt.enabled = false;
    }
}
