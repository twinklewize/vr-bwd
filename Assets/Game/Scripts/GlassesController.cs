using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassesController : MonoBehaviour
{
    static GameObject glasses;
    void Start()
    {
        glasses = gameObject;
        gameObject.SetActive(false);
    }

    public static void SetActive()
    {
        glasses.SetActive(true);
    }
}
