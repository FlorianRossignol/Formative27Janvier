using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private enum State
    {
        NONE,
        IDLE,
        WALKSIDE,
        WALKDOWN,
        WALKUP
    }
    [SerializeField] private SpriteRenderer playerCharacterSprite_;
    [SerializeField] private Rigidbody2D bodyPlayerCharacter_;
    [SerializeField] private Animator anim_;
    
    private Transform playerCharacterTransform_;
    private State currentstate_;
    private bool facingRight_ = false;
    private const float DeadZone = 0.1f;
    private const float MoveSpeed = 2.0f;
    void Start()
    {
        playerCharacterTransform_ = GetComponent<Transform>();
    }

    
    void Update()
    {
        bodyPlayerCharacter_.velocity = new Vector2(Input.GetAxis("Horizontal") * MoveSpeed, bodyPlayerCharacter_.velocity.y);
        bodyPlayerCharacter_.velocity = new Vector2(bodyPlayerCharacter_.velocity.x, Input.GetAxis("Vertical") * MoveSpeed);
    }


    void Flip()
    {
        playerCharacterSprite_.flipX = !playerCharacterSprite_.flipX;
        facingRight_ = !facingRight_;
    }


    void ChangeState(State state)
    {
        switch(state)
        {
            case State.IDLE:
                anim_.Play("idle");
                break;
            case State.WALKSIDE:
                anim_.Play("walkleftright");
                break;
            case State.WALKDOWN:
                anim_.Play("walkdown");
                break;
            case State.WALKUP:
                anim_.Play("walkup");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
        currentstate_ = state;
    }
}
