using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D Player;
    public Animator PlayerAnimator;
    private Vector2 _speed = new Vector2(10f, 10f);
    private float _horizontalInput;
    private float _verticalInput;

    // Use this for initialization
    void Start ()
	{
	    Player = GetComponent<Rigidbody2D>();
	    PlayerAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	     _horizontalInput = Input.GetAxis("Horizontal");
	     _verticalInput = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        Player.velocity = new Vector2(_speed.x * _horizontalInput, _speed.y * _verticalInput);
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.name == "FrankHouse")
        {
            SceneManager.LoadScene("FrankHouse");
        }
    }
}
