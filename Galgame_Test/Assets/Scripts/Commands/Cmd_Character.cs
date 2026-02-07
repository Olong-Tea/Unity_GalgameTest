using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cmd_Character : GameCommand
{
    public string characterName; //角色文件
    public string position;
    public bool isShow; //是否显示

    public override bool IsBlocking => false;

    public override void Execute(GameDirector director)
    {
        CharacterManager.SlotType slot = 
            (CharacterManager.SlotType)System.Enum.Parse(typeof(CharacterManager.SlotType), position);

        if (isShow)
        {
            director.characterManager.ShowCharacter(characterName, slot);
        }
        else
        {
            director.characterManager.HideCharacter(slot);
        }

        director.LogToConsole($"[Cmd_Character]:立绘:{characterName}->{position}(显示:{isShow})");
    }
}
