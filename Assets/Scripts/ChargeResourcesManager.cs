using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChargeResourcesManager : MonoBehaviour
{
    // 자원 충전 현황 진행바 UI
    [Header("ProgressBar")]
    [SerializeField] private Image ProgressBar;
    [SerializeField] private TextMeshProUGUI TimeText;
    [SerializeField] private TextMeshProUGUI AvailableResourcesText;

    // 타이머 설정용 변수
    [Header("Timer")]
    [SerializeField] private float f_CurrentTime = 0f;  // 현재 시간
    [SerializeField] private float f_SetTime = 1f;      // 목표 시간

    // 자원 관련 변수
    [Header("Resources")]
    [SerializeField] private float f_AvailableResources = 0f;   // 현재 충전된 자원량
    [SerializeField] private float f_AmountOfIncrease = 0.75f;  // 초당 증가할 자원량
    [SerializeField] private float f_MinimumValue = 100f;       // 획득 가능한 최소 단위
    [SerializeField] private int n_MaximumValue = 100000;    // 플레이어가 보유 가능한 최대 자원량

    // 자원 획득 알림
    [Header("NoticeUI")]
    [SerializeField] private GameObject NoticeUI;
    [SerializeField] private bool b_Available = false;      // 자원 획득 가능 여부
    [SerializeField] private bool b_AlreadyActive = false;  // 획득 알림 활성화 여부(과도한 함수 호출 방지용)

    // Update is called once per frame
    void Update()
    {
        SetProgressBar();
        ShowAvailableResources();
    }

    void SetProgressBar()
    {
        // 현재 시간이 목표 시간에 도달하면
        if (f_CurrentTime >= f_SetTime)
        {
            // 시간 초기화 후 자원 충전
            f_CurrentTime -= f_SetTime;
            AddResources();
        }
        // 목표 시간 도달 전까지 시간 증가
        else
        {
            f_CurrentTime += Time.deltaTime;
        }

        // 시간 텍스트와 진행바 업데이트
        TimeText.text = f_CurrentTime.ToString("F2") + "s";
        ProgressBar.fillAmount = f_CurrentTime / f_SetTime;
    }

    // 획득 가능한 자원량을 출력하는 함수
    void ShowAvailableResources()
    {
        AvailableResourcesText.text = NumberControl.FormatWithUnit(f_AvailableResources);
    }

    void AddResources()
    {
        // 증가량만큼 자원 충전
        f_AvailableResources += f_AmountOfIncrease;

        // 획득 가능 여부 확인
        CheckNoticeUIAvailable();
    }

    void CheckNoticeUIAvailable()
    {
        // 다음 조건을 모두 만족할 때 획득 가능 UI 활성화
        // 1. 충전된 자원이 최소 획득 기준을 넘을 경우
        // 2. 획득 가능 UI가 아직 활성화되지 않았을 경우
        // 3. 현재 자원 보유량이 최대치가 아닐 경우
        if (f_AvailableResources >= f_MinimumValue
            && false == b_AlreadyActive
            && false == Player.Instance.IsMaximum())
        {
            SetNoticeUI(1);
        }
    }

    void SetNoticeUI(int active)
    {
        // 0: 비활성화
        if (0 == active)
        {
            NoticeUI.SetActive(false);
            b_AlreadyActive = false;
            b_Available = false;

            AvailableResourcesText.color = Color.red;
        }
        // 1: 활성화
        else if (1 == active)
        {
            NoticeUI.SetActive(true);
            b_AlreadyActive = true;
            b_Available = true;

            AvailableResourcesText.color = Color.black;
        }
    }

    public void ReceiveResources()
    {
        // 보유 자원량이 최대치일 경우 획득 불가
        if (true == Player.Instance.IsMaximum())
        {
            return;
        }

        // 획득 가능한 경우
        if (b_Available)
        {
            // 획득할 수 있는 자원량 계산 후 자원 획득
            int value = CalculateResources();
            Player.Instance.AddResources(value);

            // 보유 자원량 텍스트 갱신
            MenuManager.UpdateResourcesText();

            // 획득한 양만큼만 차감
            f_AvailableResources -= value;

            // 획득 가능 UI 비활성화
            SetNoticeUI(0);
        }
    }

    int CalculateResources()
    {
        int currentResources = Player.Instance.GetResources();

        // 획득 시 예상 자원량이 제한을 초과할 경우
        // 획득 가능한 양만큼만 획득
        if (currentResources + (int)f_AvailableResources >= n_MaximumValue)
        {
            int difference = n_MaximumValue - currentResources;
            return difference;
        }
        // 아니라면 전체 자원을 획득
        else
        {
            return (int)f_AvailableResources;
        }
    }
}
