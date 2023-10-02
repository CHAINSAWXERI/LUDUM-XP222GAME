using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int _amunitionGun;
    [SerializeField] TMP_Text text;
    [SerializeField] GameObject ShotFlash;
    [SerializeField] public GameObject _bullet;
    [SerializeField] public Transform _shotpoint;

    private float _timeShot;
    public float _starttumeShot;


    private void Start()
    {
        text.text = "Bullets: " + _amunitionGun;
        ShotFlash.SetActive(false);
    }

    void Update()
    {

        if (_timeShot <= 0)
        {
            if (Input.GetMouseButton(0) & (_amunitionGun > 0))
            {
                _amunitionGun--;
                text.text = "Bullets: " + _amunitionGun;
                ShotFlash.SetActive(true);
                Instantiate(_bullet, _shotpoint.position, transform.rotation);
                _timeShot = _starttumeShot;

            }
            else
            {
                ShotFlash.SetActive(false);
            }
        }
        else
        {
            _timeShot -= Time.deltaTime;
        }
        
    }

    public void TakeBoxAm(int amun)
    {
        _amunitionGun = _amunitionGun + amun;
        text.text = "Bullets: " + _amunitionGun;
    }
}
