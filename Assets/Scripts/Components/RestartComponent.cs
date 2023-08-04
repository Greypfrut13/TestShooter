using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RestartComponent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        Restart();
    }

    private void Restart()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentScene);
    }
}
