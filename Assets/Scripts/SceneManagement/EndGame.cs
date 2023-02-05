using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public SceneSwitcher SceneManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Balloon")
            SceneManager.ChangeScene();
    }
}
