using UnityEngine;
using System.Collections;

public class AchievementScripts : MonoBehaviour
{

    public GameObject panelAchievement, panelArmory, panelDestroy, panelCharacter, panelRotation;
    public dfLabel numOfAchievement, numOfDestroy, numOfArmory, numOfCharacter;
    public float rotationSpeed;
    int i = 0;
    public dfTweenVector3 armory;

    void Start()
	{   if (GoogleAnalytics.instance) {
			GoogleAnalytics.instance.LogScreen ("Screen Achievement");
			
		}

        panelAchievement.SetActive(true);
        panelArmory.SetActive(false);
        panelCharacter.SetActive(false);
        panelDestroy.SetActive(false);
    }

    public void ArmoryOnClick()
	{  GameObject.Find ("Click").GetComponent<SoundClick> ().play ();
        panelAchievement.SetActive(false);
        panelArmory.SetActive(true);
        panelCharacter.SetActive(false);
        panelDestroy.SetActive(false);
        i = 1;
        armory.Play();
		for (int j=0; j<15; j++) {
			if(GameObject.Find("v"+(j+1))!=null){
				GameObject.Find("v"+(j+1)).SetActive(true);
				
			}
			
		}
    }

    public void DestroyOnClick()
	{  GameObject.Find ("Click").GetComponent<SoundClick> ().play ();
        panelAchievement.SetActive(false);
        panelArmory.SetActive(false);
        panelCharacter.SetActive(false);
        panelDestroy.SetActive(true);
        i = 1;
		for (int j=15; j<35;j++) {
			if(GameObject.Find("v"+(j+1))!=null){
				GameObject.Find("v"+(j+1)).SetActive(true);
				
			}
			
		}
    }

    public void CharacterOnClick()
	{   GameObject.Find ("Click").GetComponent<SoundClick> ().play ();
        panelAchievement.SetActive(false);
        panelArmory.SetActive(false);
        panelCharacter.SetActive(true);
        panelDestroy.SetActive(false);
        i = 1;
		for (int j=35; j<55;j++) {
			if(GameObject.Find("v"+(j+1))!=null){
				GameObject.Find("v"+(j+1)).SetActive(true);
				
			}
			
		}


    }
    public void BackButtonOnClick()
	{   GameObject.Find ("Click").GetComponent<SoundClick> ().play ();
        if (i == 1)
        {
            if (panelAchievement.activeInHierarchy == false)
            {
                panelAchievement.SetActive(!panelAchievement.activeInHierarchy);
                panelArmory.SetActive(false);
                panelCharacter.SetActive(false);
                panelDestroy.SetActive(false);
                i = 2;
				GetComponent<RewardAchievement>().update_newachi();
            }
        }
        else if (i == 2 || i == 0)
        {
            Application.LoadLevel("ChooseMap");
			//if(GameObject.Find("Admob")!=null)
				//GameObject.Find("Admob").GetComponent<AdmobControl>().bannerView.Hide();
        }

    }
    public void NextButtonOnClick()
	{   GameObject.Find ("Click").GetComponent<SoundClick> ().play ();
		//if(GameObject.Find("Admob")!=null)
			//GameObject.Find("Admob").GetComponent<AdmobControl>().bannerView.Hide();
		if (RamboState.check_continue_map) {
						Application.LoadLevel ("ChooseMap");
				} else {

			if(RamboState.check_huongdan==1)
				AutoFade.LoadLevel("Shop",0.5f,0.5f,Color.black);
			else  AutoFade.LoadLevel("Story",0.5f,0.5f,Color.black);

				}
 
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
			if (i == 1)
			{
				if (panelAchievement.activeInHierarchy == false)
				{
					panelAchievement.SetActive(!panelAchievement.activeInHierarchy);
					panelArmory.SetActive(false);
					panelCharacter.SetActive(false);
					panelDestroy.SetActive(false);
					i = 2;
					GetComponent<RewardAchievement>().update_newachi();
				}
			}
			else if (i == 2 || i == 0)
			{
				Application.LoadLevel("ChooseMap");
				//if(GameObject.Find("Admob")!=null)
				//	GameObject.Find("Admob").GetComponent<AdmobControl>().bannerView.Hide();
			}
        }
        panelRotation.transform.Rotate(new Vector3(0, 0, rotationSpeed));
    }
}