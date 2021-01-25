using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] private SpriteRenderer PlayerCharacterSprite_;
    [SerializeField] private Rigidbody2D BodyPlayerCharacter_;
    private Transform PlayerCharcterTransform_;
    private const float DeadZone_ = 0.1f;
    private const float MoveSpeed_ = 2.0f;
    void Start()
    {
        PlayerCharacterSprite_ = GetComponent < SpriteRenderer>();
        BodyPlayerCharacter_ = GetComponent<Rigidbody2D>();
        PlayerCharcterTransform_ = GetComponent<Transform>();
    }

    
    void Update()
    {
        BodyPlayerCharacter_.velocity = new Vector2(Input.GetAxis("Horizontal") * MoveSpeed_, BodyPlayerCharacter_.velocity.y);
    }
}
