using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cmd_Wait : GameCommand
{
    public float duration;
    public override bool IsBlocking => true;
    public override void Execute(GameDirector director)
    {
        director.LogToConsole($"ÏµÍ³½«ÔÝÍ££º{duration}Ãë");
    }
}
