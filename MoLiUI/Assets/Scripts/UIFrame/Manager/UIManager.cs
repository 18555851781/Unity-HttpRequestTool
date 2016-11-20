using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


namespace MoLiFrame
{
    public class UIManager : Singleton<UIManager>
    {
        /// <summary>
        /// UI参数的数据类
        /// </summary>
        class UIInfoData
        {
            public EnumUIType UIType
            {
                get;
                private set;
            }
            public string Path
            {
                get;
                private set;
            }
            public object[] UIparams
            {
                get;
                private set;
            }
            UIInfoData(EnumUIType _uiType,string _path,params object[] _uiParams)
            {
                this.UIType   = _uiType;
                this.Path     = _path;
                this.UIparams = _uiParams;
            }
        }

        /// <summary>
        /// 已经打开的UI集合
        /// </summary>
        private Dictionary<EnumUIType, GameObject> dicOpenUIs = null;

        /// <summary>
        /// 需要打开的UI
        /// </summary>
        private Stack<UIInfoData> stackOpenUIs = null;

        public override void Init()
        {
            dicOpenUIs   = new Dictionary<EnumUIType, GameObject>();
            stackOpenUIs = new Stack<UIInfoData>();
        }

        public T GetUI<T>(EnumUIType _uiType)where T :BaseUI
        {
            GameObject _retObj = GetUIObject(_uiType);
            if(null!=_retObj)
            {
              return _retObj.GetComponent<T>();
            }
            return null;
        }

        public GameObject GetUIObject(EnumUIType _uiType)
        {
            GameObject _retObj = null;
            if(!dicOpenUIs.TryGetValue(_uiType,out _retObj))
            {
                throw new Exception("_dicOpenUIs TryGetValue Failure! _uiType" + _uiType.ToString());
            }
            return _retObj;
        }
    }

}