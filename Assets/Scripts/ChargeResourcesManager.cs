using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChargeResourcesManager : MonoBehaviour
{
    // �ڿ� ���� ��Ȳ ����� UI
    [Header("ProgressBar")]
    [SerializeField] private Image ProgressBar;
    [SerializeField] private TextMeshProUGUI TimeText;
    [SerializeField] private TextMeshProUGUI AvailableResourcesText;

    // Ÿ�̸� ������ ����
    [Header("Timer")]
    [SerializeField] private float f_CurrentTime = 0f;  // ���� �ð�
    [SerializeField] private float f_SetTime = 1f;      // ��ǥ �ð�

    // �ڿ� ���� ����
    [Header("Resources")]
    [SerializeField] private float f_AvailableResources = 0f;   // ���� ������ �ڿ���
    [SerializeField] private float f_AmountOfIncrease = 0.75f;  // �ʴ� ������ �ڿ���
    [SerializeField] private float f_MinimumValue = 100f;       // ȹ�� ������ �ּ� ����

    // �ڿ� ȹ�� �˸�
    [Header("NoticeUI")]
    [SerializeField] private GameObject NoticeUI;
    [SerializeField] private bool b_Available = false;      // �ڿ� ȹ�� ���� ����
    [SerializeField] private bool b_AlreadyActive = false;  // ȹ�� �˸� Ȱ��ȭ ����(������ �Լ� ȣ�� ������)

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetProgressBar();
        ShowAvailableResources();
    }

    void SetProgressBar()
    {
        // ���� �ð��� ��ǥ �ð��� �����ϸ�
        if (f_CurrentTime >= f_SetTime)
        {
            // �ð� �ʱ�ȭ �� �ڿ� ����
            f_CurrentTime -= f_SetTime;
            AddResources();
        }
        // ��ǥ �ð� ���� ������ �ð� ����
        else
        {
            f_CurrentTime += Time.deltaTime;
        }

        // �ð� �ؽ�Ʈ�� ����� ������Ʈ
        TimeText.text = f_CurrentTime.ToString("F2") + "s";
        ProgressBar.fillAmount = f_CurrentTime / f_SetTime;
    }

    // ȹ�� ������ �ڿ����� ����ϴ� �Լ�
    void ShowAvailableResources()
    {
        AvailableResourcesText.text = NumberControl.FormatWithUnit(f_AvailableResources);
    }

    void AddResources()
    {
        // ��������ŭ �ڿ� �߰�
        f_AvailableResources += f_AmountOfIncrease;

        // ȹ�� ���� ���� Ȯ��
        CheckAvailable();
    }

    void CheckAvailable()
    {
        if (f_AvailableResources >= f_MinimumValue && false == b_AlreadyActive)
        {
            ActiveNoticeUI();
        }
    }

    void ActiveNoticeUI()
    {
        NoticeUI.SetActive(true);
        b_AlreadyActive = true;
        b_Available = true;

        AvailableResourcesText.color = Color.black;
    }

    public void GetResources()
    {
        if (b_Available)
        {
            // ȹ�� ������ �ڿ� �� ���� �κи� ȹ��
            int value = (int)f_AvailableResources;
            Player.Instance.AddResources(value);
            // ȹ���� �縸ŭ�� ����
            f_AvailableResources -= value;

            NoticeUI.SetActive(false);
            b_AlreadyActive = false;
            b_Available = false;

            AvailableResourcesText.color = Color.red;
        }
    }
}
