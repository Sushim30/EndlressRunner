using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public enum Position { Left, Middle, Right };
    public float speed = 2f; // Default speed
    private Rigidbody rb;
    public Position playerLane = Position.Middle;

    private Vector2 startTouchPosition;
    private bool isSwiping = false;
    public float movingDistance = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Ensure Rigidbody is assigned if needed
    }

    private void PositionUpdate(int motion)
    {
        if (motion == 1) // Move Right
        {
            if (playerLane == Position.Middle)
            {
                transform.position = new Vector3(transform.position.x + movingDistance, transform.position.y, transform.position.z);
                playerLane = Position.Right;
            }
            else if (playerLane == Position.Left)
            {
                transform.position = new Vector3(transform.position.x + movingDistance, transform.position.y, transform.position.z);
                playerLane = Position.Middle;
            }
        }
        else if (motion == -1) // Move Left
        {
            if (playerLane == Position.Middle)
            {
                transform.position = new Vector3(transform.position.x - movingDistance, transform.position.y, transform.position.z);
                playerLane = Position.Left;
            }
            else if (playerLane == Position.Right)
            {
                transform.position = new Vector3(transform.position.x - movingDistance, transform.position.y, transform.position.z);
                playerLane = Position.Middle;
            }
        }
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startTouchPosition = touch.position;
                    isSwiping = true;
                    break;

                case TouchPhase.Moved:
                    if (isSwiping)
                    {
                        float deltaX = touch.position.x - startTouchPosition.x;
                        float deltaY = Mathf.Abs(touch.position.y - startTouchPosition.y);

                        if (Mathf.Abs(deltaX) > 50 && deltaY < 30) // Horizontal swipe only
                        {
                            PositionUpdate(deltaX > 0 ? 1 : -1);
                            isSwiping = false; // Prevent multiple detections
                        }
                    }
                    break;

                case TouchPhase.Ended:
                    isSwiping = false;
                    break;
            }
        }
    }
}
