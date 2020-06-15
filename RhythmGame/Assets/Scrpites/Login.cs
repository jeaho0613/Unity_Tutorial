using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BackEnd;

public class Login : MonoBehaviour
{
    [SerializeField] InputField id = null;
    [SerializeField] InputField pw = null;

    DataBaseManager theDataBase;

    void Start()
    {
        theDataBase = FindObjectOfType<DataBaseManager>();
        Backend.Initialize(InitializedCallback);
    }

    void InitializedCallback()
    {
        if (Backend.IsInitialized)
        {
            Debug.Log(Backend.Utils.GetServerTime());
            Debug.Log(Backend.Utils.GetGoogleHash());
        }
        else
        {
            Debug.Log("초기화 실패");
        }
    }

    public void BtnRegist()
    {
        string t_id = id.text;
        string t_pw = pw.text;

        BackendReturnObject bro = Backend.BMember.CustomSignUp(t_id, t_pw, "Test");

        if (bro.IsSuccess())
        {
            Debug.Log("회원 가입 완료");
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("회원 가입 실패");
        }

        switch (bro.GetStatusCode())
        {
            case "429":
                Debug.LogError("429");
                break;
            case "401":
                Debug.LogError("401");
                break;
            case "408":
                Debug.LogError("408");
                break;
            case "504":
                Debug.LogError("504");
                break;
            case "503":
                Debug.LogError("503");
                break;
            case "400":
                Debug.LogError("400");
                break;
        }
    }

    public void BtnLogin()
    {
        string t_id = id.text;
        string t_pw = pw.text;

        BackendReturnObject bro = Backend.BMember.CustomLogin(t_id, t_pw);

        if (bro.IsSuccess())
        {
            Debug.Log("로그인 완료");
            theDataBase.LoadScore();
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("로그인 실패");
        }

        switch(bro.GetStatusCode())
        {
            case "429":
                Debug.LogError("429");
                break;
            case "401":
                Debug.LogError("401");
                break;
            case "408":
                Debug.LogError("408");
                break;
            case "504":
                Debug.LogError("504");
                break;
            case "503":
                Debug.LogError("503");
                break;
            case "400":
                Debug.LogError("400");
                break;
        }
    }
}
