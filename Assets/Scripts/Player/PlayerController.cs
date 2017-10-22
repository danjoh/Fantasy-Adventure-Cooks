using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float moveSpeed;
    public Rigidbody2D rb;
    public bool move;

	// Use this for initialization
	void Start () {
        move = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (move)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    public void MovePartyRight()
    {
        move = true;
    }

    public void StopParty()
    {
        move = false;
    }
}
