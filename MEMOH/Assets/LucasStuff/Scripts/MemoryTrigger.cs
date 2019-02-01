using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryTrigger : MonoBehaviour
{
    public Memory memory;

    public void TriggerMemory()
    {
        FindObjectOfType<MemoriesManager>().selectedMemory = gameObject;
        FindObjectOfType<MemoriesManager>().StartMemory(memory);
    }
}