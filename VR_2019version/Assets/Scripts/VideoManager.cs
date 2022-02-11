using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using System.IO;
using System.Xml;
using UnityEngine.Events;

public class VideoManager : MonoBehaviour
{
    VideoPlayer videoPlayer;

    public List<VideoClip> videos = new List<VideoClip>();
    public Text videoTitle;
    public GameObject skybox;
    public Material skyboxMaterial;
    //public TextAsset xmlRawFile;

    bool IsFading = false;
    float currentExposure = 1f;
    [SerializeField] float fadingSpeed = .1f;

    int i = 0;

    public UnityEvent gvrClick;
    float totalTime = 1f;
    bool gvrStatus;
    float gvrTimer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();

        //string data = xmlRawFile.text;
        //LoadXmlFile(data);
    }

    public void Play()
    {
        //SkyboxFading();
        videoPlayer.Play();
        IsFading = true;
        SetCurrentTitle();
    }

    public void Pause()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
        }

        else if (videoPlayer.isPaused)
        {
            videoPlayer.Play();
        }
    }

    public void Stop()
    {
        videoPlayer.Stop();
    }

    public void Switch()
    {
        videoPlayer.Stop();
        if (i == 0)
        {
            videoPlayer.clip = videos[i+1];
            i++;
        }
        else if (i >= videos.Count - 1)
        {
            i = 0;
            videoPlayer.clip = videos[i];
        }
        else
        {
            videoPlayer.clip = videos[i + 1];
            i++;
        }
        SetCurrentTitle();
        videoPlayer.Play();
    }

    public void SetCurrentTitle()
    {
        string title = GetComponent<VideoPlayer>().clip.name;
        videoTitle.text = "Now playing: " + title;
    }

    //void LoadXmlFile(string xmlData)
    //{
    //    string title = "";
    //    XmlDocument xmlDoc = new XmlDocument();
    //    xmlDoc.Load(new StringReader(xmlData));

    //    string xmlPathPattern;

    //    title = "Now Playing file: " + videoTitle.text;
    //}

    void Update()
    {
        if (IsFading && currentExposure >= 0.5f)
        {
            currentExposure -= Time.deltaTime * fadingSpeed;
            // RenderSettings.skybox.SetFloat("_Exposure", currentExposure);
            skyboxMaterial.SetFloat("_Exposure", currentExposure);
        }
    }

    //void SkyboxFading()
    //{
    //    float currentExposure = 1f;
    //    float fadingSpeed = .05f;

    //    while (currentExposure >= .5f)
    //    {
    //        currentExposure -= Time.deltaTime * fadingSpeed;
    //        Debug.Log(currentExposure);
    //        // RenderSettings.skybox.SetFloat("_Exposure", currentExposure);
    //        skyboxMaterial.SetFloat("_Exposure", currentExposure);
    //    }
    //}
}
