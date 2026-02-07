using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public enum SlotType { Left, Center, Right,};

    [Header("组件")]
    [SerializeField] private Image slotLeft;
    [SerializeField] private Image slotCenter;
    [SerializeField] private Image slotRight;

    private Dictionary<SlotType, Image> slots; //辅助字典
    
    private void Awake()
    {
        slots = new Dictionary<SlotType, Image>{
            {SlotType.Left, slotLeft },
            {SlotType.Center, slotCenter },
            {SlotType.Right, slotRight }
        };
    }//初始化字典

    public void ShowCharacter(string characterName, SlotType slotType)
    {
        Image targetSlot = slots[slotType];
        Animator anim = targetSlot.GetComponentInParent<Animator>();

        Sprite charSprite = Resources.Load<Sprite>(characterName);

        if (charSprite == null )
        {
            Debug.LogError($"[CharacterManager]:找不到立绘：{characterName}");
            return;
        }

        targetSlot.sprite = charSprite;
        targetSlot.SetNativeSize();

        anim.SetBool("IsVisible", true);
    }

    /// <summary>
    /// 隐藏角色
    /// </summary>
    /// <param name="slotType"></param>
    public void HideCharacter(SlotType slotType)
    {
        Image targetSlot = slots[slotType];
        Animator anim = targetSlot.GetComponentInParent<Animator>();

        anim.SetBool("IsVisible", false);
    }
}
