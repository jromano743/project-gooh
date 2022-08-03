using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager _sharedInstance;
    public PlayerController _player;
    [SerializeField] PlayerGame _playerGame;
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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        ResetGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResetGame()
    {
        _player.StartGame();
        _playerGame.StartGame();
        LevelManager._sharedInstance.StartGame();
    }

}
