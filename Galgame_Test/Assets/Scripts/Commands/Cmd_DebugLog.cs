using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cmd_DebugLog : GameCommand
{
    public string message;
    public override bool IsBlocking => false;
    public override void Execute(GameDirector director)
    {
        director.LogToConsole(this.message);
    }
}
