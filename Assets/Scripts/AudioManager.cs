using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager _sharedInstance;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _winGame;
    [SerializeField] AudioClip _loseGame;
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
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayWinSound()
    {
        _audioSource.PlayOneShot(_winGame);
    }

    public void PlayLoseSound()
    {
        _audioSource.PlayOneShot(_loseGame);
    }

    public void PlaySound(AudioClip sound)
    {
        _audioSource.PlayOneShot(sound);
    }
}
