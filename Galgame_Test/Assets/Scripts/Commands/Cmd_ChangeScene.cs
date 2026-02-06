using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cmd_ChangeScene : GameCommand
{
    public string imageName;
    public override bool IsBlocking => false;

    public override void Execute(GameDirector director)
    {
        Sprite newBg = Resources.Load<Sprite>(imageName);

        if(newBg == null)
        {
            Debug.LogError($"[Cmd_ChangeScene]:’“≤ªµΩÕº∆¨{imageName}");
            return;
        }
        director.sceneManager.ChangeScene(newBg);
    }
}
