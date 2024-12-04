using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoleSelectPanel : MonoBehaviour
{
    public static RoleSelectPanel instance;
    
    public List<RoleData> roledatas = new List<RoleData>();
    public TextAsset roleTextAsset;

    public Transform _roleList;
    public GameObject rolePrefab;
 
    public TextMeshProUGUI _avatarName;
    public TextMeshProUGUI _avatarDescribe;
    public TextMeshProUGUI _text3; //通关记录

    public Image _avatarImage;
    
    public TextMeshProUGUI _Health;
    public TextMeshProUGUI _Attack;
    public TextMeshProUGUI _Defense;
    public TextMeshProUGUI _Armor;
    public TextMeshProUGUI _Agility;
    public GameObject _attributeContent;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;

        _avatarName=GameObject.Find("Avatar_Name").GetComponent<TextMeshProUGUI>();
        _avatarDescribe=GameObject.Find("Avatar_Describe").GetComponent<TextMeshProUGUI>();
        _avatarImage=GameObject.Find("Avatar_Role").GetComponent<Image>();
        _text3=GameObject.Find("Text3").GetComponent<TextMeshProUGUI>();
        
        roleTextAsset=Resources.Load<TextAsset>("Data/role");
        roledatas=JsonConvert.DeserializeObject<List<RoleData>>(roleTextAsset.text);
        
        _attributeContent=GameObject.Find("AttributesContent");
        _Health = GameObject.Find("HP").GetComponent<TextMeshProUGUI>();
        _Attack = GameObject.Find("AT").GetComponent<TextMeshProUGUI>();
        _Defense = GameObject.Find("DE").GetComponent<TextMeshProUGUI>();
        _Armor = GameObject.Find("AR").GetComponent<TextMeshProUGUI>();
        _Agility = GameObject.Find("AG").GetComponent<TextMeshProUGUI>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (RoleData roleData in roledatas)
        {
            RoleUI r = Instantiate(rolePrefab, _roleList).GetComponent<RoleUI>();
            r.SetData(roleData);
        }
    }
    
}
