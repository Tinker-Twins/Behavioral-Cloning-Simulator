using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;
using UnityEngine.SceneManagement;

public class UISystem : MonoSingleton<UISystem> {

    public CarController carController;
    //public string GoodCarStatusMessage;
    //public string BadSCartatusMessage;
    public Text Speed_Text;
    public Image Speed_Animation;
	public Text Throttle_Text;
	public Text Brake_Text;
    public Text Angle_Text;
    public Text RecordStatus_Text;
	public Text DriveStatus_Text;
	//public Text SaveStatus_Text;
    //public GameObject RecordingPause; 
	//public GameObject RecordDisabled;
	public bool isTraining = false;

    private bool recording;
    private float topSpeed;
	private bool saveRecording;


    // Use this for initialization
    void Start() {
		Debug.Log (isTraining);
        topSpeed = carController.MaxSpeed;
        recording = false;
        //RecordingPause.SetActive(false);
		RecordStatus_Text.text = "Record";
		DriveStatus_Text.text = "MODE: Manual";
		//SaveStatus_Text.text = "";
		SetAngleValue(0);
        SetMPHValue(0);
		if (!isTraining) {
			DriveStatus_Text.text = "MODE: Autonomous";
			//RecordDisabled.SetActive (true);
			RecordStatus_Text.text = "";
		}
    }

	public void SetThrottleValue(float value)
	{
		Throttle_Text.text = (value*100).ToString("N2") + "%";
	}

	public void SetBrakeValue(float value)
	{
		Brake_Text.text = (value*100).ToString("N2") + "%";
	}

    public void SetAngleValue(float value)
    {
        Angle_Text.text = value.ToString("N2") + "°";
    }

    public void SetMPHValue(float value)
    {
        Speed_Text.text = value.ToString("N2");
        //Do something with value for fill amounts
        Speed_Animation.fillAmount = value/topSpeed;
    }

    public void ToggleRecording()
    {
		// Don't record in autonomous mode
		if (!isTraining) {
			return;
		}

        if (!recording)
        {
			if (carController.checkSaveLocation()) 
			{
				recording = true;
				//RecordingPause.SetActive (true);
				RecordStatus_Text.text = "Recording";
				carController.IsRecording = true;
			}
        }
        else
        {
			saveRecording = true;
			carController.IsRecording = false;
        }
    }
	
    void UpdateCarValues()
    {
		if (!saveRecording) {
			SetMPHValue(carController.CurrentSpeed);
			SetThrottleValue(carController.AccelInput);
			SetBrakeValue(carController.BrakeInput);
			SetAngleValue(carController.CurrentSteerAngle);
		}
		else {
			SetMPHValue(0);
			SetThrottleValue(0);
			SetBrakeValue(0);
			SetAngleValue(0);
		}
    }

	// Update is called once per frame
	void Update () {

        // Easier than pressing the actual button :-)
        // Should make recording training data more pleasant.

		if (carController.getSaveStatus ()) {
			//SaveStatus_Text.text = "Capturing Data: " + (int)(100 * carController.getSavePercent ()) + "%";
			RecordStatus_Text.text = "Saving " + (int)(100 * carController.getSavePercent ()) + "%";
			//Debug.Log ("save percent is: " + carController.getSavePercent ());
		} 
		else if(saveRecording) 
		{
			//SaveStatus_Text.text = "";
			recording = false;
			//RecordingPause.SetActive(false);
			RecordStatus_Text.text = "Record";
			saveRecording = false;
		}

        if (Input.GetKeyDown(KeyCode.R))
        {
            ToggleRecording();
        }

		if (!isTraining) 
		{
			if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) 
			{
				DriveStatus_Text.color = Color.white;
				DriveStatus_Text.text = "MODE: Manual";
			} 
			else 
			{
				DriveStatus_Text.color = Color.white;
				DriveStatus_Text.text = "MODE: Autonomous";
			}
		}

	    if(Input.GetKeyDown(KeyCode.Escape))
        {
            //Do Menu Here
            SceneManager.LoadScene("MenuScene");
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            //Do Console Here
        }

        UpdateCarValues();
    }
}
