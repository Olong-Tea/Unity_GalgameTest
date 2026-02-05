using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("组件")]
    [SerializeField] private GameDirector director;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI bodyText;
    [SerializeField] private Button fullScreenButton;

    [Header("参数")]
    [Range(0.01f, 0.5f)] public float speed = 0.05f;
    [SerializeField] private bool isSkip = false; //允许跳过文本
    [SerializeField] private bool isCompeleted = false; //文本显示完成

    private void Start()
    {
        //绑定全屏按钮时间
        if(fullScreenButton != null)
        {
            fullScreenButton.onClick.AddListener(() => OnScreenClicked());
        }
    }

    /// <summary>
    /// 显示对话和文字
    /// </summary>
    /// <param name="name">角色名称</param>
    /// <param name="body">对话内容</param>
    public void ShowDialogue(string name, string body)
    {
        nameText.text = name;
        //这里是打字机效果
        bodyText.text = body;
        StartCoroutine(TypeWriter());
    }

    /// <summary>
    /// 打字机效果协程
    /// </summary>
    /// <returns></returns>
    IEnumerator TypeWriter()
    {
        isCompeleted = false;
        isSkip = false;
        bodyText.ForceMeshUpdate();
        bodyText.maxVisibleCharacters = 0;
        int total = bodyText.textInfo.characterCount;
        int current = 0;
        while(current <= total)
        {
            bodyText.maxVisibleCharacters = current;
            current++;
            if (isSkip)
            {
                bodyText.maxVisibleCharacters = total;
                isCompeleted = true;
                Debug.Log("已跳过打印当前文本");
                yield break;
            }
            else
            {
                yield return new WaitForSeconds(speed);
            }
        }
        isCompeleted = true;
        Debug.Log("文本正常显示完成");
    }

    /// <summary>
    /// 屏幕点击事件
    /// </summary>
    void OnScreenClicked()
    {
        isSkip = true;
        if (isCompeleted)
        {
            //后续添加逻辑：当被其他界面遮挡时，不通知director
            director.ReceiveClickSignal();
        }
    }

    /// <summary>
    /// 清空对话框
    /// </summary>
    public void Clear()
    {
        nameText.text = "";
        bodyText.text = "";
    }
}
