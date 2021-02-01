using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class UndoHistory : MonoBehaviour
{
    [Range(0,50)]
    public int MaxBinSize = 10;

    [HideInInspector]
    public static UndoHistory instance = null;
    [HideInInspector]
    public List<Command> commandBuffer = new List<Command>();
    [HideInInspector]
    public List<Command> commandBin = new List<Command>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void AddCommand(Command com)
    {
        commandBuffer.Add(com);
        commandBin.Clear();
        Debug.Log("Added " + com.ToString() + " command.");
        if(commandBuffer.Count > MaxBinSize)
        {
            commandBuffer.RemoveAt(0);
        }
    }

    public void Undo()
    {
        Command undoCom = commandBuffer.Last();
        undoCom.Undo();
        Debug.Log("Undid " + undoCom.ToString() + " command.");
        commandBuffer.Remove(undoCom);
        commandBin.Add(undoCom);
        EventManager.TriggerEvent("TRIGGER_GUI_UPDATE");
    }
    public void Redo()
    {
        Command undoCom = commandBin.Last();
        undoCom.Undo();
        Debug.Log("Redid " + undoCom.ToString() + " command.");
        commandBin.Remove(undoCom);
        commandBuffer.Add(undoCom);
        EventManager.TriggerEvent("TRIGGER_GUI_UPDATE");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)&&commandBuffer.Count>0)
        {
            Undo();
        }
        if (Input.GetKeyDown(KeyCode.X) && commandBin.Count > 0)
        {
            Redo();
        }

    }
    private void CheckBinSize()
    {

    }


}

 