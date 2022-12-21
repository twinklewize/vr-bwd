using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class talking_with_deliver : MonoBehaviour
{

    public Text text_label;
    private string txt;

    // Start is called before the first frame update
    void Start()
    {
        txt = text_label.text;
    }

    private void OnTriggerStay(Collider other){
        //Debug.Log("sheeeeet");
        if(other.CompareTag("Player")){
            text_label.enabled = true;
            if(Input.GetKey(KeyCode.E) || OVRInput.Get(OVRInput.Button.One)){
                //text_label.enabled = false;
                StartCoroutine(waiter());
                text_label.text = txt;
            }
        }
        
    }

    private void OnTriggerExit(Collider other){
        text_label.text = txt;
        text_label.enabled = false;
    }

    IEnumerator waiter(){
        text_label.text = "Deliver: Hello detective!";

        yield return new WaitForSeconds(3);

        text_label.text = "Detective: Hello! What are you doing here now?";

        yield return new WaitForSeconds(3);

        text_label.text = "Deliver: I brought pizza, and there police stoped me and";

        yield return new WaitForSeconds(3);

        text_label.text = "Deliver: accuses of kidnapping!";

        yield return new WaitForSeconds(3);

        text_label.text = "Detective: I'm working on this case";

        yield return new WaitForSeconds(3);
    }
}
