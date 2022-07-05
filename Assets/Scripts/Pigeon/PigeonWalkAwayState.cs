using System.Collections;
using UnityEngine;

public class PigeonWalkAwayState : PigeonBaseState
{
    float _movementSpeed;
    bool _windowNear = false;
    bool _isWalking = false;
    bool _isMoving = false;
    Vector3 _bulletPosition;
    Vector3 _windowPosition;
    bool _imSafe = false;
    GameObject _gameObject;
    public override void EnterState(PigeonStateManager pigeon)
    {
        Debug.Log("ESTADO WALK AWAY");

        _windowNear = false;
        _isMoving = false;
        _isWalking = false;
        _imSafe = false;
        _gameObject = pigeon.gameObject;
        _movementSpeed = pigeon._movementSpeed;

        _bulletPosition = pigeon.GetBulletPosition();
        _gameObject.transform.LookAt(2 * _gameObject.transform.position - _bulletPosition);

        pigeon.StartCoroutine(RunAway());
    }

    public override void UpdateState(PigeonStateManager pigeon)
    {
        if(_isWalking)
        {
            _gameObject.transform.position += pigeon.transform.forward * _movementSpeed * Time.deltaTime;
        }

        if(_imSafe)
        {
            pigeon.StopAllCoroutines();
            pigeon.SwitchState(pigeon._botherState);
        }

        if(_windowNear)
        {
            pigeon.StopAllCoroutines();
            pigeon.SwitchState(pigeon._runAwayState);
        }
    }

    public override void OnCollisionEnter(PigeonStateManager pigeon, Collision collision)
    {
        
    }

    public override void OnTriggerEnter(PigeonStateManager pigeon, Collider other)
    {
         if(!_windowNear && other.gameObject.CompareTag("Window"))
        {
            _windowNear = true;;
            pigeon.SetWindowPosition(other.transform.position);
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
