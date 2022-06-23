using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] Transform _firePoint;
    [SerializeField] GameObject _projectilePrefab;
    [SerializeField] float _firingSpeed;
    float _lastTimeShoot = 0;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        if(_lastTimeShoot + _firingSpeed <= Time.time)
        {
            _lastTimeShoot = Time.time;
            Instantiate(_projectilePrefab, _firePoint.position, _firePoint.rotation);
        }
    }
}
