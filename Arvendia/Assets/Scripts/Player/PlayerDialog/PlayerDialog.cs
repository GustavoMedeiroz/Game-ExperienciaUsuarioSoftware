using System;
using UnityEngine;

public enum TypeDialog
{
    normal,
    puzzleQuest,
    jigsawQuest,
}

[CreateAssetMenu(fileName = "PlayerDialog", menuName = "Player Dialog")]
public class PlayerDialog : ScriptableObject
{

    [Header("Config")]
    public TypeDialog type;

    [Header("Info")]
    public new string name;
    public Sprite Icon;

    [Header("Dialogue")]
    [TextArea] public String Dialogue;
}