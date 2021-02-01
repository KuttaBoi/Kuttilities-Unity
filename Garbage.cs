using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : MonoBehaviour {

    public static Garbage instance = null;
    public List<GameObject> Bin = new List<GameObject>();

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

    public void Recycle(GameObject g)
    {
        Bin.Add(g);
        g.SetActive(false);
    }
    public void Restore(GameObject g)
    {
        Bin.Remove(g);
        g.SetActive(true);
    }
    public void EmptyBin()
    {
        foreach(GameObject g in Bin)
        {
            Destroy(g);
        }
        Bin.Clear();
    }
}
