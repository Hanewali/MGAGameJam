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
        //Debug.Log(SceneManager.GetActiveScene().name);
	    //Debug.Log(PlayerAnimator.Get);
	    if (OtherValues.State1)
	    {
            PlayerAnimator.SetBool("State1", true);
	        PlayerAnimator.SetBool("State2", false);
	        PlayerAnimator.SetBool("State3", false);
	        PlayerAnimator.SetBool("State4", false);
        }

	    if (OtherValues.State2)
	    {
	        PlayerAnimator.SetBool("State1", false);
	        PlayerAnimator.SetBool("State2", true);
	        PlayerAnimator.SetBool("State3", false);
	        PlayerAnimator.SetBool("State4", false);
        }

	    if (SceneManager.GetActiveScene().name == "AlbertHouse")
	    {
	        PlayerAnimator.SetBool("State1", false);
	        PlayerAnimator.SetBool("State2", false);
	        PlayerAnimator.SetBool("State3", true);
	        PlayerAnimator.SetBool("State4", false);
        }

	    if (OtherValues.State4)
	    {
	        PlayerAnimator.SetBool("State1", false);
	        PlayerAnimator.SetBool("State2", false);
	        PlayerAnimator.SetBool("State3", false);
	        PlayerAnimator.SetBool("State4", true);
        }
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
            OtherValues.State1 = false;
            OtherValues.State2 = true;
            OtherValues.State3 = false;
            OtherValues.State4 = false;
        }
        else if (trig.gameObject.name == "AlbertHouse")
        {
            SceneManager.LoadScene("AlbertHouse");
            OtherValues.State1 = false;
            OtherValues.State2 = false;
            OtherValues.State3 = true;
            OtherValues.State4 = false;
        }
        else if (trig.gameObject.name == "SinatraHouse")
        {
            SceneManager.LoadScene("SinatraHouse");
            OtherValues.State1 = false;
            OtherValues.State2 = false;
            OtherValues.State3 = false;
            OtherValues.State4 = true;
        }
        if (trig.gameObject.name == "Out")
        {
            SceneManager.LoadScene("Main");
            OtherValues.State1 = true;
            OtherValues.State2 = false;
            OtherValues.State3 = false;
            OtherValues.State4 = false;
        }
    }
}
