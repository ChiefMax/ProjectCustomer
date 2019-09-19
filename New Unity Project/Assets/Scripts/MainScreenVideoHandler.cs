using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class MainScreenVideoHandler : MonoBehaviour
{
    [SerializeField]
    public RawImage image;
    [SerializeField]
    public VideoPlayer videoPlayer;

    [SerializeField]
    public GameObject videoPlayerObject;

    [SerializeField]
    public GameObject mainMenuObject;

    float timeVideo = 29f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayVideo());
    }

    IEnumerator PlayVideo()
    {
        videoPlayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while (!videoPlayer.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }
        image.texture = videoPlayer.texture;
        videoPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (videoPlayer.isPlaying)
        {
            Debug.Log(timeVideo);
            timeVideo -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            timeVideo = 0;
        }

        if (timeVideo <= 0)
        {
            Debug.Log(timeVideo);
            Debug.Log("Switching");
            videoPlayerObject.SetActive(false);
            mainMenuObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            videoPlayer.Pause();
        }
    }
}
