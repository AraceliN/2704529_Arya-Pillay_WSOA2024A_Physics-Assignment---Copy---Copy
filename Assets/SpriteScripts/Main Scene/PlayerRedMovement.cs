using UnityEngine;

public class PlayerRedMovement : MonoBehaviour
{
    bool justClicked = true;
    bool canMove;
    Rigidbody2D RB;

    Collider2D PlayerCollider;

    public Transform BoundaryHolder;

    Boundary playerBoundary;

    Vector2 startPosition;


    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        startPosition = RB.position;
        PlayerCollider = GetComponent<Collider2D>();

        playerBoundary = new Boundary(BoundaryHolder.GetChild(0).position.y,
                                      BoundaryHolder.GetChild(1).position.y,
                                      BoundaryHolder.GetChild(2).position.x,
                                      BoundaryHolder.GetChild(3).position.x);
    }


    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (justClicked)
            {
                justClicked = false;

                if (PlayerCollider.OverlapPoint(MousePosition))
                {
                    canMove = true;
                }
                else
                {
                    canMove = false;
                }

            }

            if (canMove)
            {
                Vector2 clampedMousePosition = new Vector2(Mathf.Clamp(MousePosition.x, playerBoundary.Left,
                                                           playerBoundary.Right),
                                                           Mathf.Clamp(MousePosition.y, playerBoundary.Down,
                                                           playerBoundary.Up));
                RB.MovePosition(clampedMousePosition);
            }
        }
        else
        {
            justClicked = true;
        }

    }

    public void ResetPosition()
    {
        RB.position = startPosition;
    }
}

