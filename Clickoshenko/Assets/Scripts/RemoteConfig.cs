using UnityEngine;
using Unity.RemoteConfig;
using System.Threading;

public class RemoteConfig : MonoBehaviour
{
    public struct userAttributes
    {
        // Optionally declare variables for any custom user attributes:
        public bool expansionFlag;
    }

    public struct appAttributes
    {
        // Optionally declare variables for any custom app attributes:
        public int level;
        public int score;
        public string appVersion;
    }

    // Optionally declare a unique assignmentId if you need it for tracking:
    public string assignmentId;

    // Declare any Settings variables you’ll want to configure remotely:
    public int enemyVolume;
    public float enemyHealth;
    public float enemyDamage;

    public string link;
    public string version;

    public bool newData = false;
    public bool finished = false;

    public static RemoteConfig instance;
    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        if (GameObject.FindGameObjectsWithTag("RemoteConfig").Length > 1)
        {
            Destroy(gameObject);
        }
        
        
        ConfigManager.FetchConfigs<userAttributes, appAttributes>(new userAttributes(), new appAttributes());
    }

    public void Start()
    {
        ConfigManager.FetchCompleted += ApplyRemoteSettings;
    }

    void ApplyRemoteSettings(ConfigResponse configResponse)
    {
        
        switch (configResponse.requestOrigin)
        {   
            case ConfigOrigin.Default:
                Debug.Log("No settings loaded this session; using default values.");
                break;
            case ConfigOrigin.Cached:
                Debug.Log("No settings loaded this session; using cached values from a previous session.");
                break;
            case ConfigOrigin.Remote:
                Debug.Log("New settings loaded this session; update values accordingly.");
                
                link = ConfigManager.appConfig.GetString("DownloadLink");
                version = ConfigManager.appConfig.GetString("NewestVersion");

                newData = true;
                break;
        }
        finished = true;
    }
    public bool IsNewVersion()
    {
        if (Application.version.CompareTo(version) < 0)
        {
            return true;
        }
        return false;
    }

    public string GetDownloadLink()
    {
        return link;
    }
}
