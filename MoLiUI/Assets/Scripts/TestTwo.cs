using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using MoLiFrameWork.UI;

public class TestTwo : BaseUI
{

    private Button btn;
    // Use this for initialization
    void Start()
    {
        btn = transform.Find("Panel/Button").GetComponent<Button>();
        btn.onClick.AddListener(OnClickBtn);
    }

    private void OnClickBtn()
    {

        UIManager.Instance.OpenUICloseOthers(EnumUIType.TestOne);
        //GameObject go = Instantiate<GameObject>(Resources.Load("Prefabs/TestOne") as GameObject);
        //TestOne testTwo = go.GetComponent<TestOne>();
        //if (testTwo == null)
        //{
        //    testTwo = go.AddComponent<TestOne>();
        //}
      //  Close();
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
