using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


namespace MoLiFrame.UI
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
           public UIInfoData(EnumUIType _uiType,string _path,params object[] _uiParams)
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


        /// <summary>
        /// 获取UI组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_uiType"></param>
        /// <returns></returns>
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


        public void OpenUI(EnumUIType[] _uiTypes)
        {
            OpenUI(false, _uiTypes, null);
        }


        public void OpenUI(EnumUIType _uiType,params object[] _uiParams)
        {
            EnumUIType[] _uiTypes = new EnumUIType[1] { _uiType };
            OpenUI(false, _uiTypes, _uiParams);
        }




        public void OpenUICloseOthers(EnumUIType[] _uiTypes)
        {
            OpenUI(true, _uiTypes, null);
        }


        public void OpenUICloseOthers(EnumUIType _uiType,params object[] _uiParams)
        {
            EnumUIType[] _uiTypes = new EnumUIType[1] { _uiType };
            OpenUI(true, _uiTypes, _uiParams);
        }


        /// <summary>
        /// 打开UI
        /// </summary>
        /// <param name="_isCloseOther"></param>
        /// <param name="_uiTypes"></param>
        /// <param name="_uiParams"></param>
        public void OpenUI(bool _isCloseOther,EnumUIType[] _uiTypes,params object[] _uiParams)
        {
            //Close Others UI.
            if(_isCloseOther)
            {

            }

            //Push _uiTypes in stack.
            for(int i = 0;i<_uiTypes.Length;i++)
            {
                EnumUIType _uiType = _uiTypes[i];
                if(!dicOpenUIs.ContainsKey(_uiType))
                {
                    string _path = UIPathDefines.GetPrefabsPathByType(_uiType);
                    stackOpenUIs.Push(new UIInfoData(_uiType,_path,_uiParams));
                } 
            }

            //Open UI
            if(stackOpenUIs.Count>0)
            {

            }

        }

    }

}