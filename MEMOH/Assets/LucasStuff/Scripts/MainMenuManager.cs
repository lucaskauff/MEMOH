using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    float letterSpeed = 0;

    public GameObject txtBox;
    public GameObject eLetter;
    public GameObject displayedText;

    Queue<string> sentences;

    private void Start()
    {
        sentences = new Queue<string>();
        HideEletter();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            DisplayNextSentence();
        }
    }

    public void StartText(TextStock text)
    {
        txtBox.SetActive(true);

        sentences.Clear();

        foreach (string sentence in text.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        HideEletter();

        if (sentences.Count == 0)
        {
            if (displayedText.name == "Play")
            {
                SceneManager.LoadScene("Room0");
            }

            EndMemory();
            return;
        }

        string sentence = sentences.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeText(sentence));
    }

    IEnumerator TypeText(string sentence)
    {
        txtBox.GetComponent<TextMeshProUGUI>().text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            txtBox.GetComponent<TextMeshProUGUI>().text += letter;
            yield return new WaitForSeconds(letterSpeed);
        }

        ShowEletter();
    }

    public void EndMemory()
    {
        txtBox.SetActive(false);
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