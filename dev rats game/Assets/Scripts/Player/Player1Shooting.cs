using System.Collections;
using System.Collections.Generic;
using BulletFury;
using BulletFury.Data;
using UnityEngine;

public class Player1Shooting : MonoBehaviour
{
    private BulletManager _bm;

    private int _bulletAmount;
    [SerializeField] private int maxBulletAmount = 500;

    [SerializeField] private bool infinityEnabled = false;

    private GameManager _gameManager;
    
    [SerializeField] private ForceField shield;
    [HideInInspector] public bool aiming;
    
    float bulletSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        
        _bm = GetComponent<BulletManager>();

        _bulletAmount = maxBulletAmount;
        bulletSpeed = _bm.GetBulletSettings().Speed;
        
        aiming = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (infinityEnabled || !infinityEnabled && _bulletAmount > 0)
        {
            if (!_gameManager.GetIsPaused())
            {
                ShootNewBullet();
            }
        }
    }

    private void ShootNewBullet()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (Input.GetMouseButton(0))
            {
                aiming = true;
                _bm.GetBulletSettings().SetSpeed(bulletSpeed * Time.deltaTime);
                _bm.Spawn(transform.position, _bm.Plane == BulletPlane.XY ?
                    transform.up : transform.forward);
            }
            else if (Input.GetMouseButton(1))
            {
                aiming = true;
                shield.MakeAvailable();
            }
            else
            {
                shield.MakeUnavailable();
                aiming = false;
            }
        }
    }

    public int GetBulletAmount()
    {
        return _bulletAmount;
    }

    public bool GetInfinityEnabled()
    {
        return infinityEnabled;
    }
}
