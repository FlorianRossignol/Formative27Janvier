using System.Collections;
using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
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
    private State currentState_;
    private bool facingRight_ = false;
    private const float DeadZone = 0.1f;
    private const float MoveSpeed = 2.0f;
    
    void Start()
    {
        playerCharacterTransform_ = GetComponent<Transform>();
        currentState_ = State.IDLE;
    }
   
    private void FixedUpdate()
    {
        bodyPlayerCharacter_.velocity = new Vector2(Input.GetAxis("Horizontal") * MoveSpeed, bodyPlayerCharacter_.velocity.y);
        bodyPlayerCharacter_.velocity = new Vector2(bodyPlayerCharacter_.velocity.x,Input.GetAxis("Vertical") * MoveSpeed);
        if (Input.GetAxis("Horizontal") > DeadZone && !facingRight_)
        {
            Flip();
        }
        if (Input.GetAxis("Horizontal") < -DeadZone && facingRight_)
        {
            Flip();
        }
        switch (currentState_)
        {
            case State.IDLE:
                if(Mathf.Abs(Input.GetAxis("Horizontal")) > DeadZone)
                {
                    ChangeState(State.WALKSIDE);
                }

                if (Input.GetAxis("Vertical") > DeadZone)
                {
                    ChangeState(State.WALKUP);
                }
                
                if (Input.GetAxis("Vertical") < -DeadZone)
                {
                    ChangeState(State.WALKDOWN);
                }
                break;

            case State.WALKSIDE:

                if (Input.GetAxis("Vertical") > DeadZone)
                {
                    ChangeState(State.WALKUP);
                }

                if (Input.GetAxis("Vertical") < -DeadZone)
                {
                    ChangeState(State.WALKDOWN);
                }

                if ((Input.GetAxis("Vertical") > -DeadZone && Input.GetAxis("Vertical") < DeadZone)
                    && Input.GetAxis("Horizontal") > -DeadZone && Input.GetAxis("Horizontal") < DeadZone)
                {
                    ChangeState(State.IDLE);
                }
                break;
            
            case State.WALKUP:
                if(Mathf.Abs(Input.GetAxis("Horizontal")) > DeadZone)
                {
                    ChangeState(State.WALKSIDE);
                }
                
                if (Input.GetAxis("Vertical") < -DeadZone)
                {
                    ChangeState(State.WALKDOWN);
                }
                
                if ((Input.GetAxis("Vertical") > -DeadZone && Input.GetAxis("Vertical") < DeadZone)
                    && Input.GetAxis("Horizontal") > -DeadZone && Input.GetAxis("Horizontal") < DeadZone)
                {
                    ChangeState(State.IDLE);
                }
                break;
            
            case State.WALKDOWN:
                if(Mathf.Abs(Input.GetAxis("Horizontal")) > DeadZone)
                {
                    ChangeState(State.WALKSIDE);
                }
                
                if (Input.GetAxis("Vertical") > DeadZone)
                {
                    ChangeState(State.WALKUP);
                }
                
                if ((Input.GetAxis("Vertical") > -DeadZone && Input.GetAxis("Vertical") < DeadZone)
                    && Input.GetAxis("Horizontal") > -DeadZone && Input.GetAxis("Horizontal") < DeadZone)
                {
                    ChangeState(State.IDLE);
                }
                break;
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
            currentState_ = state;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Heart"))
        {
            Destroy(other.gameObject);
        }
    }
}