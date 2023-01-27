using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EvidenceController : MonoBehaviour
{
    public string title;
    private GameObject player;

    const int maxdist = 2;
    const int minDist = 1;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogueController.state != DialogueState.none || GameController.state == GameState.call)
        {
            gameObject.GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 0);
            return;
        }

        float dist = Vector3.Distance(player.transform.position, gameObject.transform.position);
        if (dist >= maxdist)
        {
            gameObject.GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 0);
        }

        else if (dist <= minDist)
        {
            gameObject.GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 1);
        } else
        {
            float opacity = (maxdist - dist) / (maxdist - minDist);
            gameObject.GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, opacity);
        }
    }


}