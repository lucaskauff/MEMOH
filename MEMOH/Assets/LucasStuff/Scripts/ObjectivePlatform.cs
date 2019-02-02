using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivePlatform : MonoBehaviour
{
    public HitPlatform selfHit;
    public GameObject[] iconPlatforms;
    public string nextLevelName;
    public GameObject roomMemory;
    public HUDManager hudMan;

    private void Update()
    {
        foreach (GameObject platform in iconPlatforms)
        {
            if (platform.GetComponent<HitPlatform>().hitted && selfHit.hitted)
            {
                EndOfRoom();
            }
        }
    }

    void EndOfRoom()
    {
        FindObjectOfType<LoadNewScene>().LoadNewLevel(nextLevelName);
        roomMemory.GetComponent<MemoryTrigger>().memory.discovered = true;
        hudMan.ShowHUD();
    }
}