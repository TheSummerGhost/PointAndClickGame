using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
    public void RestartLevel() {

        if (GameManager.Instance != null)
        {
            Destroy(GameManager.Instance.gameObject);
        }
        if (InventoryManager.Instance != null)
        {
            Destroy(InventoryManager.Instance.gameObject);
        }
        SceneManager.LoadScene("FirstRoom");
    }
}
