using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrankController : MonoBehaviour
{

    public GameObject canv;
    public Animator FrankAnimator;
    public static bool isTrue;
	// Use this for initialization
	void Start ()
	{
	    FrankAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (isTrue) FrankAnimator.SetBool("IsTrue", true);
        else if(!isTrue) FrankAnimator.SetBool("IsTrue", false);
        Debug.Log(isTrue);
	}
}
