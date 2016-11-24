using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using MoLiFrame.UI;

public class TestOne : BaseUI 
{
    private Button btn;
	// Use this for initialization
	void Start () 
    {
        btn = transform.Find("Panel/Button").GetComponent<Button>();
        btn.onClick.AddListener(OnClickBtn);
	}
	
    private void OnClickBtn()
    {
        UIManager.Instance.OpenUICloseOthers(EnumUIType.TestTwo);
        //GameObject   go = Instantiate<GameObject>(Resources.Load("Prefabs/TestTwo")as GameObject);
        //TestTwo testTwo = go.GetComponent<TestTwo>();
        //if(testTwo == null)
        //{
        //    testTwo = go.AddComponent<TestTwo>();
        //}
       // Close();
    }


    private void Close()
    {
        Destroy(this.gameObject);
    }



    public override EnumUIType GetUIType()
    {
        return EnumUIType.TestTwo;
    }
}
