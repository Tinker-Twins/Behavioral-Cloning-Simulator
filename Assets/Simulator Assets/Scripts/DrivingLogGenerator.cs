using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
using UnityEditor;
using System.IO;

public class DrivingLogGenerator : MonoBehaviour
{
		public GameObject car;
		public CarController carController;

    private List<float> PositionX = new List<float>();
		private List<float> PositionZ = new List<float>();
    private List<float> Throttle = new List<float>();
    private List<float> Brake = new List<float>();
    private List<float> Steering = new List<float>();
    private List<float> Speed = new List<float>();

    void Update()
    {
		PositionX.Add(car.transform.position.x);
		PositionZ.Add(car.transform.position.z);
		Throttle.Add(carController.AccelInput);
		Brake.Add(carController.BrakeInput);
		Steering.Add(carController.CurrentSteerAngle);
		Speed.Add(carController.CurrentSpeed);
    }

	public void GenerateLog ()
	{
		string PositionXArrayString = "Position X Array: ";
		foreach(var item in PositionX)
		{
			PositionXArrayString += item.ToString() + " ";
		}
		Debug.Log(PositionXArrayString);

		string PositionZArrayString = "Position Z Array: ";
		foreach(var item in PositionZ)
		{
			PositionZArrayString += item.ToString() + " ";
		}
		Debug.Log(PositionZArrayString);

		string ThrottleArrayString = "Throttle Array: ";
		foreach(var item in Throttle)
		{
			ThrottleArrayString += item.ToString() + " ";
		}
		Debug.Log(ThrottleArrayString);

		string BrakeArrayString = "Brake Array: ";
		foreach(var item in Brake)
		{
			BrakeArrayString += item.ToString() + " ";
		}
		Debug.Log(BrakeArrayString);

		string SteeringArrayString = "Steering Array: ";
		foreach(var item in Steering)
		{
			SteeringArrayString += item.ToString() + " ";
		}
		Debug.Log(SteeringArrayString);

		string SpeedArrayString = "Speed Array: ";
		foreach(var item in Speed)
		{
			SpeedArrayString += item.ToString() + " ";
		}
		Debug.Log(SpeedArrayString);
	}
}
