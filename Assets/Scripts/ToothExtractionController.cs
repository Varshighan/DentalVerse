using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToothExtractionController : MonoBehaviour
{
    public GameObject messagePanel;
    public TextMeshProUGUI messageText;
    public Button continueButton;
    public TextMeshProUGUI buttonText;

    public GameObject syringe;
    public GameObject elevator;
    public GameObject gauze;
    public GameObject tooth;

    private enum ProcedureStep { Start, Anesthesia, Elevation, Extraction, Complete }
    private ProcedureStep currentStep = ProcedureStep.Start;

    private void Start()
    {
        // Hide all tools initially
        syringe.SetActive(false);
        elevator.SetActive(false);
        gauze.SetActive(false);

        ShowMessage("Begin the procedure by pressing Continue.");
        buttonText.text = "Continue";
        continueButton.onClick.AddListener(OnContinueButtonClicked);

        Debug.Log("Simulation started. Current Step: " + currentStep);
    }

    public void OnContinueButtonClicked()
    {
        Debug.Log("Continue button clicked manually.");
        Debug.Log("Step: " + currentStep);

        switch (currentStep)
        {
            case ProcedureStep.Start:
                syringe.SetActive(true);
                ShowMessage("Use the syringe to apply anesthesia to the tooth.");
                currentStep = ProcedureStep.Anesthesia;
                break;

            case ProcedureStep.Anesthesia:
                ShowMessage("Apply the elevator to loosen the tooth.");
                elevator.SetActive(true);
                currentStep = ProcedureStep.Elevation;
                break;

            case ProcedureStep.Elevation:
                ShowMessage("Use the gauze to extract the tooth.");
                gauze.SetActive(true);
                currentStep = ProcedureStep.Extraction;
                break;

            case ProcedureStep.Extraction:
                ShowMessage("Procedure complete. Well done!");
                HideAllTools();
                currentStep = ProcedureStep.Complete;
                Debug.Log("Tooth extraction is complete.");
                break;

            case ProcedureStep.Complete:
                ShowMessage("Procedure already completed.");
                break;
        }
    }

    private void ShowMessage(string message)
    {
        messagePanel.SetActive(true);
        messageText.text = message;
    }

    private void HideAllTools()
    {
        syringe.SetActive(false);
        elevator.SetActive(false);
        gauze.SetActive(false);
        tooth.SetActive(false); // Hides the tooth to simulate extraction
    }


    public void OnToolUsed(GameObject tool)
{
    Debug.Log($"Tool used: {tool.name}, Step: {currentStep}");

    if (currentStep == ProcedureStep.Anesthesia && tool == syringe)
    {
        ShowMessage("Anesthesia applied. Press Continue.");
        continueButton.gameObject.SetActive(true);
    }
    else if (currentStep == ProcedureStep.Elevation && tool == elevator)
    {
        tooth.transform.position += new Vector3(0, 10f, 0);
        ShowMessage("Tooth loosened. Press Continue.");
        continueButton.gameObject.SetActive(true);
    }
    else if (currentStep == ProcedureStep.Extraction && tool == gauze)
    {
        ShowMessage("Tooth extracted. Press Continue.");
        continueButton.gameObject.SetActive(true);
    }
    else
    {
        Debug.LogWarning("Tool used at the wrong step or wrong tool.");
    }
}





    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Collision Detected: Tool={other.name}, Step={currentStep}");

        if (currentStep == ProcedureStep.Anesthesia && other.gameObject == syringe)
        {
            ShowMessage("Anesthesia applied. Press Continue.");
            continueButton.gameObject.SetActive(true);
        }
        else if (currentStep == ProcedureStep.Elevation && other.gameObject == elevator)
        {
            // Simulate loosening tooth by moving it
            tooth.transform.position += new Vector3(0, 10f, 0);
            ShowMessage("Tooth loosened. Press Continue.");
            continueButton.gameObject.SetActive(true);
        }
        else if (currentStep == ProcedureStep.Extraction && other.gameObject == gauze)
        {
            ShowMessage("Tooth extracted. Press Continue.");
            continueButton.gameObject.SetActive(true);
        }
    }
}
