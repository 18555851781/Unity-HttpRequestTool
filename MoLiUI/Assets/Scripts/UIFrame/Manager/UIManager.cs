using UnityEngine;
using System.Collections;
using System;


namespace MoLiFrame
{
    public class UIManager : Singleton<UIManager>
    {
        public override void Init()
        {
            
            Debug.Log("UIManager : Singleton<UIManager> Init");
        }


        public void Test()
        {
            Debug.Log("UIManager : Singleton<UIManager> Test");
        }
    }

}