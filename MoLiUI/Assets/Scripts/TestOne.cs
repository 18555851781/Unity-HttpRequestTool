using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TestOne : MonoBehaviour 
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
        GameObject   go = Instantiate<GameObject>(Resources.Load("Prefabs/TestTwo")as GameObject);
        TestTwo testTwo = go.GetComponent<TestTwo>();
        if(testTwo == null)
        {
            testTwo = go.AddComponent<TestTwo>();
        }
        Close();
    }


    private void Close()
    {
        Destroy(this.gameObject);
    }


}
