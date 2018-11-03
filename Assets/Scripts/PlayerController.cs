using System.Collections;
using System.Collections.Generic;
using Assets.Additional_Scripts;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D Player;
    public Animator PlayerAnimator;
    public Rigidbody2D ShopKeeper;
    public GameObject DialogueCanvas;
    private Vector2 _speed = new Vector2(8f, 8f);
    private float _horizontalInput;
    private float _verticalInput;
    private float _distanceToShopKeeper;


    // Use this for initialization
    void Start ()
    {
        //ShopKeeper = GetComponent<Rigidbody2D>();
	    Player = GetComponent<Rigidbody2D>();
	    PlayerAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	     _horizontalInput = Input.GetAxis("Horizontal");
	     _verticalInput = Input.GetAxis("Vertical");
        Debug.Log(_distanceToShopKeeper);
        //Debug.Log(Mathf.Abs(Player.transform.position.x - ShopKeeper.transform.position.x));
        //Debug.Log(Mathf.Abs(Player.transform.position.y - ShopKeeper.transform.position.y));
	    if (_distanceToShopKeeper < 2.5 && Input.GetKeyDown(KeyCode.E))
	    {
            //TODO: Rozpoczęcie dialogu z ShopKeeperem
            DialogueCanvas.SetActive(!DialogueCanvas.activeSelf);
            Debug.Log("Dialogue Started!");
            
	    }
        else if (_distanceToShopKeeper > 2.5)
	    {
	        DialogueCanvas.SetActive(false);
            
	    }
	}

    void FixedUpdate()
    {
        Player.velocity = new Vector2(_speed.x * _horizontalInput, _speed.y * _verticalInput);
        _distanceToShopKeeper = AddMath.Pitagorem(Mathf.Abs(Player.transform.position.x - ShopKeeper.transform.position.x), Mathf.Abs(Player.transform.position.y - ShopKeeper.transform.position.y));
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.name == "FrankHouse")
        {
            SceneManager.LoadScene("FrankHouse");
        }
        else if (trig.gameObject.name == "AlbertHouse")
        {
            SceneManager.LoadScene("AlbertHouse");
        }
        else if (trig.gameObject.name == "SinatraHouse")
        {
            SceneManager.LoadScene("SinatraHouse");
        }
        if (trig.gameObject.name == "Out")
        {
            SceneManager.LoadScene("Main");
        }
    }
}
