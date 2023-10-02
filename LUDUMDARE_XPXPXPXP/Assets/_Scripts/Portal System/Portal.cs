using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public int NextScene;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            if (collision.collider.CompareTag("Player"))
            {
                SceneManager.LoadScene(NextScene);
            }
        }
    }
}
