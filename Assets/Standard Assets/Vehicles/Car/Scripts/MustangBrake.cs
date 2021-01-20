using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car{

	public class MustangBrake : MonoBehaviour {

		public CarController car;

		public Texture LightsOFF1;
		public Texture LightsOFF2;
		public Texture LightsOFF3;
		public Texture LightsON;


		Renderer m_Renderer;

		void Start () {
			m_Renderer = GetComponent<Renderer>();
		}
	
		void Update () {
			if (car.BrakeInput > 0f) {
				m_Renderer.materials[8].SetTexture("_MainTex", LightsON);
				m_Renderer.materials[9].SetTexture("_MainTex", LightsON);
				m_Renderer.materials[10].SetTexture("_MainTex", LightsON);
			}
			else {
				m_Renderer.materials[8].SetTexture("_MainTex", LightsOFF1);
				m_Renderer.materials[9].SetTexture("_MainTex", LightsOFF2);
				m_Renderer.materials[10].SetTexture("_MainTex", LightsOFF3);
			}
		}
	}
}
