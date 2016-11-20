using UnityEngine;
using System.Collections;

namespace MoLiFrame
{
    public class UIResManager : Singleton<UIResManager>
    {
        public override void Init()
        {
            
            Debug.Log(" UIResManager : Singleton<UIResManager> Init");
        }
	

        public void Test()
        {
            Debug.Log(" UIResManager : Singleton<UIResManager> Test");
        }
    }
}