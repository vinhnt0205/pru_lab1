using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 30f;
    private Vector2 _moveDirection;
    public InputActionReference moveAction;
    public InputActionReference fireAction;

    public Vector2 xLimit;
    public Vector2 yLimit;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Time.timeScale = 0;
            ResetGame();
            ScoreManager.score -= 5;
            if (ScoreManager.score < 0)
            {
                ScoreManager.score = 0;
            }
        }
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("GameOver");
    }

}
