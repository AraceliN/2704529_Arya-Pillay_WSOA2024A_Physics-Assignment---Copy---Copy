using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public enum Score
    {
        BluePlayerScore, RedPlayerScore
    }
    
    [SerializeField]
    private TextMeshProUGUI BluePlayerText;
    [SerializeField]
    private TextMeshProUGUI RedPlayerText;

    private int bluePlayerScore, redPlayerScore;

    public int MaximumScore;
    public UIManager uiManager;

    private int BluePlayerScore
    {
        get { return bluePlayerScore; }
        set
        {
            bluePlayerScore = value;
            if (value == MaximumScore)
                uiManager.ShowReStartCanvas(true);
        }
    }
    private int RedPlayerScore
    {
        get { return redPlayerScore; }
        set
        {
            redPlayerScore = value;
            if (value == MaximumScore)
                uiManager.ShowReStartCanvas(false);
        }
    }
    public void Increment(Score whichScore)
    {
        if(whichScore == Score.BluePlayerScore)
            BluePlayerText.text = (++BluePlayerScore).ToString();

        else
            RedPlayerText.text = (++RedPlayerScore).ToString();
    }

    public void ResetScore()
    {
        BluePlayerScore = RedPlayerScore = 0;
        BluePlayerText.text = RedPlayerText.text = "0";
    }
}

