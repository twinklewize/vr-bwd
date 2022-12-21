using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class open_special : MonoBehaviour
{
    private Animator anim;
    public Text txt;

    void Start(){
        anim = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other){
        if(global.key){
            if(other.CompareTag("Player")){
                txt.enabled = true;
                if(Input.GetKey(KeyCode.E) || OVRInput.Get(OVRInput.Button.One)){
                    anim.enabled = true;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other){
        txt.enabled = false;
    }
}
