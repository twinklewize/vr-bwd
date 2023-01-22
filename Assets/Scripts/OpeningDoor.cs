using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.Animations;

public class OpeningDoor : MonoBehaviour
{
    private Animator anim;
    public Text txt;
    public bool state = false;
    public AnimatorController open;
    public AnimatorController close;
    // public MonoBehaviour door_state;

    void Start(){
        anim = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other){
        if(other.CompareTag("Player")){
            txt.enabled = true;
            if((Input.GetKey(KeyCode.E) || OVRInput.Get(OVRInput.Button.One)) && state == false){
                anim.enabled = false;
                anim.runtimeAnimatorController = open as RuntimeAnimatorController;
                anim.enabled = true;
                changeDoorState();
                Debug.Log("open");
            }
            else if((Input.GetKey(KeyCode.E) || OVRInput.Get(OVRInput.Button.One)) && state == true){
                anim.enabled = false;
                anim.runtimeAnimatorController = close as RuntimeAnimatorController;
                anim.enabled = true;
                changeDoorState();
                Debug.Log("close");
            }

        }
    }

    private void OnTriggerExit(Collider other){
        txt.enabled = false;
    }

    private void changeDoorState(){
        state = !state;
    }

    // IEnumerator open(){
    //     if((Input.GetKey(KeyCode.E) || OVRInput.Get(OVRInput.Button.One)) && state == false){

    //         // anim.enabled = true;
    //         playAnim();
    //         yield return new WaitForSeconds(3);
    //         changeDoorState();
    //         Debug.Log("aaa");
    //         // anim.enabled = false;
    //     }
    //     // anim.enabled = false;
    // }

    // IEnumerator close(){
    //     if((Input.GetKey(KeyCode.E) || OVRInput.Get(OVRInput.Button.One)) && state == true){
    //         anim.SetFloat("close", -1);
    //         playAnim();
    //         yield return new WaitForSeconds(3);
    //         changeDoorState();
    //         // anim.enabled = false;
    //     }
    //     // anim.enabled = false;
    // }
}


                //anim.Play("Door_Open");
                            // if(!state) { StartCoroutine(open()); }
            // else { StartCoroutine(close());}