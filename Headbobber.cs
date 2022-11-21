using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headbobber : MonoBehaviour {

	private float timer = 0.0f;
	public float bobbingSpeed = 0.29f;
	public float bobbingAmount = 0.05f;
	public float midpoint = 1.7f;
	private Player player;

    public float fps;

    void OnEnable(){

		player = GameObject.Find("Player").GetComponent<Player>();

	}

	void Update () {

        fps = (int)(1f / Time.deltaTime);

        if (fps > 120)
        {
            bobbingSpeed = 0.01f;
            bobbingAmount = 0.02f;
        }

        else if (fps <= 120 && fps > 85)
        {
            bobbingSpeed = 0.1f;
            bobbingAmount = 0.02f;
        }

        else if (fps <= 85 && fps > 60)
        {
            bobbingSpeed = 0.2f;
            bobbingAmount = 0.02f;
        }

        else if (fps <= 60 && fps > 30)
        {
            bobbingSpeed = 0.2f;
            bobbingAmount = 0.02f;
        }

        else
        {
            bobbingSpeed = 0.5f;
            bobbingAmount = 0.02f;
        }

        float waveslice = 0.0f;
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		Vector3 cSharpConversion = transform.localPosition; 

		if (Mathf.Abs(horizontal) == 0 && Mathf.Abs(vertical) == 0 && player.isSprint == true) {
			timer = 0.0f;
		}
		else {
			waveslice = Mathf.Sin(timer);
			timer = timer + bobbingSpeed;
			if (timer > Mathf.PI * 2) {
				timer = timer - (Mathf.PI * 2);
			}
		}
		if (waveslice != 0 && player.isSprint == true) {
			float translateChange = waveslice * bobbingAmount;
			float totalAxes = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
			totalAxes = Mathf.Clamp (totalAxes, 0.0f, 1.0f);
			translateChange = totalAxes * translateChange;
			cSharpConversion.y = midpoint + translateChange;
		}
		else {
			cSharpConversion.y = midpoint;
		}

		transform.localPosition = cSharpConversion;
	}

}
