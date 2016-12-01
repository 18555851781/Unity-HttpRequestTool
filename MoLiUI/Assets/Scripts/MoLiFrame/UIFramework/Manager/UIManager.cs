using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


namespace MoLiFrameWork.UI
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

            public Type ScriptType
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
                this.UIType     = _uiType;
                this.Path       = _path;
                this.UIparams   = _uiParams;
                this.ScriptType = UIPathDefines.GetUIScriptByType(this.UIType);
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


        /// <summary>
        /// 预加载多个UI
        /// </summary>
        /// <param name="_uiTypes"></param>
        public void PreloadUI(EnumUIType[] _uiTypes)
        {
            for(int i = 0; i<_uiTypes.Length;i++)
            {
                PreloadUI(_uiTypes[i]);
            }
        }


        /// <summary>
        /// 预加载UI
        /// </summary>
        /// <param name="_uiType"></param>
        public void PreloadUI(EnumUIType _uiType)
        {
            string path = UIPathDefines.GetPrefabsPathByType(_uiType);
            Resources.Load(path);
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
                CloseUIAll();
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

            //Open UI,协程加载UI.
            if(stackOpenUIs.Count>0)
            {
                CoroutineController.Instance.StartCoroutine(AsyncLoadData());
            }
        }

        /// <summary>
        /// 异步加载数据
        /// </summary>
        /// <returns>加载的数据</returns>
        private IEnumerator<int> AsyncLoadData()
        {
            UIInfoData _uiInfoData     = null;
            UnityEngine.Object _prefabObj = null;
            GameObject _uiObject       = null;

            if(stackOpenUIs!=null&&stackOpenUIs.Count>0)
            {
                do
                {
                    _uiInfoData = stackOpenUIs.Pop();
                    _prefabObj = Resources.Load(_uiInfoData.Path);
                    if(_prefabObj!=null)
                    {
                        //_uiObject = NGUITools.AddChild(Game.Instance.mainUICamera.gameObject,_prefabObject);
                        _uiObject = MonoBehaviour.Instantiate(_prefabObj) as GameObject;
                        BaseUI _baseUI = _uiObject.GetComponent<BaseUI>();
                        if(null == _baseUI)
                        {
                            _baseUI = _uiObject.AddComponent(_uiInfoData.ScriptType) as BaseUI;
                        }

                        if(null!=_baseUI)
                        {
                            _baseUI.SetUIWhenOpening(_uiInfoData.UIparams);
                        }
                        dicOpenUIs.Add(_uiInfoData.UIType, _uiObject);        
                    }

                } while (stackOpenUIs.Count > 0);

            }
            yield return 0;
        }

        /// <summary>
        /// 关闭UI
        /// </summary>
        /// <param name="_uiType"></param>
        public void CloseUI(EnumUIType _uiType)
        {
            GameObject _uiObj = GetUIObject(_uiType);
            if(null  == _uiObj)
            {
                dicOpenUIs.Remove(_uiType);
            }
            else
            {
                BaseUI _baseUI = _uiObj.GetComponent<BaseUI>();
                if(null == _baseUI)
                {
                    GameObject.Destroy(_uiObj);
                    dicOpenUIs.Remove(_uiType);
                }
                else
                {
                    _baseUI.StateChanged += CloseUIHandle;
                    _baseUI.Release();
                }
            }
        }

        /// <summary>
        /// 关闭所有UI
        /// </summary>
        public void CloseUIAll()
        {
            List<EnumUIType> _listKey = new List<EnumUIType>(dicOpenUIs.Keys);
            for(int i = 0 ; i<_listKey.Count;i++)
            {
                CloseUI(_listKey[i]);
            }

           // CloseUI(_listKey.ToArray());
            dicOpenUIs.Clear();
        }

        /// <summary>
        /// 关闭UI
        /// </summary>
        /// <param name="_uiTypes"></param>
        public void CloseUI(EnumUIType[] _uiTypes)
        {
            for(int i = 0; i<_uiTypes.Length;i++)
            {
                CloseUI(_uiTypes[i]);
            }
        }

        /// <summary>
        /// 关闭UI时启动的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="newState"></param>
        /// <param name="oldState"></param>
        private void CloseUIHandle(object sender, EnumObjectState newState, EnumObjectState oldState)
        {
            if(newState == EnumObjectState.Closing)
            {
                BaseUI _baseUI = sender as BaseUI;
                dicOpenUIs.Remove(_baseUI.GetUIType());
                _baseUI.StateChanged -= CloseUIHandle;
            }
        }

    }

}