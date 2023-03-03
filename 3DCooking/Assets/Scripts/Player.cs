using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 7.5f;
    private bool _isWalking = false;

    private void Update()
    {
        Vector2 inputVector = new Vector2(0, 0);

        if(Input.GetKey(KeyCode.W))
        {
            inputVector.y = +1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x = +1;
        }

        inputVector = inputVector.normalized;
        Vector3 moveDirection = new Vector3(inputVector.x, 0f, inputVector.y);
        float rotationSpeed = 10f;

        _isWalking = moveDirection != Vector3.zero;
        transform.position += moveDirection * _movementSpeed * Time.deltaTime;
        transform.forward = Vector3.Slerp(transform.forward, moveDirection, rotationSpeed * Time.deltaTime);
    }

    public bool IsWalking()
    {
        return _isWalking;
    }
}
