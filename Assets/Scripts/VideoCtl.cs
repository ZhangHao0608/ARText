using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoCtl : MonoBehaviour {

    public VideoPlayer m_Videoplayer;
    public Image m_Image;

    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void VideoPlay()
    {
        if(m_Videoplayer.isPlaying)
        {
            m_Videoplayer.Pause();
            m_Image.color = new Vector4(255, 255, 255, 255);
        }
        else
        {
            m_Videoplayer.Play();
            m_Image.color = new Vector4(255, 255, 255, 0);
        }
    }

    public void HideVideoPlay()
    {
        m_Videoplayer.Pause();
        m_Image.color = new Vector4(255, 255, 255, 0);
    }
}
