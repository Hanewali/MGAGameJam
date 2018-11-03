using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{

    public static Text DialogueText1;
    public static Text DialogueText2;
    public static Text DialogueText3;
    public static GameObject Text1;
    public static GameObject Text2;
    public static GameObject Text3;

    //Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && DialogueText1.text == "Welcome!")
        {
            SetDialogToDefault();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && DialogueText1.text.Contains("Kupiec"))
        {
            DialogueText1.text = "1. Opowiedz o sobie";
            Text2.SetActive(false);
            Text3.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && DialogueText1.text.Contains("sobie"))
        {
            DialogueText1.text = "Pochodzę z zamożnej rodziny \r\nale sam nie mam wiele pieniędzy";
        }
    }

    public static void SetDialogToDefault()
    {
        Text1.SetActive(true);
        Text2.SetActive(true);
        Text3.SetActive(true);
        DialogueText1.text = "1. Kupiec";
        DialogueText2.text = "2. Klejnot";
        DialogueText3.text = "3. Rodzina";
    }

}

