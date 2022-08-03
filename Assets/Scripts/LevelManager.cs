using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{   
    [SerializeField] int _enemysForLevel;
    [SerializeField] int _enemysInLevel;
    [SerializeField] int _currentPigeons = 0;
    [SerializeField] int _maxEnemysOnLevel;
    [SerializeField] GameObject[] _spawnPoints;
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] PlayerController _playerController;

    float _score = 0;
    float _highScore = 0;

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
        _enemysInLevel = _enemysForLevel;
        _currentPigeons = 0;

        while(_currentPigeons < _maxEnemysOnLevel)
        {
            AddEnemy();
        }


        _levelTime = 0;
        _gameOver = false;

        
        Debug.Log("High Score: " + _highScore);
        Debug.Log("Score: "+ _score);
        GUIManager._sharedInstance.InGame();
    }

    // Update is called once per frame
    void Update()
    {
        if(!_gameOver) _levelTime += Time.deltaTime;
    }

    public void WinGame()
    {
        EndGame(true);
        _playerController._GameOver = true;
        //_playerController.PlayEndGameAnimation(true);
    }

    public void EndGame(bool winGame)
    {
        DeleteEnemies();
        BulletPool.Instance.CollectAllBullets();

        bool newScore = false;
        string winText = winGame ? "You win!" : "Game over!";
        _score = _levelTime;

        Debug.Log("High Score: " + _highScore);
        Debug.Log("Score: "+ _score);

        if(_score < _highScore || _highScore == 0){
            _highScore = _score;
            newScore = true;
        }

        Debug.Log("High Score: " + _highScore);
        Debug.Log("Score: "+ _score);

        string _stringScore = FormatTime(_score);
        string _stringHighScore = FormatTime(_highScore);
        GUIManager._sharedInstance.GameOver(winText, _stringScore, _stringHighScore, newScore);

        if(winGame)
        {
            AudioManager._sharedInstance.PlayWinSound();
        }
        else
        {
            AudioManager._sharedInstance.PlayWinSound();
        }

        _playerController._GameOver = true;
    }

    void AddEnemy()
    {
        if(_enemysInLevel != 0 && _currentPigeons < _maxEnemysOnLevel)
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

    void DeleteEnemies()
    {
        GameObject[] aux = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (var item in aux)
        {
            Destroy(item);
        }
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

    public string FormatTime(float time)
    {
        int minutes = (int) time / 60000 ;
        int seconds = (int) time / 1000 - 60 * minutes;
        int milliseconds = (int) time - minutes * 60000 - 1000 * seconds;
        return string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds );
    }

}
