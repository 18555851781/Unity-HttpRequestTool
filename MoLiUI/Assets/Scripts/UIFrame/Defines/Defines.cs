using UnityEngine;
using System.Collections;
using System;


namespace MoLiFrame.UI
{
    public delegate void StateChangedEvent(object sender, EnumObjectState newState, EnumObjectState oldState);

    //全局枚举对象
    public enum EnumObjectState
    {
        None,
        Initial,
        Loading,
        Ready,
        Disabled,
        Closing
    }

    public enum EnumUIType:int
    {
        None    = -1,
        TestOne =  0,
        TestTwo =  1
    }



    public class Defines :MonoBehaviour
    {

    }
}