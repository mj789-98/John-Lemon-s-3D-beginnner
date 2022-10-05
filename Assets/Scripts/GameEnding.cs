using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public AudioSource exitAudio;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    public AudioSource caughtAudio;

    public  bool mIsPlayerAtExit;
    public  bool mIsPlayerCaught;
    public  float mTimer;
    public bool mHasAudioPlayed;
    
    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject == player)
        {
            mIsPlayerAtExit = true;
        }
    }

    public void CaughtPlayer ()
    {
        mIsPlayerCaught = true;
    }

    void Update ()
    {
        if (mIsPlayerAtExit)
        {
            EndLevel (exitBackgroundImageCanvasGroup, false, exitAudio);
        }
        else if (mIsPlayerCaught)
        {
            EndLevel (caughtBackgroundImageCanvasGroup, true, caughtAudio);
        }
    }

    void EndLevel (CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        if (!mHasAudioPlayed)
        {
            audioSource.Play();
            mHasAudioPlayed = true;
        }
        mTimer += Time.deltaTime;
        imageCanvasGroup.alpha = mTimer / fadeDuration;

        if (mTimer > fadeDuration + displayImageDuration)
        {
            if (doRestart)
            {
                SceneManager.LoadScene (sceneBuildIndex: 0);
            }
            else
            {
                Application.Quit ();
            }
        }
    }
}