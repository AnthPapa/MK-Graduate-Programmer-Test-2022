using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    static MusicScript music;
    // Start is called before the first frame update
    void Awake()
    {
        if (music != null)
        {
            Destroy(gameObject);
        }
        else
        {
            music = this;
            DontDestroyOnLoad(this.gameObject);
        }    
    }
}
