using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] int _poolSize = 10;
    [SerializeField] List<GameObject> _bulletList;

    //Singleton
    private static BulletPool instance;
    public static BulletPool Instance {get { return instance; } }

    private void Awake() 
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        AddBulletsToPool(_poolSize);
    }

    void AddBulletsToPool(int amount)
    {
        for(int i=0; i<amount; i++)
        {
            GameObject bullet = Instantiate(_bulletPrefab);
            bullet.SetActive(false);
            _bulletList.Add(bullet);

            bullet.transform.parent = transform;
        }
    }

    public GameObject RequestBullet()
    {
        for(int i=0; i<_bulletList.Count;i++)
        {
            if(!_bulletList[i].activeSelf)
            {
                _bulletList[i].SetActive(true);
                return _bulletList[i];
            }
        }

        return null;
    }

    public void CollectAllBullets()
    {
        for(int i=0; i<_bulletList.Count;i++)
        {
            if(_bulletList[i].activeSelf)
            {
                _bulletList[i].SetActive(false);
            }
        }
    }
}
