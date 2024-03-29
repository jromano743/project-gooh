using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [Header("Gun Settings")]
    [SerializeField] Transform _firePoint;
    [SerializeField] AudioClip _shotSound;
    [SerializeField] float _firingSpeed;
    float _lastTimeShoot = 0;

    [Header("Bullet Settings")]
    [SerializeField] int _maxBullet;
    [SerializeField] int _currentBullet;

    // Update is called once per frame

    void Start() 
    {
        _currentBullet = _maxBullet;
    }
    void Update()
    {
        
    }

    public void AddBullet()
    {
        _currentBullet++;
    }

    public void Shoot()
    {
        
        if(_lastTimeShoot + _firingSpeed <= Time.time)
        {
            _lastTimeShoot = Time.time;
            GameObject bullet = BulletPool.Instance.RequestBullet();
            
            if(bullet != null)
            {
                bullet.GetComponent<Bullet>().MoveBullet(_firePoint);
                AudioManager._sharedInstance.PlaySound(_shotSound);
                _currentBullet--;
            }
            else
            {
                //play sin municion
                Debug.Log("Sin municion!");
            }
        }
    }
}
