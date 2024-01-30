using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Dictionary<string, bool> itemsInWorld = new Dictionary<string, bool>();
    // Start is called before the first frame update

    public void AddToDictionary(string id, bool state) 
    {
        if (itemsInWorld.ContainsKey(id))
        {
            Debug.Log("This is already in the dictionary");
        } else
        {
            itemsInWorld.Add(id, state);
        }
    }

    public bool CheckInDictionary(string id)
    {
        return(itemsInWorld.ContainsKey(id));
    }

    public void SetState(string id, bool state)
    {
        if (CheckInDictionary(id))
        {
            itemsInWorld[id] = state;
        }
    }

    public bool GetState(string id)
    {
        if(itemsInWorld.TryGetValue(id, out bool state))
        {
            return state;
        } 
        return false;
    }
    // Update is called once per frame
    public static GameManager Instance { get; private set; }
    private void Awake() 
    { 

        if (Instance != null && Instance != this) 
        { 
            Destroy(this.gameObject); 
        } else 
        { 
            DontDestroyOnLoad(this.gameObject);
            Instance = this; 
        } 
    }
}
