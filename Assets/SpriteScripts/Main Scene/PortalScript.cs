using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    [SerializeField]
    private Transform destination;
    [SerializeField]
    private GameObject PortalCanvas;

    public bool isTeleporter1;
    public float distance = 0.5f;

    public ScoreScript scoreScript;

    private void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isTeleporter1 == false)
        {
            destination = GameObject.FindGameObjectWithTag("Teleporter 1").GetComponent<Transform>();
        }

        else if (isTeleporter1 == true)
        {
            destination = GameObject.FindGameObjectWithTag("Teleporter 2").GetComponent<Transform>();
        }


        if (Vector2.Distance(transform.position, other.transform.position) > distance)
        {
            other.transform.position = new Vector2(destination.position.x, destination.position.y);
        }
    }

}



