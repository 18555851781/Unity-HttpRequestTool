using UnityEngine;
using System.Collections;


namespace MoLiFrame
{
    public class BaseUI : MonoBehaviour 
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


        void Start()
        {

        }
	
	   
	    void Update () 
        {
	
	    }
    }
}