
using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;


namespace MoLiFrameWork.Util
{
    public class TextUtil
    {

        public static void CreateTextFile(string fileName, string path, string textValue)
        {
            StreamWriter streamWriter;

            FileInfo fileInfo = new FileInfo(path + "//" + fileName + ".txt");


            if (fileInfo.Exists)
            {
                streamWriter = fileInfo.AppendText();
            }
            else
            {
                streamWriter = fileInfo.CreateText();
            }
            streamWriter.WriteLine(textValue);
            streamWriter.Close();
            streamWriter.Dispose();
        }

        public static ArrayList LoadTextFile(string fileName, string path)
        {
            StreamReader streamReader = null;


            streamReader = File.OpenText(path + "//" + fileName + ".txt");


            string line;
            ArrayList arraylist = new ArrayList();
            while ((line = streamReader.ReadLine()) != null)
            {
                arraylist.Add(line);
            }
            streamReader.Close();
            streamReader.Dispose();
            return arraylist;
        }

        public static void DeleteTextFile(string fileName, string path)
        {

            FileInfo fileInfo = new FileInfo(path + "//" + fileName + ".txt");




            if (fileInfo.Exists)
            {
                File.Delete(path + "//" + fileName + ".txt");
            }
        }

        public static bool IsTextExits(string fileName, string path)
        {


            FileInfo fileInfo = new FileInfo(path + "//" + fileName + ".txt");




            if (fileInfo.Exists)
            {
                return true;
            }
            else
            {
                return false;
            }
        }




    }
}


