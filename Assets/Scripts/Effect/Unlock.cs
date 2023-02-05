using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock : MonoBehaviour
{
    private void OnEnable()
    {
        if (GameObject.Find("Door") != null)
            GameObject.Find("Door").GetComponent<Door>().Open();
    }
}
