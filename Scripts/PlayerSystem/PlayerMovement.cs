using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    Vector2 move;
    [SerializeField] float speed = 5f;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;
    private void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        rb2d.velocity = move * speed;
        spriteHandle();
    }

    void spriteHandle(){
        if(!spriteRenderer.flipX && move.x < 0){
            spriteRenderer.flipX = true;
        }
        else if(spriteRenderer.flipX && move.x > 0){
            spriteRenderer.flipX = false;
        }
    }
    void OnMove(InputValue value){
        move = value.Get<Vector2>();
        Debug.Log(move);
    }
}
