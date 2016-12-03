using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace MoLiFrameWork.UI
{
    public class AssetInfo
    {
        private UnityEngine.Object _Object;
        public Type AssetType { get; set; }
        public string Path { get; set; }
        public bool IsLoaded
        {
            get
            {
                return null != _Object;
            }
            private set { }
        }


        public UnityEngine.Object AssetObject
        {
            get
            {
                if(null==_Object)
                {
                    return Resources.Load(Path);
                }
                return _Object;
            }
        }

        public IEnumerator GetAsyncObject(Action <UnityEngine.Object> _loaded)
        {

            return GetAsyncObject(_loaded, null);
        }

        public IEnumerator GetAsyncObject(Action<UnityEngine.Object> _loaded,Action<float> _progress)
        {
            if(null!=_Object)
            {
                _loaded(_Object);
                yield break;
            }

            ResourceRequest _resRequest = Resources.LoadAsync(Path);

            //
            while(_resRequest.progress<0.9f)
            {
                if (null != _progress)
                {
                    _progress(_resRequest.progress);
                }
                    yield return null;
                
            }

            //
            while(!_resRequest.isDone)
            {
                if(null!=_progress)
                {
                    _progress(_resRequest.progress);
                }
                yield return null;
            }


            //
            _Object = _resRequest.asset;
            if(null != _loaded)
            {
                _loaded(_Object);

            }
            yield return _resRequest;

        }

    }



    public class UIResManager : Singleton<UIResManager>
    {
        private Dictionary<string, AssetInfo> dicAssetInfo = null;



        public override void Init()
        {
            dicAssetInfo = new Dictionary<string, AssetInfo>();

            //Resources.LoadAsync();
        }
	
        public UnityEngine.Object LoadInstance(string _path)
        {
            UnityEngine.Object _retObj = null;
            UnityEngine.Object _obj    = Load(_path);
            if(null != _obj)
            {
                _retObj = MonoBehaviour.Instantiate(_obj);
                if (null != _retObj)
                {
                    return _retObj;
                }
                else
                {
                    Debug.LogError("Error: null Instance _retObj.");
                }
            }
            else
            {
                Debug.LogError("Error:null Resources Load return _obj");
            }
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
            if(string.IsNullOrEmpty(_path))
            {
                Debug.LogError("Error:null _path name");
                return null;
            }
            
            //Load Res ....
            UnityEngine.Object _retObj = null;

            return _retObj;
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