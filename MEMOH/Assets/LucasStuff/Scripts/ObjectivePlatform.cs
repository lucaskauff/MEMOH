using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivePlatform : MonoBehaviour
{
    public HitPlatform hitPlat;
    public MemoriesManager memoMan;
    public GameObject roomMemory;
    public HUDManager hudMan;
    bool check = false;

    private void Update()
    {
        if (hitPlat.hitted && !check)
        {
            EndOfRoom();
        }
    }

    void EndOfRoom()
    {
        roomMemory.GetComponent<MemoryTrigger>().memory.discovered = true;
        hudMan.SendMessage("ShowHUD");
        check = true;
    }
}