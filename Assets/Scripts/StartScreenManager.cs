using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenManager : MonoBehaviour
{

    public void Start() 
    {
        if (GameManager.Instance != null)
        {
            Destroy(GameManager.Instance.gameObject);
        }
        if (InventoryManager.Instance != null)
        {
            Destroy(InventoryManager.Instance.gameObject);
        }
    }
    public void loadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
