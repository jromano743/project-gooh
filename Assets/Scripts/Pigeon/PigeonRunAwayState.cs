using System.Collections;
using UnityEngine;

public class PigeonRunAwayState : PigeonBaseState
{
    float _movementSpeed;
    bool _isWalking = false;
    bool _isMoving = false;
    Vector3 _windowPosition;
    bool _imSafe = false;
    GameObject _gameObject;
    public override void EnterState(PigeonStateManager pigeon)
    {
        Debug.Log("ESTADO RUN AWAY");
        _isMoving = false;
        _isWalking = false;
        _imSafe = true;
        _movementSpeed = pigeon._movementSpeed;

        _windowPosition = pigeon.GetWindowPosition();
        _gameObject = pigeon.gameObject;
        _gameObject.transform.LookAt(_windowPosition);

        pigeon.StartCoroutine(RunAway());
    }

    public override void UpdateState(PigeonStateManager pigeon)
    {
        if(_isWalking)
        {
            _gameObject.transform.position += pigeon.transform.forward * _movementSpeed * Time.deltaTime;
        }

        if(!_imSafe)
        {
            pigeon.StopAllCoroutines();
            pigeon.SwitchState(pigeon._walkAwayState);
        }
    }

    public override void OnCollisionEnter(PigeonStateManager pigeon, Collision collision)
    {
        
    }

    public override void OnTriggerEnter(PigeonStateManager pigeon, Collider other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            _imSafe = false;
            pigeon.SetBulletPosition(other.transform.position);
        }
    }

    public override void OnTriggerStay(PigeonStateManager pigeon, Collider other)
    {
        
    }

    IEnumerator RunAway()
    {
        int walkTime = Random.Range(1,3);


        _isMoving = true;

        _isWalking = true;

        yield return new WaitForSeconds(walkTime);

        _isWalking = false;

        _isMoving = false;

        _imSafe = true;

    }

}

