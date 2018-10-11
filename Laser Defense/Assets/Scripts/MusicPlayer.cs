using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
    void Awake()
    {
        PlayMusicSingleton();
    }

    private void PlayMusicSingleton()
    {
        // finds the type of this object only, more generic
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }


        /* Gets named type, in this case music player
         * 
        int gameStatusCount = FindObjectsOfType<MusicPlayer>().Length;
        if (gameStatusCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
        */
    }


}
