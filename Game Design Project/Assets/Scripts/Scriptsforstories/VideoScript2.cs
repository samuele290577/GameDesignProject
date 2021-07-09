using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NDream.AirConsole;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoScript2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AirConsole.instance.Broadcast(new { action = "showTeaser" });


        GameObject camera = GameObject.Find("Main Camera");
        var videoPlayer = camera.AddComponent<VideoPlayer>();
        videoPlayer.playOnAwake = false;
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "teaserdagioco.mp4");
        videoPlayer.Play();
        videoPlayer.loopPointReached += CheckOver;
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene("SceltaTeam");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("SceltaTeam");
        }
    }
}
