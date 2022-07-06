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

    float _levelTime = 0;
    bool _gameOver = false;

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
    public void StartGame()
    {
        while(_currentPigeons < _maxEnemysOnLevel)
        {
            AddEnemy();
        }

        _levelTime = 0;
        _gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!_gameOver) _levelTime += Time.deltaTime;
    }

    public void WinGame()
    {
        Debug.Log("Ganaste!");
    }

    public void EndGame()
    {
        Debug.Log("Fin del juego");
        Debug.Log("Tiempo: "+ _levelTime.ToString());
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
