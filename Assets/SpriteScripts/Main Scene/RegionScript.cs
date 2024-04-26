using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Transactions;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RegionScript : MonoBehaviour
{

    public static bool WasRegion {  get; private set; }
    public PuckScript puckscript;



    [SerializeField]
    private TextMeshProUGUI BluePlayerText;
    [SerializeField]
    private TextMeshProUGUI RedPlayerText;

    public void FixedUpdate()
    {
        
    }
}
