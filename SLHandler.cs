using System.IO; 
using UnityEngine;
/// <summary>
/// Save Load Handler
/// </summary>
public static class SLHandler
{ 
    //Change this to where you want to save
    static string  path = Application.persistentDataPath + "\\" + "SaveFiles\\";
     
    /// <summary>
    /// Saves a json file to the path's location
    /// </summary>
    /// <typeparam name="T">Save type</typeparam>
    /// <param name="dataToSave">Value to save</param>
    /// <param name="saveName">Save file's name</param>
    public static void Save<T>(T dataToSave,string saveName)
    {
        string write=  JsonUtility.ToJson(dataToSave);
        try
        {
            //if a directory is missing than creat the missing path
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            File.WriteAllText(path+ saveName + ".json", write);
        }
        catch (IOException)
        {
            throw;
        }
    }

    /// <summary>
    /// Saves a json file to the path's location
    /// </summary>
    /// <typeparam name="T">Save type</typeparam>
    /// <param name="dataToSave">Value to save</param>
    /// <param name="saveName">Save file's name</param>
    /// <param name="exceptionMessage">Returns log messages</param>
    public static void Save<T>(T dataToSave, string saveName, out string exceptionMessage)
    {
        string write = JsonUtility.ToJson(dataToSave);
        try
        {
            //if a directory is missing than creat the missing path
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            File.WriteAllText(path + saveName + ".json", write);
            exceptionMessage = saveName + " saved successfully";
        }
        catch (IOException e)
        {
            exceptionMessage = e.Message;
        }
    }

    /// <summary>
    /// Loads a json file from the path's location
    /// </summary>
    /// <typeparam name="T">Load type</typeparam>
    /// <param name="defaultData">Default value in case of an error</param>
    /// <param name="saveName">Load file's name</param>
    /// <returns>Save data from file</returns>
    public static T Load<T>(T defaultData, string saveName)
    {
        try
        {
            T value = JsonUtility.FromJson<T>(
            File.ReadAllText(path + saveName + ".json"));
            return value;
        }
        catch (IOException)
        {
            return defaultData;
        }
    }

    /// <summary>
    /// Loads a json file from the path's location
    /// </summary>
    /// <typeparam name="T">Load type</typeparam>
    /// <param name="defaultData">Default value in case of an error</param>
    /// <param name="saveName">Load file's name</param>
    /// <param name="exceptionMessage">Returns log messages</param>
    /// <returns>Save data from file</returns>
    public static T Load<T>(T defaultData, string saveName,out string exceptionMessage)
    {
        try
        { 
            T value = JsonUtility.FromJson<T>(
            File.ReadAllText(path + saveName + ".json"));
            exceptionMessage = saveName+" Loaded SuccessFully";
            return value;
        }
        catch (IOException e)
        {
            exceptionMessage = e.Message;
            return defaultData;
        }
    }
    
    /// <summary>
    /// <br>Always be cautious when you delete files. Make sure everything is right when you decide to delete something.</br>
    /// <br>Deletes a json save file from the path's location</br>
    /// </summary>
    /// <param name="saveName">Name of the file which we want to delete</param>
    public static void DeleteSaveSlot(string saveName)
    {
        File.Delete(path + saveName + ".json");
    }
}
