using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChargeResourcesManager : MonoBehaviour
{
    [SerializeField] private Image ProgressBar;
    [SerializeField] private TextMeshProUGUI TimeText;
    [SerializeField] private TextMeshProUGUI AvailableResourcesText;

    [SerializeField] private float f_CurrentTime = 0f;
    [SerializeField] private float f_SetTime = 1f;

    [SerializeField] private float f_AvailableResources = 0f;
    [SerializeField] private float f_AmountOfIncrease = 0.75f;

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
        if (f_CurrentTime >= f_SetTime)
        {
            f_CurrentTime -= 1f;
            f_AvailableResources += f_AmountOfIncrease;
        }
        else
        {
            f_CurrentTime += Time.deltaTime / f_SetTime;
        }

        TimeText.text = f_CurrentTime.ToString("F2") + "s";
        ProgressBar.fillAmount = f_CurrentTime;
    }

    void ShowAvailableResources()
    {
        AvailableResourcesText.text = NumberControl.FormatWithUnit(f_AvailableResources);
    }
}
