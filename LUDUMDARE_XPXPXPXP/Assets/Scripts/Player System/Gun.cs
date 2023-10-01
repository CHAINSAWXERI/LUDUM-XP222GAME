using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public static int _amunitionGun = 5;
    [SerializeField] public GameObject _bullet;
    [SerializeField] public Transform _shotpoint;

    private float _timeShot;
    public float _starttumeShot;

    void Update()
    {

        if (_timeShot <= 0)
        {
            if (Input.GetMouseButton(0) & (_amunitionGun > 0))
            {
                _amunitionGun--;
                Instantiate(_bullet, _shotpoint.position, transform.rotation);
                _timeShot = _starttumeShot;
            }
        }
        else
        {
            _timeShot -= Time.deltaTime;
        }
    }

    public void TakeBoxAm()
    {
        _amunitionGun = _amunitionGun + 100;
    }
}
