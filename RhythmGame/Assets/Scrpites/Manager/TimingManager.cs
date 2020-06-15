using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    public List<GameObject> boxNoteList = new List<GameObject>();

    int[] judgementResult = new int[5];

    [SerializeField] Transform Center = null;
    [SerializeField] RectTransform[] timingRect = null;
    Vector2[] timingBoxs = null;

    EffectManager theEffect;
    ScoreManager theScoreManager;
    ComboManager theComboManager;
    StageManager theStageManager;
    PlayerController thePlayerController;
    StatusManager theStatusManager;
    AudioManager theAudioManager;

    private void Start()
    {
        theAudioManager = AudioManager.instance;
        theEffect = FindObjectOfType<EffectManager>();
        theScoreManager = FindObjectOfType<ScoreManager>();
        theComboManager = FindObjectOfType<ComboManager>();
        theStageManager = FindObjectOfType<StageManager>();
        thePlayerController = FindObjectOfType<PlayerController>();
        theStatusManager = FindObjectOfType<StatusManager>();

        // 타이밍 박스 설정
        timingBoxs = new Vector2[timingRect.Length];
        for (int i = 0; i < timingRect.Length; i++)
        {
            timingBoxs[i].Set(Center.localPosition.x - timingRect[i].rect.width / 2,
                              Center.localPosition.x + timingRect[i].rect.width / 2);
        }
    }

    public bool CheckTiming()
    {
        for (int i = 0; i < boxNoteList.Count; i++)
        {
            float t_notePosX = boxNoteList[i].transform.localPosition.x;

            for (int x = 0; x < timingBoxs.Length; x++)
            {
                if (timingBoxs[x].x <= t_notePosX && t_notePosX <= timingBoxs[x].y)
                {
                    // 노트 제거
                    boxNoteList[i].GetComponent<Note>().HideNote();
                    boxNoteList.RemoveAt(i);

                    // 이펙트 연출
                    if (x < timingBoxs.Length - 1)
                        theEffect.NoteHitEffect();

                    // 발판 중복 체크
                    if (CheckCanNextPlate())
                    {
                        theScoreManager.IncreaseScore(x); // 점수 증가
                        theStageManager.ShowNextPlate(); // 발판 생성
                        theEffect.JudgemnetEffect(x); // 판정 연출
                        judgementResult[x]++; // 판정 기록
                        theStatusManager.CheckShield();
                    }
                    else
                    {
                        theEffect.JudgemnetEffect(5);
                    }

                    theAudioManager.PlaySFX("Clap");

                    return true;
                }
            }
        }

        theComboManager.ResetCombo();
        theEffect.JudgemnetEffect(timingBoxs.Length);
        MissRecord();
        return false;
    }

    bool CheckCanNextPlate()
    {
        if (Physics.Raycast(thePlayerController.destPos, Vector3.down, out RaycastHit t_hitInfo, 1.1f))
        {
            if (t_hitInfo.transform.CompareTag("BasicPlate"))
            {
                BasicPlate t_plate = t_hitInfo.transform.GetComponent<BasicPlate>();
                if (t_plate.flag)
                {
                    t_plate.flag = false;
                    return true;
                }
            }
        }

        return false;
    }

    public int[] GetJudgementRecord()
    {
        return judgementResult;
    }

    public void MissRecord()
    {
        judgementResult[4]++;
        theStatusManager.ResetShieldCombo();
    }

    public void Initialized()
    {
        judgementResult[0] = 0;
        judgementResult[1] = 0;
        judgementResult[2] = 0;
        judgementResult[3] = 0;
        judgementResult[4] = 0;
    }
}
