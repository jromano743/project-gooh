using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] Vector3 _targetOffset;

    [SerializeField] float _movementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        transform.position = Vector3.Lerp(transform.position, _target.position + _targetOffset, _movementSpeed * Time.deltaTime);
    }
}
