using UnityEngine;
using System.Collections;
using System;


namespace MoLiFrame
{

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



    public class Defines 
    {
       public Defines()
        {

        }
    }
}