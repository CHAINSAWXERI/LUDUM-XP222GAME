using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public int NextScene;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision != null)
        {
            if (collision.CompareTag("Player"))
            {
                SceneManager.LoadScene(NextScene);
            }
        }
    }
}
