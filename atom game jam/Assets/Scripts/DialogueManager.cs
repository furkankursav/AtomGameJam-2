using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text name, dialogueText;
    public Animator anim;
    AudioSource audioSource;

    private Queue<string> sentences;

    private void Start()
    {
        sentences = new Queue<string>();
        audioSource = GetComponent<AudioSource>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting convervation with " + dialogue.name);
        name.text = dialogue.name;
        anim.SetBool("IsOpen", true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<SideScrollerMovement>().StopPlayer();

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        Debug.Log("butona tıklandı");

    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        audioSource.Play();
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
        audioSource.Stop();
    }

    void EndDialogue()
    {
        Debug.Log("End of conservation");
        anim.SetBool("IsOpen", false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<SideScrollerMovement>().ResetPlayer();

    }
}
