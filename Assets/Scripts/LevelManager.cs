using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{   
    [SerializeField] int _enemysInLevel;
    int _currentPigeons = 0;
    [SerializeField] int _maxEnemysOnLevel;
    [SerializeField] GameObject[] _spawnPoints;
    [SerializeField] GameObject _enemyPrefab;

    public static LevelManager _sharedInstance;

    private void Awake() 
    {
        if (_sharedInstance != null && _sharedInstance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            _sharedInstance = this; 
        } 
    }
    // Start is called before the first frame update
    void Start()
    {
        while(_currentPigeons < _maxEnemysOnLevel)
        {
            AddEnemy();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void WinGame()
    {
        Debug.Log("Ganaste!");
    }

    void AddEnemy()
    {
        if(_enemysInLevel > 0 && _currentPigeons < _maxEnemysOnLevel)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        int index = Random.Range(0, _spawnPoints.Length);
        Instantiate(_enemyPrefab, _spawnPoints[index].transform.position, Quaternion.identity);
        _enemysInLevel--;
        _currentPigeons++;
    }

    public void EnemyScape()
    {
        _currentPigeons--;
        AddEnemy();
        if(_enemysInLevel == 0 && _currentPigeons == 0)
        {
            WinGame();
        }
    }

}
