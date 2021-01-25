using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] private SpriteRenderer playerCharacterSprite_;
    [SerializeField] private Rigidbody2D bodyPlayerCharacter_;
    
    private Transform playerCharacterTransform_;
    private bool facingRight_, facingLeft_, facingUp_, facingDown_;
    private const float DeadZone = 0.1f;
    private const float MoveSpeed = 2.0f;
    void Start()
    {
        playerCharacterSprite_ = GetComponent<SpriteRenderer>();
        bodyPlayerCharacter_ = GetComponent<Rigidbody2D>();
        playerCharacterTransform_ = GetComponent<Transform>();
    }

    
    void Update()
    {
        bodyPlayerCharacter_.velocity = new Vector2(Input.GetAxis("Horizontal") * MoveSpeed, bodyPlayerCharacter_.velocity.y);
        bodyPlayerCharacter_.velocity = new Vector2(bodyPlayerCharacter_.velocity.x,Input.GetAxis("Vertical") * MoveSpeed);
    }
}
