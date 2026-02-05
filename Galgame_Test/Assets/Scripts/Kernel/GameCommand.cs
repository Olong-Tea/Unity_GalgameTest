using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class GameCommand
{
    /// <summary>
    /// 是否阻塞命令
    /// </summary>
    public abstract bool IsBlocking { get; }
    /// <summary>
    /// 被执行的命令
    /// </summary>
    /// <param name="director"></param>
    public abstract void Execute(GameDirector director);
}
