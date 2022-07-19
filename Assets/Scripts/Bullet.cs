using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _bulletSpeed = 1f;
    [SerializeField] Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //MoveBullet();
    }

    public void MoveBullet(Transform firePoint)
    {
        transform.rotation = firePoint.rotation;
        transform.position = firePoint.position;

        _rb.AddForce(transform.right * _bulletSpeed);
    }

    public void BulletCollected()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Pasa");
            BulletCollected();
        }    
    }
    
}
