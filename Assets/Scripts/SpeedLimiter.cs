using UnityEngine;
using System.Collections;

public class SpeedLimiter : MonoBehaviour
{
    [Range(1.0f, 100.0f)]
    public float
        maxSpeed = 25.0f;
    
    private Rigidbody2D rigidBody2D;
    private OneAxisMover mover;
    
    void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        mover = GetComponent<OneAxisMover>();
    }
	
    void FixedUpdate()
    {
        var velocity = rigidBody2D.velocity;
        switch (mover.moveAxis)
        {
            case AxisEnum.Horizontal:
                if (Mathf.Abs(velocity.x) > maxSpeed)
                {                    
                    rigidBody2D.velocity = Vector2.right * maxSpeed * Mathf.Sign(velocity.x);
                }
                break;
            case AxisEnum.Vertical:
                if (Mathf.Abs(velocity.y) > maxSpeed)
                {                    
                    rigidBody2D.velocity = Vector2.up * maxSpeed * Mathf.Sign(velocity.y);
                }
                break;
                
            default:
                break;
        }
    }
}
