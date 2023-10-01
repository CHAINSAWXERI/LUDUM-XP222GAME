using UnityEngine;

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
}
