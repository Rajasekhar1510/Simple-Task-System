using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

[CreateAssetMenu(fileName = "NewNPCDialogue", menuName = "NPC DIALOGUE")]
public class NPCDialogue : ScriptableObject
{
    public string npcName;
    //public GameObject npcModel;
    public string[] dialogueLines;
    public bool[] autoProgressLines;
    public bool[] endDialogueLines;
    public float autoProgressDelay = 1.5f;
    public float typingSpeed = 0.05f;
    //public AudioClip voiceSound;
    // public float voicePitch = 1f;

    public DialogueChoice[] choices;

    public int questInProgressIndex;
    public int questCompletedIndex;
    public Tasks task;
}

[System.Serializable]
public class DialogueChoice
{
    public int DialogueIndex;
    public string[] choices;
    public int[] nextDialogueIndexes;
    public bool[] givesQuest;
}