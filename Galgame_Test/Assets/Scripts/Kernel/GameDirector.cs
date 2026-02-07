using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    #region 单例实现
    /// <summary>
    /// GD的单例模式
    /// </summary>
    public static GameDirector Instance {  get; private set; }
    //初始化
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
        }
    }
    #endregion

    [Header("组件")]
    public UIManager uiManager;
    public SceneManager sceneManager;
    public CharacterManager characterManager;

    [Header("命令列表")]
    private List<GameCommand> commands = new List<GameCommand>();

    [Header("参数")]
    [SerializeField] private int commadIndex = 0; //程序计数器
    [SerializeField] private bool playerClicked = false; //点击信号

    private void Start()
    {
        //存入测试数据
        commands.Add(new Cmd_DebugLog { message = "=== 游戏开始 ===" });

        // 第一句：不需要等待点击，直接显示（通常用于独白或画外音）
        // 注意：如果我们想让它等待，IsBlocking 必须是 true。
        commands.Add(new Cmd_ShowText { characterName = "旁白", dialogueContent = "这是一个明媚的早晨。" });

        // 这里其实有一个逻辑点：Cmd_ShowText 本身是阻塞的 (IsBlocking=true)。
        // 所以执行完上一句，CPU 会自动停下，等待点击。

        commands.Add(new Cmd_ShowText { characterName = "小明", dialogueContent = "哎呀！要迟到了！" });

        commands.Add(new Cmd_ShowText { characterName = "老师", dialogueContent = "那位同学，站住。" });

        commands.Add(new Cmd_ShowText { characterName = "旁白", dialogueContent = "我在学校门口。" });

        // 触发切换：换成 B 图
        // 因为是非阻塞，这行执行完瞬间会执行下一行
        commands.Add(new Cmd_ChangeScene { imageName = "Textures/Backgrounds/街_通学路C" });

        commands.Add(new Cmd_ShowText { characterName = "旁白", dialogueContent = "背景应该正在慢慢变成 B 图..." });

        commands.Add(new Cmd_ShowText { characterName = "旁白", dialogueContent = "这时，一个人影走了过来。" });

        // 【新增】中间出现立绘
        commands.Add(new Cmd_Character
        {
            characterName = "Textures/Characters/茉子a_0_1892",
            position = "Center",
            isShow = true
        });

        commands.Add(new Cmd_ShowText { characterName = "神秘少女", dialogueContent = "你好，初次见面。" });

        // 【新增】立绘消失
        commands.Add(new Cmd_Character
        {
            characterName = "Textures/Characters/茉子a_0_1892",
            position = "Center",
            isShow = false
        });

        commands.Add(new Cmd_ShowText { characterName = "旁白", dialogueContent = "她转身离开了。" });

        StartCoroutine(ExecuteLoop());
    }

    /// <summary>
    /// 读取指令
    /// </summary>
    /// <returns></returns>
    private IEnumerator ExecuteLoop()
    {
        while (commadIndex < commands.Count)
        {
            //A.取指令
            GameCommand currentCmd = commands[commadIndex];
            //B.执行指令
            currentCmd.Execute(this);
            //C.判断是否阻塞
            if (currentCmd.IsBlocking)
            {
                playerClicked = false;
                LogToConsole("进入阻塞，等待输入");
                yield return new WaitUntil(() => playerClicked);
            }
            //D.程序计数器前进
            commadIndex++;
        }
        Debug.Log("脚本执行完毕");
    }

    /// <summary>
    /// 接收来自UIManager的屏幕点击指令
    /// </summary>
    public void ReceiveClickSignal()
    {
        playerClicked = true;
        Debug.Log("收到点击,阻塞被取消");
    }

    /// <summary>
    /// 日志打印
    /// </summary>
    /// <param name="message"></param>
    public void LogToConsole(string message)
    {
        Debug.Log($"[GameDirector]: {message}");
    }
}
