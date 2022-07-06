using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonStateManager : MonoBehaviour
{
    //Holds a reference to the active state in a SM
    PigeonBaseState _currentState;

    //Properties
    public float _movementSpeed;
    public float _rotationSpeed;
    Vector3 _bulletPosition;
    Vector3 _windowPosition;

    //States initialize
    public PigeonBotherState _botherState = new PigeonBotherState();
    public PigeonWalkAwayState _walkAwayState = new PigeonWalkAwayState();
    public PigeonRunAwayState _runAwayState = new PigeonRunAwayState();
    // Start is called before the first frame update
    void Start()
    {
        //Set Initial state
        _currentState = _botherState;

        //"this" is a reference to the context (this EXACT Monobehaivor script)
        _currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        _currentState.UpdateState(this);
    }

    public void SwitchState(PigeonBaseState state)
    {
        _currentState = state;
        state.EnterState(this);
    }

    private void OnCollisionEnter(Collision other) 
    {
        _currentState.OnCollisionEnter(this, other);
    }

    private void OnTriggerEnter(Collider other) 
    {
        _currentState.OnTriggerEnter(this, other);
    }

    public Vector3 GetBulletPosition()
    {
        return _bulletPosition;
    }

    public void SetBulletPosition(Vector3 position)
    {
        _bulletPosition = position;
    }
    public Vector3 GetWindowPosition()
    {
        return _windowPosition;
    }

    public void SetWindowPosition(Vector3 position)
    {
        _windowPosition = position;
    }

    public void Scape()
    {
        StopAllCoroutines();
        LevelManager._sharedInstance.EnemyScape();
        Destroy(gameObject);
    }
}
