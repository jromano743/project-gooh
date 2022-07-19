using UnityEngine;
using System.Collections;

public class PigeonBotherState : PigeonBaseState
{
    bool _imSafe = true;

    float _rotationSpeed;
    float _movementSpeed;
    bool isWandering;
    bool isRotationLeft;
    bool isRotationRight;
    bool isWalking;
    GameObject _gameObject;

    public override void EnterState(PigeonStateManager pigeon)
    {
        pigeon.transform.rotation = Quaternion.Euler(0,pigeon.transform.rotation.y,0);

        _imSafe = true;
        isWandering = false;
        isRotationLeft = false;
        isRotationRight = false;
        isWalking = false;
        
        _gameObject = pigeon.gameObject;

        _rotationSpeed = pigeon._rotationSpeed;
        _movementSpeed = pigeon._movementSpeed;
    }

    public override void UpdateState(PigeonStateManager pigeon)
    {
        if(!isWandering)
        {
            pigeon.StartCoroutine(Wander());
        }

        if(isRotationRight)
        {
            _gameObject.transform.Rotate(pigeon.transform.up * Time.deltaTime * _rotationSpeed);
        }

        if(isRotationLeft)
        {
            _gameObject.transform.Rotate(pigeon.transform.up * Time.deltaTime * -_rotationSpeed);
        }

        if(isWalking)
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

    IEnumerator Wander()
    {
        int rotateDirection = Random.Range(1,3); //1 or 2 (letf or right)
        int rotationTime = Random.Range(1,3);
        int walkTime = Random.Range(1,3);

        int rotateWait = Random.Range(1,2);
        int walkWait = Random.Range(1,2);

        isWandering = true;

        yield return new WaitForSeconds(walkWait);

        isWalking = true;

        yield return new WaitForSeconds(walkTime);

        isWalking = false;

        yield return new WaitForSeconds(rotateWait);

        if(rotateDirection == 1)
        {
            isRotationLeft = true;
            yield return new WaitForSeconds(rotationTime);
            isRotationLeft = false;
        }

        if(rotateDirection == 2)
        {
            isRotationRight = true;
            yield return new WaitForSeconds(rotationTime);
            isRotationRight = false;
        }

        isWandering = false;
    }
}
