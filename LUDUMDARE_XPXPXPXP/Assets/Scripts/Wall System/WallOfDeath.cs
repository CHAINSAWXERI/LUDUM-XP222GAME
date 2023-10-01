using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallOfDeath : MonoBehaviour
{
    public int speed;
    void Update()
    {
        transform.position += new Vector3(1 + Time.deltaTime * speed, 4, 7);
    }
}
