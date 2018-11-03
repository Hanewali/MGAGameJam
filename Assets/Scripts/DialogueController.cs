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
    public GameObject Text1;
    public GameObject Text2;
    public GameObject Text3;
    public GameObject player;
    public GameObject ShopKeeper;
    public GameObject CanvaGameObject;
    private bool Greeting = false;

    //Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && DialogueText1.text == "Welcome!")
        {
            SetDialogToDefault();
            Greeting = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && DialogueText1.text.Contains("Kupiec"))
        {
            DialogueText1.text = "1. Opowiedz o sobie";
            Text2.SetActive(false);
            Text3.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && DialogueText1.text.Contains("sobie"))
        {
            DialogueText1.text = "Pochodzę z zamożnej rodziny ale sam nie mam wiele pieniędzy";
        }

        if (AddMath.Pitagorem(Mathf.Abs(player.transform.position.x - ShopKeeper.transform.position.x),
                Mathf.Abs(player.transform.position.y - ShopKeeper.transform.position.y)) > 2.5 && Greeting == true)
        {
            SetDialogToDefault();
        }

        if (Greeting == true && Input.GetKeyDown(KeyCode.E))
        {
            SetDialogToDefault();
        }
    }

    private void SetDialogToDefault()
    {
        Text1.SetActive(true);
        Text2.SetActive(true);
        Text3.SetActive(true);
        DialogueText1.text = "1. Kupiec";
        DialogueText2.text = "2. Klejnot";
        DialogueText3.text = "3. Rodzina";
    }

}
