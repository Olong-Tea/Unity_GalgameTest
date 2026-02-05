using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cmd_ShowText : GameCommand
{
    public string characterName;
    public string dialogueContent;

    public override bool IsBlocking => true;
    public override void Execute(GameDirector director)
    {
        director.uiManager.ShowDialogue(characterName, dialogueContent);

        director.LogToConsole($"œ‘ æ∂‘ª∞£∫[{characterName}]:{dialogueContent}");
    }
}
