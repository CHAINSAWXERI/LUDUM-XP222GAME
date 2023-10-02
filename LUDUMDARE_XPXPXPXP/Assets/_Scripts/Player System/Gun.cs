using TMPro;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private int _bulletsAmount;
    [SerializeField] private int _maxBulletsInMagazine;
    [SerializeField] TMP_Text text;
    [SerializeField] GameObject ShotFlash;
    [SerializeField] public GameObject _bullet;
    [SerializeField] public Transform _shotpoint;

    private float _timeShot;
    public float _startTimeShot;
    private bool isShooting = false;
    private int bulletsInMagazine;
    
    private Animator anim;

    private void Start()
    {
        bulletsInMagazine = _maxBulletsInMagazine;
        _bulletsAmount -= bulletsInMagazine;
        text.text = "Bullets: " + bulletsInMagazine + "/" + _bulletsAmount;
        ShotFlash.SetActive(false);
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        text.text = "Bullets: " + bulletsInMagazine + "/" + _bulletsAmount;
        if (_timeShot <= 0)
        {
            if (Input.GetMouseButton(0) && bulletsInMagazine > 0 && !isShooting)
            {
                anim.Play(HashedAnimationsData.Shoot);
                isShooting=true;
                bulletsInMagazine--;
                text.text = "Bullets: " + bulletsInMagazine + "/" + _bulletsAmount;
                ShotFlash.SetActive(true);
                Instantiate(_bullet, _shotpoint.position, _shotpoint.rotation);
                _timeShot = _startTimeShot;
            }
            else if(isShooting)
            {
                ShotFlash.SetActive(false);
                isShooting = false;
                anim.CrossFade(HashedAnimationsData.Idle, 0.3f);
            }
        }
        else
        {
            _timeShot -= Time.deltaTime;
        }
        if(bulletsInMagazine <= 0 && _bulletsAmount > 0)
        {
            anim.Play(HashedAnimationsData.Reload); 
            text.text = "Bullets: " + bulletsInMagazine + "/" + _bulletsAmount;

            if (_bulletsAmount >= _maxBulletsInMagazine)
            {
                bulletsInMagazine = _maxBulletsInMagazine;
                _bulletsAmount -= _maxBulletsInMagazine;
                text.text = "Bullets: " + bulletsInMagazine + "/" + _bulletsAmount;

            }
            else
            {
                bulletsInMagazine = _bulletsAmount;
                _bulletsAmount = 0;
                text.text = "Bullets: " + bulletsInMagazine + "/" + _bulletsAmount;

            }
        }
    }

    public void TakeBoxAm(int amun)
    {
        _bulletsAmount = _bulletsAmount + amun;
        text.text = "Bullets: " + _bulletsAmount;
    }
}
