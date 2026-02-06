using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    [Header("组件")]
    [SerializeField] private Image bgBack;
    [SerializeField] private Image bgFront;
    [SerializeField] private Animator animator;

    [Header("参数")]
    [SerializeField] private bool isSwitching = false;

    public void ChangeScene(Sprite newSprite, string transitionName = "CrossFade")
    {
        if (isSwitching) return; //如果正在切换，则拒绝此次切换
        isSwitching = true;

        bgFront.sprite = newSprite; //将要切换的图片交给前景
        animator.SetTrigger(transitionName); //播放动画
    }

    public void OnTransitionComplete()
    {
        bgBack.sprite = bgFront.sprite; //将要切换的图传递给背景
        animator.Play("Idle"); //回到Idle状态
        isSwitching = false;
        Debug.Log("[SceneManager]:场景图片切换完成");
    }
}