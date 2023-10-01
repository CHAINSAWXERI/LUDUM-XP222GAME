using UnityEngine;
using UnityEngine.SceneManagement;

public class WallOfDeath : MonoBehaviour
{
    [SerializeField] private int speed;

    private Vector3 direction;

    void Update()
    {
        MoveWall();
    }

    private void MoveWall()
    {
        direction = new Vector3(speed * Time.deltaTime, 0,0);
        transform.Translate(direction);
    }

    private void OnCollisionEnter(Collision collision)
    {
            if (collision != null)
            {
                if (collision.collider.CompareTag("Player"))
                {
                    SceneManager.LoadScene(1);
                }
            }
    }
}
