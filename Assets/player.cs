using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    Vector2 rawInput;
    
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 delta = rawInput * speed * Time.deltaTime;
        transform.position += delta;
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }
}
