using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    private static CurrentInteraction interaction = CurrentInteraction.none;
    private bool interactionIsBlocked;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}


public enum CurrentInteraction
{
    none,

    artist,

    mother,
    homekeeper,
    detective,
    courier,

    brush,
    glasses,

    cans,
    stepladder,
    painting,
}