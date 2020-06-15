using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Song
{
    public string name;
    public string composer;
    public int bpm;
    public Sprite sprite;
}

public class StageMenu : MonoBehaviour
{
    [SerializeField] Song[] songList = null;

    [SerializeField] Text txtSongName = null;
    [SerializeField] Text txtSongComposer = null;
    [SerializeField] Text txtSongScore = null;
    [SerializeField] Image imgDisk = null;

    [SerializeField] GameObject titleMenu = null;
    DataBaseManager theDatabase;

    int currentSong = 0;

    private void OnEnable()
    {
        if(theDatabase == null)
        {
            theDatabase = FindObjectOfType<DataBaseManager>();
        }

        SettingSong();
    }

    public void BtnNext()
    {
        AudioManager.instance.PlaySFX("Touch");

        if (++currentSong > songList.Length - 1)
        {
            currentSong = 0;
        }

        SettingSong();
    }

    public void BtnPrior()
    {
        AudioManager.instance.PlaySFX("Touch");

        if (--currentSong < 0)
        {
            currentSong = songList.Length - 1;
        }

        SettingSong();
    }

    public void SettingSong()
    {
        txtSongName.text = songList[currentSong].name;
        txtSongComposer.text = songList[currentSong].composer;
        txtSongScore.text = string.Format("{0:#,##0}", theDatabase.score[currentSong]);
        imgDisk.sprite = songList[currentSong].sprite;

        AudioManager.instance.PlayBGM("BGM" + currentSong);
    }

    public void BtnBack()
    {
        titleMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void BtnPlay()
    {
        int t_bpm = songList[currentSong].bpm;

        GameManager.instance.GameStart(currentSong, t_bpm);
        gameObject.SetActive(false);
    }
}
