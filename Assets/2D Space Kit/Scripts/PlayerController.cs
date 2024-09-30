using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 5f;
    private Vector2 _moveDirection;
    public InputActionReference moveAction;
    public InputActionReference fireAction;

    public Vector2 xLimit;
    public Vector2 yLimit;

    // Start is called before the first frame update
    void Start()
    {
        xLimit = new Vector2(-30f, 30f);
        yLimit = new Vector2(-50f, 50f);
    }

    // Update is called once per frame
    void Update()
    {
        _moveDirection = moveAction.action.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector2 move = new Vector2(_moveDirection.x * speed, _moveDirection.y * speed);
        rb.velocity = move;

        Vector2 newPosition = rb.position + move * speed * Time.deltaTime;

        newPosition.x = Mathf.Clamp(newPosition.x, xLimit.x, xLimit.y);
        newPosition.y = Mathf.Clamp(newPosition.y, yLimit.x, yLimit.y);

        rb.MovePosition(newPosition);
    }
    private void OnEnable()
    {
        fireAction.action.started += Fire;
    }

    private void OnDisable()
    {
        fireAction.action.started -= Fire;
    }

    private void Fire(InputAction.CallbackContext context)
    {
        Debug.Log("Fire");
    }
}
