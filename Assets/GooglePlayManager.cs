using GooglePlayGames.BasicApi;
using GooglePlayGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooglePlayManager : MonoBehaviour
{
    public static GooglePlayManager instance;
    void Update()
    {
        
    }

    public void Start()
    {
        if (instance == null)
        {
            instance = this;    
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        PlayGamesPlatform.Activate();
        PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);
    }

    internal void ProcessAuthentication(SignInStatus status)
    {
        if (status == SignInStatus.Success)
        {
            // Continue with Play Games Services
        }
        else
        {
            // Disable your integration with Play Games Services or show a login button
            // to ask users to sign-in. Clicking it should call
            // PlayGamesPlatform.Instance.ManuallyAuthenticate(ProcessAuthentication).
        }

        Social.localUser.Authenticate(success => { if (success)
            {

                Debug.Log("Autenticacion Logging Succesfully");
                string userinfo = Social.localUser.userName + "/" + Social.localUser.id + "/" + Social.localUser.underage;
                Debug.Log(userinfo);
            }
            else {
                Debug.Log("Autentication Failed");
                    }
        });
    }

    public void Report(string Logro)
    {
        Social.ReportProgress(Logro, 100.0f, (bool success) => {
            Debug.Log(Logro);// handle success or failure
        });
    }


}

