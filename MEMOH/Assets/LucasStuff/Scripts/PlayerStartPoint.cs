using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour
{
    public GameObject thePlayer;

    private void Start()
    {
        thePlayer.transform.position = transform.position;
    }
}