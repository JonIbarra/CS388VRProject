using UnityEngine;
public class ConfigMenu : MonoBehaviour {
	public GameObject NOVRstuff; //single camera
	public GameObject VRStuff; //Two eyed camera
	float testTime = 10f; //time to go back from vr

	public Animator animator;
	// Use this for initialization
	void Start () {
		EndTest ();
	}
	//Load next scene when continue is pressed
	public void LoadNextScene(){
		this.enabled = false; //Security check to avoid multiple instances
		animator.Play("FadeOut");
		Invoke("LoadNextSceneAction", 1);
	}
	//Load next scene when continue is pressed
	public void LoadNextSceneAction()
	{
		//Load next scene (hardcoded)
		UnityEngine.SceneManagement.SceneManager.LoadScene(1);
	}
	//Deactivates non vr camera, and activates vr
	public void StartTest(){
		NOVRstuff.SetActive (false);
		VRStuff.SetActive (true);
		Invoke ("EndTest", testTime);
	}
	//Deactivates vr camera and deactivates non vr
	public void EndTest(){
		VRStuff.SetActive (false);
		NOVRstuff.SetActive (true);
	}
}
