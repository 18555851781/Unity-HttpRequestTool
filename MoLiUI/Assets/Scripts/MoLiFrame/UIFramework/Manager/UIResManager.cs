using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace MoLiFrameWork.UI
{
    public class UIResManager : Singleton<UIResManager>
    {
        private Dictionary<string, GameObject> dicAssetInfo =null;



        public override void Init()
        {
            dicAssetInfo = new Dictionary<string, GameObject>();
        }
	
        public GameObject LoadInstance(string _path)
        {



            return null;
        }


        public void LoadInstance(string _path, Action<UnityEngine.Object> _loaded)
        {
            LoadInstance(_path, _loaded, null);
        }


        public void LoadInstance(string _path, Action<UnityEngine.Object> _loaded, Action<float> progress)
        {
            Load(_path, (_obj) => {
                UnityEngine.Object _retObj = null;
                if(null!=_obj)
                {
                   _retObj = MonoBehaviour.Instantiate(_obj);
                    if(null!=_retObj)
                    {
                        if(null!=_loaded)
                        {
                            _loaded(_retObj);
                        }
                        else
                        {
                            Debug.LogError("Error:null _loaded.");
                        }
                    }
                    else
                    {
                        Debug.LogError("Error:null Instaniate _retObj.");
                    }
                }
                else
                {
                    Debug.LogError("Error:null Resources Load return _obj.");
                }  

            }, progress);

        }


         
        public UnityEngine.Object Load(string _path)
        {
            Load(_path, null,null);
            return null;
        }

        public void Load(string _path,Action<UnityEngine.Object> _loaded)
        {
            Load(_path, _loaded, null);
        }

        public void Load(string _path,Action<UnityEngine.Object> _loaded,Action<float> _progress)
        {
            if(string.IsNullOrEmpty(_path))
            {
                Debug.LogError("Error:null _path name.");
                if(null!=_loaded)
                {
                    _loaded(null);
                }
            }


            //资源加载工作


        }

    }
}