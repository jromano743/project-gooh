using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGame : MonoBehaviour
{
    [SerializeField] float _stressfarRatio = 0.1f;
    [SerializeField] float _stressClaseRatio = 0.2f;
    float _stress = 0;
    bool _isEnd = false;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            AddStress(_stressClaseRatio);
        }
    }

    private void OnTriggerStay(Collider other) 
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            AddStress(_stressfarRatio);
        }
    }
    void AddStress(float value)
    {
        if(_isEnd) return;

        _stress += value;
        if(_stress > 100)
        {
            _stress = 100;
            _isEnd = true;
            LevelManager._sharedInstance.EndGame();
        }

        GUIManager._sharedInstance.UpdateStressBar(_stress);
    }

    void StartGame()
    {
        _stress = 0;
        _isEnd = false;
    }
}
