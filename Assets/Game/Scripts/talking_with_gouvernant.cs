using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class talking_with_gouvernant : MonoBehaviour
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
                //text_label.text = txt;
            }
        }
        
    }

    private void OnTriggerExit(Collider other){
        text_label.text = txt;
        text_label.enabled = false;
    }

    IEnumerator waiter(){

        text_label.text = "Detective: Hello! Do you now, where may be the key of the storeroom?";

        yield return new WaitForSeconds(3);

        text_label.text = "Gouvernant: Hello detective! I get this key";

        yield return new WaitForSeconds(3);

        text_label.text = "Detective: Give it to me, it's important";

        yield return new WaitForSeconds(3);

        text_label.text = "Gouvernant: Take it in bedroom near the mirror";

        yield return new WaitForSeconds(3);
    }
}
