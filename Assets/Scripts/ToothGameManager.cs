using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Import TextMeshPro namespace

public class ToothGameManager : MonoBehaviour
{
    public GameObject startButton;
    public GameObject continueButton;
    public GameObject syringe;
    public GameObject elevator;
    public GameObject gauze;
    public GameObject teeth;
    public GameObject gums;
    public TextMeshProUGUI messageText; // TMP Text

    private int step = 0;
    private bool isTeethLifted = false;
    private bool isTeethRemoved = false;
    private bool isGauzeApplied = false;

    void Start()
    {
        startButton.SetActive(true);
        continueButton.SetActive(false);
        syringe.SetActive(false);
        elevator.SetActive(false);
        gauze.SetActive(false);
        teeth.SetActive(true);
        gums.SetActive(true);
        messageText.text = "";
    }

    public void OnStartClicked()
    {
        startButton.SetActive(false);
        syringe.SetActive(true);
        teeth.SetActive(true);
        gums.SetActive(true);
        ShowMessage("Apply anesthesia using the syringe");
    }

    void Update()
    {
        if (step == 0 && syringe.activeSelf && IsTouching(syringe, gums))
        {
            ShowMessage("Anesthesia applied");
            ShowContinueButton();
            step = 1;
        }

        if (step == 2 && elevator.activeSelf && IsTouching(elevator, gums))
        {
            if (!isTeethLifted)
            {
                teeth.transform.position += new Vector3(0, 1f, 0);
                isTeethLifted = true;
            }
            else if (!isTeethRemoved)
            {
                teeth.transform.position += new Vector3(1f, 0, 0);
                ShowMessage("Elevator used, tooth removed");
                ShowContinueButton();
                isTeethRemoved = true;
                step = 3;
            }
        }

        if (step == 4 && gauze.activeSelf && IsTouching(gauze, gums))
        {
            gauze.transform.position = gums.transform.position;
            ShowMessage("Gauze used, Bleeding stopped");
            ShowContinueButton();
            isGauzeApplied = true;
            step = 5;
        }
    }

    public void OnContinueClicked()
    {
        continueButton.SetActive(false);

        if (step == 1)
        {
            PrepareElevatorStep();
            step = 2;
        }
        else if (step == 3)
        {
            PrepareGauzeStep();
            step = 4;
        }
        else if (step == 5)
        {
            CompleteProcess();
        }
    }

    private void PrepareElevatorStep()
    {
        syringe.SetActive(false);
        elevator.SetActive(true);
        ShowMessage("Use the elevator to lift and remove the tooth");
    }

    private void PrepareGauzeStep()
    {
        elevator.SetActive(false);
        gauze.SetActive(true);
        ShowMessage("Apply gauze on the wound");
    }

    private void CompleteProcess()
    {
        gauze.SetActive(false);
        teeth.SetActive(false);
        ShowMessage("Process complete.");
    }

    private void ShowMessage(string msg)
    {
        messageText.text = msg;
    }

    private void ShowContinueButton()
    {
        continueButton.SetActive(true);
    }

    private bool IsTouching(GameObject obj1, GameObject obj2)
    {
        Collider col1 = obj1.GetComponent<Collider>();
        Collider col2 = obj2.GetComponent<Collider>();

        if (col1 != null && col2 != null)
        {
            return col1.bounds.Intersects(col2.bounds);
        }

        return false;
    }
}
