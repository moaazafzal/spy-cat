using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public class Dailygift : MonoBehaviour
{
    public static DateTime lastPlay;
    public static TimeSpan difference;
    public static DateTime currentDate;
    public static string temp;
    public GameObject panelPopUp, panelDaily;
    public dfLabel labelDes;
    public dfButton btnClose, btnClaim;
    public dfPanel icon, day2, day3, day4, day5, day6, day7, day8, day9, day10, day11, day12, day13, day14;
    void Start()
	{  
        RamboState.dailyCount = PlayerPrefs.GetInt("DailyCountDown", RamboState.dailyCount);
        temp = PlayerPrefs.GetString("LastPlay", DateTime.Now.ToString());

        if (RamboState.dailyCount == 1)
        {
            //Store the current time when it starts
            currentDate = DateTime.Now;
            //If first time, store current date = old date. isFirstTime lay trong RamboState
            lastPlay = currentDate;
        }
        else
        {
            currentDate = DateTime.Now;
            lastPlay = DateTime.Parse(temp.Trim());
        }

        //Use the Subtract method and store the result as a timespan variable
        difference = currentDate - lastPlay;

        if (MenuOnClick.checkDaily && difference.TotalHours >= 24)
        {
            panelPopUp.SetActive(true);
        }
        else
        {
            panelPopUp.SetActive(false);
        }

        #region LoadDaily
        if (RamboState.dailyCount == 1)
        {
            labelDes.Text = RamboState.day1;
            icon.BackgroundSprite = "1";
            panelDaily.SetActive(true);
            panelPopUp.SetActive(true);
        }
        else if (RamboState.dailyCount == 2 && difference.TotalHours >= 24)
        {
            labelDes.Text = RamboState.day2;
            icon.BackgroundSprite = "2";
		
            day2.BackgroundSprite = "2";
            panelDaily.SetActive(true);
            panelPopUp.SetActive(true);
        }
        else if (RamboState.dailyCount == 3 && difference.TotalHours >= 24)
        {
            labelDes.Text = RamboState.day3;
            icon.BackgroundSprite = "3";
			day2.BackgroundSprite = "2";
            day3.BackgroundSprite = "3";
            panelDaily.SetActive(true);
            panelPopUp.SetActive(true);
        }
        else if (RamboState.dailyCount == 4 && difference.TotalHours >= 24)
        {
            labelDes.Text = RamboState.day4;
            icon.BackgroundSprite = "4";
			day2.BackgroundSprite = "2";
			day3.BackgroundSprite = "3";
            day4.BackgroundSprite = "4";
            panelDaily.SetActive(true);
            panelPopUp.SetActive(true);
        }
        else if (RamboState.dailyCount == 5 && difference.TotalHours >= 24)
        {
            labelDes.Text = RamboState.day5;
            icon.BackgroundSprite = "d5";
			day2.BackgroundSprite = "2";
			day3.BackgroundSprite = "3";
			day4.BackgroundSprite = "4";
            day5.BackgroundSprite = "5";
            panelDaily.SetActive(true);
            panelPopUp.SetActive(true);
        }
        else if (RamboState.dailyCount == 6 && difference.TotalHours >= 24)
        {
            labelDes.Text = RamboState.day6;
            icon.BackgroundSprite = "6";
			day2.BackgroundSprite = "2";
			day3.BackgroundSprite = "3";
			day4.BackgroundSprite = "4";
			day5.BackgroundSprite = "5";
            day6.BackgroundSprite = "6";
            panelDaily.SetActive(true);
            panelPopUp.SetActive(true);
        }
        else if (RamboState.dailyCount == 7 && difference.TotalHours >= 24)
        {
            labelDes.Text = RamboState.day7;
            icon.BackgroundSprite = "7";
			day2.BackgroundSprite = "2";
			day3.BackgroundSprite = "3";
			day4.BackgroundSprite = "4";
			day5.BackgroundSprite = "5";
			day6.BackgroundSprite = "6";
            day7.BackgroundSprite = "7";
            panelDaily.SetActive(true);
            panelPopUp.SetActive(true);
        }
        else if (RamboState.dailyCount == 8 && difference.TotalHours >= 24)
        {
            labelDes.Text = RamboState.day8;
            icon.BackgroundSprite = "8";
			day2.BackgroundSprite = "2";
			day3.BackgroundSprite = "3";
			day4.BackgroundSprite = "4";
			day5.BackgroundSprite = "5";
			day6.BackgroundSprite = "6";
			day7.BackgroundSprite = "7";
            day8.BackgroundSprite = "8";
            panelDaily.SetActive(true);
            panelPopUp.SetActive(true);
        }
        else if (RamboState.dailyCount == 9 && difference.TotalHours >= 24)
        {
            labelDes.Text = RamboState.day9;
            icon.BackgroundSprite = "9";
			day2.BackgroundSprite = "2";
			day3.BackgroundSprite = "3";
			day4.BackgroundSprite = "4";
			day5.BackgroundSprite = "5";
			day6.BackgroundSprite = "6";
			day7.BackgroundSprite = "7";
			day8.BackgroundSprite = "8";
            day9.BackgroundSprite = "9";
            panelDaily.SetActive(true);
            panelPopUp.SetActive(true);
        }
        else if (RamboState.dailyCount == 10 && difference.TotalHours >= 24)
        {
            labelDes.Text = RamboState.day10;
            icon.BackgroundSprite = "10";
			day2.BackgroundSprite = "2";
			day3.BackgroundSprite = "3";
			day4.BackgroundSprite = "4";
			day5.BackgroundSprite = "5";
			day6.BackgroundSprite = "6";
			day7.BackgroundSprite = "7";
			day8.BackgroundSprite = "8";
			day9.BackgroundSprite = "8";
            day10.BackgroundSprite = "10";
            panelDaily.SetActive(true);
            panelPopUp.SetActive(true);
        }
        else if (RamboState.dailyCount == 11 && difference.TotalHours >= 24)
        {
            labelDes.Text = RamboState.day11;
            icon.BackgroundSprite = "11";
			day2.BackgroundSprite = "2";
			day3.BackgroundSprite = "3";
			day4.BackgroundSprite = "4";
			day5.BackgroundSprite = "5";
			day6.BackgroundSprite = "6";
			day7.BackgroundSprite = "7";
			day8.BackgroundSprite = "8";
			day9.BackgroundSprite = "8";
			day10.BackgroundSprite = "10";
            day11.BackgroundSprite = "11";
            panelDaily.SetActive(true);
            panelPopUp.SetActive(true);
        }
        else if (RamboState.dailyCount == 12 && difference.TotalHours >= 24)
        {
            labelDes.Text = RamboState.day12;
            icon.BackgroundSprite = "12";
			day2.BackgroundSprite = "2";
			day3.BackgroundSprite = "3";
			day4.BackgroundSprite = "4";
			day5.BackgroundSprite = "5";
			day6.BackgroundSprite = "6";
			day7.BackgroundSprite = "7";
			day8.BackgroundSprite = "8";
			day9.BackgroundSprite = "8";
			day10.BackgroundSprite = "10";
			day11.BackgroundSprite = "11";
            day12.BackgroundSprite = "12";
            panelDaily.SetActive(true);
            panelPopUp.SetActive(true);
        }
        else if (RamboState.dailyCount == 13 && difference.TotalHours >= 24)
        {
            labelDes.Text = RamboState.day13;
            icon.BackgroundSprite = "13";
			day2.BackgroundSprite = "2";
			day3.BackgroundSprite = "3";
			day4.BackgroundSprite = "4";
			day5.BackgroundSprite = "5";
			day6.BackgroundSprite = "6";
			day7.BackgroundSprite = "7";
			day8.BackgroundSprite = "8";
			day9.BackgroundSprite = "8";
			day10.BackgroundSprite = "10";
			day11.BackgroundSprite = "11";
			day12.BackgroundSprite = "12";
            day13.BackgroundSprite = "13";
            panelDaily.SetActive(true);
            panelPopUp.SetActive(true);
        }
        else if (RamboState.dailyCount == 14 && difference.TotalHours >= 24)
        {
            labelDes.Text = RamboState.day14;
            icon.BackgroundSprite = "14";
			day2.BackgroundSprite = "2";
			day3.BackgroundSprite = "3";
			day4.BackgroundSprite = "4";
			day5.BackgroundSprite = "5";
			day6.BackgroundSprite = "6";
			day7.BackgroundSprite = "7";
			day8.BackgroundSprite = "8";
			day9.BackgroundSprite = "8";
			day10.BackgroundSprite = "10";
			day11.BackgroundSprite = "11";
			day12.BackgroundSprite = "12";
			day13.BackgroundSprite = "13";
            day14.BackgroundSprite = "14";
            panelDaily.SetActive(true);
            panelPopUp.SetActive(true);
        }
        #endregion
    }

    public void OnClick(dfControl control, dfMouseEventArgs mouseEvent)
	{  GameObject.Find ("Click").GetComponent<SoundClick> ().play ();
        if (control.name == "Button Claim")
        {
            MenuOnClick.checkDaily = false;

            if (RamboState.dailyCount == 1)
            {
                RamboState.HP_RAMBO += 2;
                RamboState.dailyCount = 2;
                PlayerPrefs.SetInt("DailyCountDown", 2);
                panelPopUp.SetActive(false);
            }
            else if (RamboState.dailyCount == 2 && difference.TotalHours >= 24)
            {
                RamboState.dola += 500;
                RamboState.dailyCount = 3;
                PlayerPrefs.SetInt("DailyCountDown", 3);
                panelPopUp.SetActive(false);
            }
            else if (RamboState.dailyCount == 3 && difference.TotalHours >= 24)
            {
                RamboState.RAMBO_LUUDAN += 5;
                RamboState.dailyCount = 4;
                PlayerPrefs.SetInt("DailyCountDown", 4);
                panelPopUp.SetActive(false);
            }
            else if (RamboState.dailyCount == 4 && difference.TotalHours >= 24)
            {
                RamboState.dola += 500;
                RamboState.dailyCount = 5;
                PlayerPrefs.SetInt("DailyCountDown", 5);
                panelPopUp.SetActive(false);
            }
            else if (RamboState.dailyCount == 5 && difference.TotalHours >= 24)
            {
                RamboState.dola += 1000;
                RamboState.dailyCount = 6;
                PlayerPrefs.SetInt("DailyCountDown", 6);
                panelPopUp.SetActive(false);
            }
            else if (RamboState.dailyCount == 6 && difference.TotalHours >= 24)
            {
                RamboState.dola += 1500;
                RamboState.dailyCount = 7;
                PlayerPrefs.SetInt("DailyCountDown", 7);
                panelPopUp.SetActive(false);
            }
            else if (RamboState.dailyCount == 7 && difference.TotalHours >= 24)
            {
                RamboState.dola += 2000;
                RamboState.dailyCount = 8;
                PlayerPrefs.SetInt("DailyCountDown", 8);
                panelPopUp.SetActive(false);
            }
            else if (RamboState.dailyCount == 8 && difference.TotalHours >= 24)
            {
                if (RamboState.clothes_buy[4] == 0)
                {
                    RamboState.clothes_buy[4] = 1;
                    RamboState.state_clothes = 4;
                }
                else
                {
                    RamboState.dola += 12000;
                }
                RamboState.dailyCount = 9;
                PlayerPrefs.SetInt("DailyCountDown", 9);
                panelPopUp.SetActive(false);
            }
            else if (RamboState.dailyCount == 9 && difference.TotalHours >= 24)
            {
                if (RamboState.gun_buy[8] == 0)
                {
                    RamboState.gun_buy[8] = 1;
                    RamboState.state_sung = 26;
                }
                else
                {
                    RamboState.dola += 7500;
                }
                RamboState.dailyCount = 10;
                PlayerPrefs.SetInt("DailyCountDown", 10);
                panelPopUp.SetActive(false);
            }
            else if (RamboState.dailyCount == 10 && difference.TotalHours >= 24)
            {
                RamboState.total_bullet_sungluc += 100;
                RamboState.total_bullet_sungtia += 100;
                RamboState.dailyCount = 11;
                PlayerPrefs.SetInt("DailyCountDown", 11);
                panelPopUp.SetActive(false);
            }
            else if (RamboState.dailyCount == 11 && difference.TotalHours >= 24)
            {
                RamboState.total_bullet_sungshotgun += 100;
                RamboState.total_bullet_sungngam += 15;
                RamboState.total_bullet_sung_tenlua += 15;
                RamboState.dailyCount = 12;
                PlayerPrefs.SetInt("DailyCountDown", 12);
                panelPopUp.SetActive(false);
            }
            else if (RamboState.dailyCount == 12 && difference.TotalHours >= 24)
            {
                RamboState.HP_RAMBO += 50;
                RamboState.dailyCount = 13;
                PlayerPrefs.SetInt("DailyCountDown", 13);
                panelPopUp.SetActive(false);
            }
            else if (RamboState.dailyCount == 13 && difference.TotalHours >= 24)
            {
                RamboState.total_bullet_sungngam += 200;
                RamboState.dailyCount = 14;
                PlayerPrefs.SetInt("DailyCountDown", 14);
                panelPopUp.SetActive(false);
            }
            else if (RamboState.dailyCount == 14 && difference.TotalHours >= 24)
            {
                if (RamboState.gun_buy[7] == 0)
                {
                    RamboState.gun_buy[7] = 1;
                    RamboState.state_sung = 23;
                }
                else
                    RamboState.dola += 25000;

                RamboState.dailyCount = 15;
                PlayerPrefs.SetInt("DailyCountDown", 15);
                panelPopUp.SetActive(false);
            }
        }
        PlayerPrefs.Save();
        ApplicationQuit();
    }

    void ApplicationQuit()
    {
        //Save the current system time as a string in the player prefs class
        PlayerPrefs.SetString("LastPlay", DateTime.Now.ToString());
    }


	public void check(){
		if (RamboState.dailyCount == 1)
		{

			icon.BackgroundSprite = "1";

		}
		else if (RamboState.dailyCount == 2 )
		{

			icon.BackgroundSprite = "2";			


		}
		else if (RamboState.dailyCount == 3 )
		{

			icon.BackgroundSprite = "3";
			day2.BackgroundSprite = "2";

		
		}
		else if (RamboState.dailyCount == 4 )
		{

			icon.BackgroundSprite = "4";
			day2.BackgroundSprite = "2";
			day3.BackgroundSprite = "3";
		
		
		}
		else if (RamboState.dailyCount == 5 )
		{

			icon.BackgroundSprite = "d5";
			day2.BackgroundSprite = "2";
			day3.BackgroundSprite = "3";
			day4.BackgroundSprite = "4";

		
		}
		else if (RamboState.dailyCount == 6 )
		{

			icon.BackgroundSprite = "6";
			day2.BackgroundSprite = "2";
			day3.BackgroundSprite = "3";
			day4.BackgroundSprite = "4";
			day5.BackgroundSprite = "5";


		}
		else if (RamboState.dailyCount == 7)
		{

			icon.BackgroundSprite = "7";
			day2.BackgroundSprite = "2";
			day3.BackgroundSprite = "3";
			day4.BackgroundSprite = "4";
			day5.BackgroundSprite = "5";
			day6.BackgroundSprite = "6";


		}
		else if (RamboState.dailyCount == 8)
		{

			icon.BackgroundSprite = "8";
			day2.BackgroundSprite = "2";
			day3.BackgroundSprite = "3";
			day4.BackgroundSprite = "4";
			day5.BackgroundSprite = "5";
			day6.BackgroundSprite = "6";
			day7.BackgroundSprite = "7";
			day8.BackgroundSprite = "8";

		}
		else if (RamboState.dailyCount == 9 )
		{

			icon.BackgroundSprite = "9";
			day2.BackgroundSprite = "2";
			day3.BackgroundSprite = "3";
			day4.BackgroundSprite = "4";
			day5.BackgroundSprite = "5";
			day6.BackgroundSprite = "6";
			day7.BackgroundSprite = "7";
			day8.BackgroundSprite = "8";
		
		
		}
		else if (RamboState.dailyCount == 10 )
		{

			icon.BackgroundSprite = "10";
			day2.BackgroundSprite = "2";
			day3.BackgroundSprite = "3";
			day4.BackgroundSprite = "4";
			day5.BackgroundSprite = "5";
			day6.BackgroundSprite = "6";
			day7.BackgroundSprite = "7";
			day8.BackgroundSprite = "8";
			day9.BackgroundSprite = "8";
		
		
		}
		else if (RamboState.dailyCount == 11 )
		{

			icon.BackgroundSprite = "11";
			day2.BackgroundSprite = "2";
			day3.BackgroundSprite = "3";
			day4.BackgroundSprite = "4";
			day5.BackgroundSprite = "5";
			day6.BackgroundSprite = "6";
			day7.BackgroundSprite = "7";
			day8.BackgroundSprite = "8";
			day9.BackgroundSprite = "8";
			day10.BackgroundSprite = "10";


		
		}
		else if (RamboState.dailyCount == 12 )
		{

			icon.BackgroundSprite = "12";
			day2.BackgroundSprite = "2";
			day3.BackgroundSprite = "3";
			day4.BackgroundSprite = "4";
			day5.BackgroundSprite = "5";
			day6.BackgroundSprite = "6";
			day7.BackgroundSprite = "7";
			day8.BackgroundSprite = "8";
			day9.BackgroundSprite = "8";
			day10.BackgroundSprite = "10";
			day11.BackgroundSprite = "11";


		}
		else if (RamboState.dailyCount == 13)
		{

			icon.BackgroundSprite = "13";
			day2.BackgroundSprite = "2";
			day3.BackgroundSprite = "3";
			day4.BackgroundSprite = "4";
			day5.BackgroundSprite = "5";
			day6.BackgroundSprite = "6";
			day7.BackgroundSprite = "7";
			day8.BackgroundSprite = "8";
			day9.BackgroundSprite = "8";
			day10.BackgroundSprite = "10";
			day11.BackgroundSprite = "11";
			day12.BackgroundSprite = "12";

		
		}
		else if (RamboState.dailyCount == 14 )
		{

			icon.BackgroundSprite = "14";
			day2.BackgroundSprite = "2";
			day3.BackgroundSprite = "3";
			day4.BackgroundSprite = "4";
			day5.BackgroundSprite = "5";
			day6.BackgroundSprite = "6";
			day7.BackgroundSprite = "7";
			day8.BackgroundSprite = "8";
			day9.BackgroundSprite = "8";
			day10.BackgroundSprite = "10";
			day11.BackgroundSprite = "11";
			day12.BackgroundSprite = "12";
			day13.BackgroundSprite = "13";


		}

	}

}
