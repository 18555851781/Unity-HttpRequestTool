using UnityEngine;
using System.Collections;
using System;



namespace MoLiFrame
{
    public class SingletonException : Exception
    {
        public SingletonException(string msg)
            : base(msg)
        {

        }

    }
}