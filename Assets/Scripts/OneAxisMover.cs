using UnityEngine;
using System.Collections;

public enum AxisEnum
{
    Horizontal,
    Vertical
}

public class OneAxisMover : MonoBehaviour
{
    public bool isMovedByPlayer;
    public AxisEnum moveAxis;
    public float moveForce = 10.0f;

    private Rigidbody2D rigidBody2D;

    void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveValue = GetMoveValue();
        switch (moveAxis)
        {
            case AxisEnum.Horizontal:
                Move(Vector2.right, moveValue);
                break;
            case AxisEnum.Vertical:
                Move(Vector2.up, moveValue);
                break;
            default:
                break;
        }
    }

    private float GetMoveValue()
    {
        if (isMovedByPlayer)
        {
            return Input.GetAxis(moveAxis.ToString());
        }
        else
        {
            return -1.0f;
        }
    }
    
    private void Move(Vector2 axis, float value)
    {
        rigidBody2D.AddForce(axis * value * moveForce);
    }
}
