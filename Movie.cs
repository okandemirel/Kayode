
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.iOS;



public class Movie : MonoBehaviour
{
    public string movieFileName = "cabbar.mp4";
    public Color backgroundColor = Color.black;

#if UNITY_ANDROID || UNITY_IPHONE
    public FullScreenMovieControlMode controlMod = FullScreenMovieControlMode.Hidden;
    public FullScreenMovieScalingMode scalingMod = FullScreenMovieScalingMode.Fill;
#endif

    public bool playOnStart = true;

    IEnumerator Start()
    {
        Debug.Log(Application.streamingAssetsPath + "/" + movieFileName);
        if (playOnStart)
        {
            Play();
            
        }
        
        Invoke("NextScene", 0f);
        yield return 0;
       
    }

    /// <summary>
    /// Play the movie
    /// </summary>
    public void Play()
    {
        if (Input.GetMouseButtonDown(0))
        {

            SceneManager.LoadScene("TheSillyBird");

        }
        if (string.IsNullOrEmpty(movieFileName))
        {
            Debug.Log("movieFileName is undefined");
            return;
           
        }
#if UNITY_ANDROID || UNITY_IPHONE
        //Play full screen only
        Handheld.PlayFullScreenMovie("cabbar.mp4", backgroundColor, controlMod, scalingMod);
#endif
    }


    public void NextScene()
    {
        SceneManager.LoadScene("TheSillyBird");
    }
    void Update()
    {

    }
}


