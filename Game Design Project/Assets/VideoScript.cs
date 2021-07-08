using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NDream.AirConsole;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AirConsole.instance.Broadcast(new { action = "showBackgroundStory" });


        GameObject camera = GameObject.Find("Main Camera");
        var videoPlayer = camera.AddComponent<VideoPlayer>();
        videoPlayer.playOnAwake = false;
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "backgroundstory.mp4");
        videoPlayer.Play();
        videoPlayer.loopPointReached += CheckOver;
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene("Earth");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Earth");
        }
    }
}
