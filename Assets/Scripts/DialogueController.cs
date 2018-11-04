using System.Collections;
using System.Collections.Generic;
using Assets.Additional_Scripts;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{

    public Text DialogueText1;
    public Text DialogueText2;
    public Text DialogueText3;
    public Text DialogueMain;
    public GameObject Text1;
    public GameObject Text2;
    public GameObject Text3;
    public GameObject player;
    public GameObject ShopKeeper;
    public GameObject CanvaGameObject;
    private bool Greeting;

    //Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && DialogueMain.text.Contains("Welcome"))
        {
            SetDialogToDefault();
            //Greeting = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && DialogueMain.text.Contains("hand"))
        {
            Text1.SetActive(true); 
            Text2.SetActive(true);
            Text3.SetActive(true);
            
            DialogueText1.text = "1. I found this little thing. I'm not sure if it's worth anything...";
            DialogueText2.text = "2. I found this in my backyard. How would you value that?";
            DialogueText3.text = "3. That's my lucky jewel. My grandma gave me it a long time ago...";
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && DialogueText3.text.Contains("lucky jewel"))
        {
            DialogueMain.text = "Well, it looks pretty nice, but...";
            Text1.SetActive(false);
            Text2.SetActive(false);
            Text3.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && DialogueText1.text.Contains("Shop"))
        {
            DialogueMain.text = "I come from a noble and wealthy family.\n\r I don't " +
                                "really care about what anyone has to say!";
            Text1.SetActive(false);
            Text2.SetActive(false);
            Text3.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            
            DialogueMain.text = "Huh? What's that in your hand?";
            Text1.SetActive(false);
            Text2.SetActive(false);
            Text3.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && DialogueMain.text.Contains("wealthy"))
        {
            SetDialogToDefault();
        } 
        
        if (AddMath.Pitagorem(Mathf.Abs(player.transform.position.x - ShopKeeper.transform.position.x),
                Mathf.Abs(player.transform.position.y - ShopKeeper.transform.position.y)) > 2.5/* && Greeting == true*/)
        {
            SetDialogToDefault();
        }

        if (/*Greeting == true && */Input.GetKeyDown(KeyCode.E) && CanvaGameObject.activeSelf==true)
        {
            SetDialogToDefault();
        }

    }

    private void SetDialogToDefault()
    {
        Text1.SetActive(true);
        Text2.SetActive(true);
        Text3.SetActive(true);
        DialogueText1.text = "1. Shopkeeper";
        DialogueText2.text = "2. Jewel";
        DialogueText3.text = "3. My Family";
        DialogueMain.text = string.Empty;
    }

}
