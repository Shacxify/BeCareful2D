using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class mute : MonoBehaviour
{
    AudioSource audio;
		public Sprite unmute, MUTE;
		Image sR;

    void Start()
    {
				bool musicstate = true;
        audio = GameObject.Find("music").GetComponent<AudioSource>();
				sR = GameObject.Find("sound_0").GetComponent<Image>();
    }


		public void onClick() {
			if (audio.mute) {
					audio.mute = false;
					sR.sprite = unmute;
				} else {
					audio.mute = true;
					sR.sprite = MUTE;
				}
			}
}
