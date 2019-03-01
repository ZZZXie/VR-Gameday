using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using HoloToolkit.Unity;

public class BaseSceneManager : Singleton<BaseSceneManager> {
    public bool chatEnabled = false;
	// Use this for initialization
	void Start () {
        SceneManager.LoadScene("Startup", LoadSceneMode.Additive);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
