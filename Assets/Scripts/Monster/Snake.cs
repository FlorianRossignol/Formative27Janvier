using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] Animator snakeanim_;
    private State currentstate_;
    private enum State
    {
        NONE,
        IDLE
    }
    
    void Start()
    {
        currentstate_ = State.IDLE;
    }

   
    void FixedUpdate()
    {

    }

    void ChangeState(State state)
    {
        switch (state)
        {
            case State.IDLE:
                snakeanim_.Play("idlesnake");
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
        currentstate_ = state;

    }
}
