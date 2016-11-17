using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TestTwo : MonoBehaviour {

    private Button btn;
    // Use this for initialization
    void Start()
    {
        btn = transform.Find("Panel/Button").GetComponent<Button>();
        btn.onClick.AddListener(OnClickBtn);
    }

    private void OnClickBtn()
    {
        GameObject go = Instantiate<GameObject>(Resources.Load("Prefabs/TestOne") as GameObject);
        TestOne testTwo = go.GetComponent<TestOne>();
        if (testTwo == null)
        {
            testTwo = go.AddComponent<TestOne>();
        }
        Close();
    }


    private void Close()
    {
        Destroy(this.gameObject);
    }

}
