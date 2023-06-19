using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BugReportSender : MonoBehaviour
{
    [SerializeField] InputField inputField;

    [SerializeField] Animator reportSentNotification;
    [SerializeField] Animator reportThanksNotificaiton;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void RefreshNotificationsVisibility()
    {
        reportSentNotification.Play("ReportSentInvisible", -1, 0f);
        reportThanksNotificaiton.Play("ThanksFeedbackInvisible", -1, 0f);
    }

    public void SendBugReport()
    {
        if (inputField.text != "")
        {
            inputField.Select();
            inputField.text = "";
            reportSentNotification.Play("ReportSentNotification", -1, 0f);
            reportThanksNotificaiton.Play("ThanksFeedbackNotification", -1, 0f);
        }
    }
}
