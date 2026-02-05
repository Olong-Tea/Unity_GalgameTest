using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cmd_WaitClick : GameCommand
{
    public override bool IsBlocking => true;
    public override void Execute(GameDirector director)
    {
        director.LogToConsole("µÈ´ýÍæ¼Òµã»÷ÆÁÄ»");
    }
}
