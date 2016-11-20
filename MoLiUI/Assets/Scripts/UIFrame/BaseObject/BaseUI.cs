using UnityEngine;
using System.Collections;


namespace MoLiFrame.UI
{
    public abstract class BaseUI : MonoBehaviour 
    {
        private GameObject _cacheGameObject;
        public GameObject CacheGameObject
        {
            get
            {
                if(null == _cacheGameObject)
                {
                    _cacheGameObject = this.gameObject;
                }
                return _cacheGameObject;
            }
        }

        private Transform _cacheTransform;
        public Transform CacheTransform
        {
            get 
            { 
                if(null == _cacheTransform)
                {
                    _cacheTransform = this.transform;
                }
                return _cacheTransform; 
            }
        }

        protected EnumObjectState state = EnumObjectState.None;
        public MoLiFrame.UI.EnumObjectState State
        {
            get { return this.state; }
            set 
            {
                if(value!=state)
                {
                    EnumObjectState oldState = state;
                    state = value;
                    if(null!=StateChanged)
                    {
                        StateChanged(this, state, oldState);
                    }
                }
            }
        }


        public event StateChangedEvent StateChanged;



        public abstract EnumUIType GetUIType();

        protected virtual void SetDepthToTop()
        {

        }

        void Awake()
        {
            this.State = EnumObjectState.Initial;
            OnAwake();
        }

        void Start()
        {
            OnStart();
        }
	 
	    void Update () 
        {
            if (EnumObjectState.Ready == this.state)
            {
                OnUpdate(Time.deltaTime);
            }
	    }

        public void Release()
        {
            this.State = EnumObjectState.Closing;
            GameObject.Destroy(CacheGameObject);
            OnRelease();
        }

        protected virtual void OnStart()
        {

        }

        protected virtual void OnAwake()
        {
            this.State = EnumObjectState.Loading;
            //播放音乐
            this.OnPlayOpenUIAudio();
        }

        protected virtual void OnUpdate(float deltaTime)
        {

        }

        protected virtual void OnRelease()
        {
            this.OnPlayCloseUIAudio();
        }


        /// <summary>
        /// 播放打开界面音乐
        /// </summary>
        protected virtual void OnPlayOpenUIAudio()
        {

        }

        /// <summary>
        /// 播放关闭界面音乐
        /// </summary>
        protected virtual void OnPlayCloseUIAudio()
        {

        }

        protected virtual void SetUI(params object[] uiParams)
        {
            this.State = EnumObjectState.Loading;
        }

        public virtual void SetUIparam(params object[] uiParams)
        {

        }


        protected virtual void OnLoadData()
        {

        }

        public void SetUIWhenOpening(params object[] uiParams)
        {
            SetUI(uiParams);
            StartCoroutine(AsyncOnLoadData());
        }

        private IEnumerator AsyncOnLoadData()
        {
            yield return new WaitForSeconds(0);
            if (this.State == EnumObjectState.Loading)
            {
                this.OnLoadData();
                this.State = EnumObjectState.Ready;
            }
        }

    }
}