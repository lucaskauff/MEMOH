using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : MonoBehaviour
{
    public TextStock text;
    public PlayerMapMov player;

    public void TriggerText()
    {
        player.whereToGo = gameObject.transform;
        player.hasToMove = true;

        FindObjectOfType<MainMenuManager>().displayedText = gameObject;
        FindObjectOfType<MainMenuManager>().StartText(text);
    }
}