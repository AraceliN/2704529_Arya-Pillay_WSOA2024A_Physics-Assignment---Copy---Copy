using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Transactions;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PuckScript : MonoBehaviour
{
    public ScoreScript ScoreScriptInstance;
    public static bool WasGoal { get; private set; }
    public static bool puckHitTwice = false;
    public ScoreScript ScoreScript;

    public static bool WasRegion { get; private set; }

    [SerializeField]
    private TextMeshProUGUI BluePlayerText;
    [SerializeField]
    private TextMeshProUGUI RedPlayerText;

    private int bluePlayerScore, redPlayerScore;

    private Rigidbody2D RB;

    public float MaximumSpeed;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        WasGoal = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!WasGoal)
        {
            if (other.tag == "BluePlayerGoal")
            {
                ScoreScriptInstance.Increment(ScoreScript.Score.RedPlayerScore);
                WasGoal = true;
                StartCoroutine(ResetPuck());
            }

            else if (other.tag == "RedPlayerGoal")
            {
                ScoreScriptInstance.Increment(ScoreScript.Score.BluePlayerScore);
                WasGoal = true;
                StartCoroutine(ResetPuck());
            }
        }
    }

    private IEnumerator ResetPuck()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        WasGoal = false;
        RB.velocity = RB.position = new Vector2(0, 0);
    }

    public void CentrePuck()
    {
        RB.position = new Vector2 (0, 0);
    }

    private void FixedUpdate()
    {
        RB.velocity = Vector2.ClampMagnitude (RB.velocity, MaximumSpeed);
    }
}


