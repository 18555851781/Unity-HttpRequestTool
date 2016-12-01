using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace MoLiFrameWork.Util
{
    public class SaveKeyUtil
    {

        /*
        public static void CheckHasToogleValue(string keyName, Switch switchToogle)
        {
            if (!PlayerPrefs.HasKey(keyName))
            {
                PlayerPrefs.SetInt(keyName, 1);
                switchToogle.isOn = true;
                Debug.Log("不存在：" + keyName);
            }
            else
            {
                if (PlayerPrefs.GetInt(keyName) == 1)
                {
                    switchToogle.isOn = true;
                }
                else
                {
                    switchToogle.isOn = false;
                }
            }
            PlayerPrefs.Save();
        }

        public static void SaveSetting(bool isPlay, string keyName)
        {
            if (isPlay)
            {
                PlayerPrefs.SetInt(keyName, 1);
            }
            else
            {
                PlayerPrefs.SetInt(keyName, 0);
            }
            PlayerPrefs.Save();
        }


        public static bool GetSetting(string keyName)
        {
            if (!PlayerPrefs.HasKey(keyName))
            {
                PlayerPrefs.SetInt(keyName, 1);
                PlayerPrefs.Save();
                return true;
            }
            else
            {
                if (PlayerPrefs.GetInt(keyName) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }*/

    }
}
