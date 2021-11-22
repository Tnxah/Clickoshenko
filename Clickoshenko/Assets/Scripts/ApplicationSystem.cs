using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplicationSystem : MonoBehaviour
{
    public static ApplicationSystem instance;
    public delegate void Quit();
    public Quit onQuitPause;
    Dictionary<string, string> map = new Dictionary<string, string> { {"SampleScene","Main Menu"},
                                                                      {"Main Menu","Exit"} };


    void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("ApplicationSystem").Length > 1)
        {
            Destroy(this.gameObject);
        }

        if (instance == null)
        {
            instance = this;
        }

        DontDestroyOnLoad(this);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadScene(map[SceneManager.GetActiveScene().name]);
        }
    }

    void OnApplicationQuit()
    {
        onQuitPause?.Invoke();
    }

    void OnApplicationPause()
    {
        onQuitPause?.Invoke();
    }


    void LoadScene(string scene)
    {
        if (scene == "Exit")
        {
            Application.Quit();
        }
        else
        {
            SceneManager.LoadScene(scene);
        }
    }
}
