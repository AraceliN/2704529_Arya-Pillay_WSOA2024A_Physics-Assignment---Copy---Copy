using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerBlue: MonoBehaviour
{
    public float MaxPlayerSpeed;
    private Rigidbody2D RB;
    private Vector2 startPosition;

    public Rigidbody2D Puck;
    public Transform PlayerBoundaryHolder;
    private Boundary PlayerBoundary;

    public Transform PuckBoundaryHolder;
    private Boundary PuckBoundary;

    private Vector2 targetPosition;

    private bool firstTimeInOpponentHalf = true;
    private float offSetXFromTarget;

    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        startPosition = RB.position;

        PlayerBoundary = new Boundary(PlayerBoundaryHolder.GetChild(0).position.y,
                                      PlayerBoundaryHolder.GetChild(1).position.y,
                                      PlayerBoundaryHolder.GetChild(2).position.x,
                                      PlayerBoundaryHolder.GetChild(3).position.x);

        PuckBoundary = new Boundary(PuckBoundaryHolder.GetChild(0).position.y,
                                      PuckBoundaryHolder.GetChild(1).position.y,
                                      PuckBoundaryHolder.GetChild(2).position.x,
                                      PuckBoundaryHolder.GetChild(3).position.x);
    }

    private void FixedUpdate()
    {
        if (!PuckScript.WasGoal)
        {

            float MovementSpeed;

            if (Puck.position.y < PuckBoundary.Down)
            {
                if (firstTimeInOpponentHalf)
                {
                    firstTimeInOpponentHalf = false;
                    offSetXFromTarget = Random.Range(-1.2f, 1.2f);
                }
                MovementSpeed = MaxPlayerSpeed * Random.Range(0.1f, 0.3f);
                targetPosition = new Vector2(Mathf.Clamp(Puck.position.x + offSetXFromTarget, PlayerBoundary.Left, PlayerBoundary.Right), startPosition.y);
            }

            else
            {
                firstTimeInOpponentHalf = true;

                MovementSpeed = Random.Range(MaxPlayerSpeed * 0.4f, MaxPlayerSpeed);
                targetPosition = new Vector2(Mathf.Clamp(Puck.position.x, PlayerBoundary.Left, PlayerBoundary.Right),
                                             Mathf.Clamp(Puck.position.y, PlayerBoundary.Down, PlayerBoundary.Up));
            }

            RB.MovePosition(Vector2.MoveTowards(RB.position, targetPosition, MovementSpeed * Time.fixedDeltaTime));
        }
    }

    public void ResetPosition()
    {
        RB.position = startPosition;
    }
}

