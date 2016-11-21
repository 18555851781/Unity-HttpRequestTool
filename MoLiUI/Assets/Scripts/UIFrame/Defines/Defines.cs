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



    public class UIPathDefines
    {
        /// <summary>
        /// UI预设
        /// </summary>
        public const string UI_PREFAB          = "Prefabs/";

        /// <summary>
        /// UI小控件预设
        /// </summary>
        public const string UI_CONTROLS_PREFAB = "UIPrefab/Control";

        /// <summary>
        /// UI子页面预设
        /// </summary>
        public const string UI_SUBUI_PREFAB    = "UIPrefab/SubUI/";

        /// <summary>
        /// icon路径
        /// </summary>
        public const string UI_ICON_PATH       = "UI/Icon";

        public static string GetPrefabsPathByType(EnumUIType _uiType)
        {
            string _path = string.Empty;
            switch(_uiType)
            {
                case EnumUIType.TestOne:
                    _path = UI_PREFAB + "TestOne";
                break;
                case EnumUIType.TestTwo:
                _path = UI_PREFAB + "TestTwo";
                break;
                default:
                Debug.Log("Not Find EnumUIType type: " + _uiType.ToString());
                break;
            }

            return _path;
        }

    }



    public class Defines :MonoBehaviour
    {

    }
}