using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speed = 6f;
    [SerializeField] PlayerGun _playerGun;
    [SerializeField] Vector3 _initialPosition;
    [SerializeField] Animator _anim;
    bool _gameOver = false;
    public bool _GameOver { get { return _gameOver; } set { _gameOver = value; } }


    void Start() 
    {
        _playerGun = GetComponentInChildren<PlayerGun>();
        _anim = GetComponent<Animator>();
        _gameOver = true;
    }

    public void StartGame()
    {
        transform.position = _initialPosition;
        _gameOver = false;
    }

    void Update()
    {
        if(!_gameOver)
        {
            MovePlayer();
            HandleRotationInput();
            HandleShootInput();
        }
        else
        {
            //Debug.Log("Play Angry animation");
        }
    }

    void MovePlayer(){
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical);

        if(direction.magnitude != 0)
        {
            _anim.SetBool("isWalking", true);
        }
        else
        {
            _anim.SetBool("isWalking", false);
        }

        transform.Translate(direction * _speed * Time.deltaTime, Space.World);
    }

    void HandleRotationInput()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }
    }

    void HandleShootInput()
    {
        if(Input.GetButton("Fire1"))
        {
            _playerGun.Shoot();
        }
    }

    public void PlayEndGameAnimation(bool winGame)
    {
        if(winGame)
        {
            _anim.SetBool("win", true);
        }
        else
        {
            _anim.SetBool("lose", true);
        }
    }
}
