using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RoleUI : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public RoleData roleData;

    public Image _avatarBackground;//修改移入背景图片颜色变化
    public Image _avatarImage;
    public Button _button;
    
    public PentagramRadar pentagramRadar;//属性五芒星
    public List<float> roleStatus;

    
    
    
    
    // Start is called before the first frame update
    private void Awake()
    {
        _avatarBackground = GetComponent<Image>();
        _avatarImage = transform.GetChild(0).GetComponent<Image>();
        _button = GetComponent<Button>();
        
        
    }
    

    public void SetData(RoleData data)
    {
        this.roleData = data;

        if (roleData.Unlock == 0)
        {
            _avatarImage.sprite=Resources.Load<Sprite>("Image/lock"); 
        }
        else
        {
            _avatarImage.sprite=Resources.Load<Sprite>(data.Avatar);
            SetStatus();
        }
        

        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _avatarBackground.color=new Color(200/255f,200/255f,200/255f);
        RenewUI(roleData.Unlock);
    }

    private void SetStatus()//不同的值直接对应
    {
        roleStatus.Add(roleData.Health);
        roleStatus.Add(roleData.Attack);
        roleStatus.Add(roleData.Defense);
        roleStatus.Add(roleData.Armor);
        roleStatus.Add(roleData.agility);
    }

    private void RenewUI(int Unlock)
    {
        if (Unlock == 0)
        {
            RoleSelectPanel.instance._avatarName.text = "???";
            RoleSelectPanel.instance._avatarImage.sprite = Resources.Load<Sprite>("Image/unlock");
            RoleSelectPanel.instance._avatarDescribe.text = roleData.UnlockConditions;
            RoleSelectPanel.instance._text3.text = "0";

            
            RoleSelectPanel.instance._attributeContent.SetActive(false);
            
        }
        else
        {
            RoleSelectPanel.instance._avatarName.text = roleData.Name;
            RoleSelectPanel.instance._avatarImage.sprite = _avatarImage.sprite;
            RoleSelectPanel.instance._avatarDescribe.text = roleData.Skill;
            RoleSelectPanel.instance._text3.text = roleData.Record.ToString();

            RoleSelectPanel.instance._attributeContent.SetActive(true);
            PentagramRadar p= GameObject.Find("五芒星").GetComponent<PentagramRadar>();
            p.DrawPentagram(roleStatus);
            ShowAttribute();
            
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _avatarBackground.color=new Color(1,1,1);
    }

    public void ShowAttribute()
    {
        RoleSelectPanel.instance._Health.text = roleData.Health.ToString();
        RoleSelectPanel.instance._Attack.text = roleData.Attack.ToString();
        RoleSelectPanel.instance._Defense.text = roleData.Defense.ToString();
        RoleSelectPanel.instance._Armor.text = roleData.Armor.ToString();
        RoleSelectPanel.instance._Agility.text=roleData.agility.ToString();
    }
}
