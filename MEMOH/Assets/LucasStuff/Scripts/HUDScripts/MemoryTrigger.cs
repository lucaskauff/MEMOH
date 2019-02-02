using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryTrigger : MonoBehaviour
{
    public Memory memory;

    public void TriggerMemory()
    {
        Debug.Log("clicked");
        FindObjectOfType<MemoriesManager>().StartMemory(memory);
    }
}