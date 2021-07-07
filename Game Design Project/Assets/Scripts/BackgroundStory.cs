using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NDream.AirConsole;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class BackgroundStory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AirConsole.instance.Broadcast(new { action = "showBackgroundStory" });
    }


    VideoPlayer video;

    void Awake()
    {
        video = GetComponent<VideoPlayer>();
        video.Play();
        video.loopPointReached += CheckOver;
    }


    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene("Earth");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Earth");
        }
    }
}
