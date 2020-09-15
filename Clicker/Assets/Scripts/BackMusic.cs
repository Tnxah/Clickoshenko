using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class BackMusic : MonoBehaviour
{

    public static AudioSource aSource;
    // Start is called before the first frame update
    void Awake()
    {
        aSource = GetComponent<AudioSource>();
        GameObject[] obj = GameObject.FindGameObjectsWithTag("music");
        if (obj.Length > 1)
        {
            Debug.Log("already");
            Destroy(this.gameObject);
            return;
        }
        
        aSource.Play();
        DontDestroyOnLoad(aSource);

    }

    // Update is called once per frame
    void Update()
    {




        if (Application.loadedLevelName == "nonononon")
        {
            aSource.Stop();

        }
    }
}
