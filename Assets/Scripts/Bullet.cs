using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _bulletSpeed = 1f;
    Vector3 _firingPoint;
    // Start is called before the first frame update
    void Start()
    {
        _firingPoint = transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        MoveBullet();
    }

    void MoveBullet()
    {
        transform.Translate(Vector3.right * _bulletSpeed * Time.deltaTime);
    }
}
