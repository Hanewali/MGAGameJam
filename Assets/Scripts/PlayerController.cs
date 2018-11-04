using Assets.Additional_Scripts;
using UnityEngine;
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

    private Vector2 FrankFront = new Vector3(3f, 0f, 0f);
    private Vector2 AlbertFront = new Vector3(5f, 0f, 0f);
    private Vector2 SinatraFront = new Vector3(0f, 2f, 0f);

    public static int itemValue = 2000;


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
	    if (_distanceToShopKeeper < 2.5 && Input.GetKeyDown(KeyCode.E))
	    {
            DialogueCanvas.SetActive(!DialogueCanvas.activeSelf);
	        if (DialogueCanvas.activeSelf) FrankController.isTrue = true;
            else if (!DialogueCanvas.activeSelf) {FrankController.isTrue = false;}
	    }
        else if (_distanceToShopKeeper > 2.5)
	    {
	        DialogueCanvas.SetActive(false);
	        FrankController.isTrue = false;
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
            if (SceneManager.GetActiveScene().name == "FrankHouse")
            {
                SceneManager.LoadSceneAsync("Main");
                Player.transform.position = FrankFront;
            }

            else if (SceneManager.GetActiveScene().name == "SinatraHouse")
            {
                SceneManager.LoadScene("Main");
                Player.MovePosition(SinatraFront);
            }

            else if (SceneManager.GetActiveScene().name == "AlbertHouse")
            {
                SceneManager.LoadScene("Main");
                Player.MovePosition(AlbertFront);
            }
        }
    }
}
