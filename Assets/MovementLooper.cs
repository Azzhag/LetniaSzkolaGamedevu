using UnityEngine;
using System.Collections;

[RequireComponent(typeof(OneAxisMover))]
public class MovementLooper : MonoBehaviour
{
    private OneAxisMover mover;

    void Awake()
    {
        mover = GetComponent<OneAxisMover>();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Finish")
        {
            var newPosition = transform.position;
            switch (mover.moveAxis)
            {
                case AxisEnum.Horizontal:
                    newPosition.x = -newPosition.x;
                    break;
                case AxisEnum.Vertical:
                    newPosition.y = -newPosition.y;
                    break;

                default:
                    break;
            }
            transform.position = newPosition;
        }
    }
}
