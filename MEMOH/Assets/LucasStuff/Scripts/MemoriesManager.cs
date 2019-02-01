using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MemoriesManager : MonoBehaviour
{
    [SerializeField]
    float letterSpeed = 0;

    Queue<string> sentences;

    public GameObject[] memories;
    public GameObject memoryText;
    public PlayerMapMov player;
    public GameObject eLetter;

    public GameObject selectedMemory;
    public GameObject memoryWithPlayer;

    public bool hudOpened = false;

    private void Start()
    {
        memories[0].GetComponent<MemoryTrigger>().memory.discovered = true;

        sentences = new Queue<string>();

        foreach (GameObject item in memories)
        {
            foreach (Image image in item.GetComponentsInChildren(typeof(Image)))
            {
                image.enabled = false;
            }
        }

        HideEletter();
    }

    private void Update()
    {
        foreach (GameObject item in memories)
        {
            if (item.GetComponent<MemoryTrigger>().memory.discovered  && !item.GetComponent<MemoryTrigger>().memory.yeppa)
            {
                item.GetComponent<MemoryTrigger>().memory.yeppa = true;
                NeuroneApparition(item);
            }
        }

        if (hudOpened)
        {
            selectedMemory = memoryWithPlayer;

            if (player.GetComponent<PlayerMapMov>().hasToMove)
            {
                return;
            }
            else
            {
                StartMemory(selectedMemory.GetComponent<MemoryTrigger>().memory);
                hudOpened = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            DisplayMemory();
        }
    }

    public void NeuroneApparition(GameObject neurone)
    {
        //ANIM APPARITION (OUPAS)
        foreach (Image image in neurone.GetComponentsInChildren(typeof(Image)))
        {
            image.enabled = true;
        }

        player.GetComponent<PlayerMapMov>().whereToGo = neurone.transform;
        player.GetComponent<PlayerMapMov>().hasToMove = true;
        memoryWithPlayer = neurone;
    }

    public void StartMemory(Memory memory)
    {
        memoryText.SetActive(true);

        sentences.Clear();

        foreach (string sentence in memory.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayMemory();
    }

    public void DisplayMemory()
    {
        HideEletter();

        if (sentences.Count == 0)
        {
            EndMemory();
            return;
        }

        string sentence = sentences.Dequeue();

        //memoryText.GetComponent<TextMeshProUGUI>().text = selectedMemory.GetComponent<MemoryTrigger>().memory.sentence;

        StopAllCoroutines();
        StartCoroutine(TypeMemory(sentence));
    }

    IEnumerator TypeMemory (string sentence)
    {
        memoryText.GetComponent<TextMeshProUGUI>().text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            memoryText.GetComponent<TextMeshProUGUI>().text += letter;
            yield return new WaitForSeconds(letterSpeed);
        }

        ShowEletter();
    }

    public void EndMemory()
    {
        memoryText.SetActive(false);
    }

    public void ShowEletter()
    {
        eLetter.SetActive(true);
    }

    public void HideEletter()
    {
        eLetter.SetActive(false);
    }
}