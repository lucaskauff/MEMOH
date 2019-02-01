using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public GameObject hUD;
    public Transform mindMap;
    public MemoriesManager memoMan;
    public GameObject player;
    bool open;

    private void Start()
    {
        ShowHUD();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!open)
            {
                ShowHUD();
            }
            else
            {
                HideHUD();
            }
        }
    }

    public void ShowHUD()
    {
        //Center on player's position
        mindMap.position = mindMap.position - player.transform.position;

        memoMan.hudOpened = true;
        hUD.SetActive(true);

        open = true;
    }

    public void HideHUD()
    {
        hUD.SetActive(false);
        open = false;
    }
}