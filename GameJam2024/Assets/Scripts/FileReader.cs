using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileReader
{
    public static string ReadFile(string fileName)
    {
        string readData = "";
        string path;

        path = Application.dataPath;
        //Debug.Log(path);
        path = path.Substring(0, path.LastIndexOf("/"));
        //Debug.Log(path);
        path += "/Data";
       // Debug.Log(path);
        path += "/" + fileName + ".txt";

       // Debug.Log(path);

        readData = File.ReadAllText(path);

        //Debug.Log(readData);

        return readData;
    }
}
