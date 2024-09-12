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
    [SerializeField] private int n_MaximumValue = 100000;    // �÷��̾ ���� ������ �ִ� �ڿ���

    // �ڿ� ȹ�� �˸�
    [Header("NoticeUI")]
    [SerializeField] private GameObject NoticeUI;
    [SerializeField] private bool b_Available = false;      // �ڿ� ȹ�� ���� ����
    [SerializeField] private bool b_AlreadyActive = false;  // ȹ�� �˸� Ȱ��ȭ ����(������ �Լ� ȣ�� ������)

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
        // ��������ŭ �ڿ� ����
        f_AvailableResources += f_AmountOfIncrease;

        // ȹ�� ���� ���� Ȯ��
        CheckNoticeUIAvailable();
    }

    void CheckNoticeUIAvailable()
    {
        // ���� ������ ��� ������ �� ȹ�� ���� UI Ȱ��ȭ
        // 1. ������ �ڿ��� �ּ� ȹ�� ������ ���� ���
        // 2. ȹ�� ���� UI�� ���� Ȱ��ȭ���� �ʾ��� ���
        // 3. ���� �ڿ� �������� �ִ�ġ�� �ƴ� ���
        if (f_AvailableResources >= f_MinimumValue
            && false == b_AlreadyActive
            && false == Player.Instance.IsMaximum())
        {
            SetNoticeUI(1);
        }
    }

    void SetNoticeUI(int active)
    {
        // 0: ��Ȱ��ȭ
        if (0 == active)
        {
            NoticeUI.SetActive(false);
            b_AlreadyActive = false;
            b_Available = false;

            AvailableResourcesText.color = Color.red;
        }
        // 1: Ȱ��ȭ
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
        // ���� �ڿ����� �ִ�ġ�� ��� ȹ�� �Ұ�
        if (true == Player.Instance.IsMaximum())
        {
            return;
        }

        // ȹ�� ������ ���
        if (b_Available)
        {
            // ȹ���� �� �ִ� �ڿ��� ��� �� �ڿ� ȹ��
            int value = CalculateResources();
            Player.Instance.AddResources(value);

            // ���� �ڿ��� �ؽ�Ʈ ����
            MenuManager.UpdateResourcesText();

            // ȹ���� �縸ŭ�� ����
            f_AvailableResources -= value;

            // ȹ�� ���� UI ��Ȱ��ȭ
            SetNoticeUI(0);
        }
    }

    int CalculateResources()
    {
        int currentResources = Player.Instance.GetResources();

        // ȹ�� �� ���� �ڿ����� ������ �ʰ��� ���
        // ȹ�� ������ �縸ŭ�� ȹ��
        if (currentResources + (int)f_AvailableResources >= n_MaximumValue)
        {
            int difference = n_MaximumValue - currentResources;
            return difference;
        }
        // �ƴ϶�� ��ü �ڿ��� ȹ��
        else
        {
            return (int)f_AvailableResources;
        }
    }
}
