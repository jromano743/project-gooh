using UnityEngine;

public abstract class PigeonBaseState
{
    public abstract void EnterState(PigeonStateManager pigeon);
    public abstract void UpdateState(PigeonStateManager pigeon);
    public abstract void OnCollisionEnter(PigeonStateManager pigeon, Collision collision);
    public abstract void OnTriggerEnter(PigeonStateManager pigeon, Collider other);
    public abstract void OnTriggerStay(PigeonStateManager pigeon, Collider other);
}
