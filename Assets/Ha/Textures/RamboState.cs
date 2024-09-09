using UnityEngine;
using System.Collections;

public class RamboState : MonoBehaviour
{ 
		//public static bool check_achievement = false;
		public static int mode = 1;
		public static bool check_tapjoy = false;
		public static bool check_off_sale = true;
		public static bool check_sale = true;
		public static bool check_unlock_shop = true;
		public static int state_unlock = 0;
		public static int qualitys = 4;
		public static int[] check_unlock_gun = new int[7];
		public static int[] check_unlock_clothes = new int[9];
		public static int huongdan_fashion = 1;
		public static int lockmap2;
		public static int lockmap3;
		public static int lockmap4;
		public static int lockmap5;
		public static int huongdanshop = 1;
		public static bool check_iab = false;
		public static int check_phanthuong = 1;
		public static int check_ads ;
		public static int GAME_PLAY = 1;
		public static int GAME_PAUSE = 2;
		public static int GAME_OVER = 3;
		public static int GAME_COMPLETE = 4;
		public static int Game_state = 1 ;
		public static int RAMBO_RUN = 0;
		public static int RAMBO_NUP = 1;
		public static int RAMBO_DIE = 2;
		public static int state;
		public static float hp_rambo = 0;
		public static int hp_raochan = 50;
		public static int HP_RAOCHAN = 50;
	    public static int level =41;
		public static int RAMBO_SUNG = 0;
		public static int RAMBO_LUUDAN = 1;
		public static int state_vukhi;
		public static int bullet;
		public static bool check_hiencanhbao = true;
		public static bool check_hostage1, check_hostage2;
		public static int dola = 1500;
		public static float score;
		public static int combo = 0;
		public static float HP_RAMBO = 0;
		public static int state_sung = 0;
		public static int state_clothes = 0;
		public static int number_enemy = 0;
		public static int number_start = 3;
		public static int dola_saveme = 400;
		public static int[] state_level1 = new int[50];
	public static int[] state_level2 = new int[50];
	public static int[] state_level3 = new int[50];
	public static bool check_next = false;
		public static int number_shield = 1;
		public static int number_vip = 1;
		public static bool check_vip = false;
		public static int number_grenede = 1;
		public static int max_bullet = 30;
		public static int state_map = 1;
		public static bool check_continue_map = false;
		public static int state_continue = 0;
		public static int check_huongdan = 1;
		public static int check_story;
		public static int saveme_free;
		public static float[] scores = new float[50];
		public static int check_recomend;
		public static int total_bullet_sungluc = 0;
		public static int total_bullet_sungtia = 0;
		public static int total_bullet_sungshotgun = 0;
		public static int total_bullet_sungngam = 0;
		public static int total_bullet_sung_tenlua = 0;
		public static float musicVol = 0.7f;
		public static float sfxVol = 1f;
		public static int vibrate = 1;
		public static int[] gun_buy = new int[13];
		public static int[] clothes_buy = new int[13];
		public static bool check_chonsung = false;
	
		//Name of Gun
		public static string pistol_lv1 = "Five Seven Lv1 / 3";
		public static string pistol_lv2 = "Five Seven Lv2 / 3";
		public static string pistol_lv3 = "Five Seven Lv3 / 3";
		public static string m4a1_lv1 = "M4A1 Lv1 / 4";
		public static string m4a1_lv2 = "M4A1 Lv2 / 4";
		public static string m4a1_lv3 = "M4A1 Lv3 / 4";
		public static string m4a1_lv4 = "M4A1 Lv4 / 4";
		public static string scar_lv1 = "Rifle Scar Lv1 / 4";
		public static string scar_lv2 = "Rifle Scar Lv2 / 4";
		public static string scar_lv3 = "Rifle Scar Lv3 / 4";
		public static string scar_lv4 = "Rifle Scar Lv4 / 4";
	public static string m3_lv1 = "M3 Lv1 / 1"; 
		public static string m3_lv2 = "M3 Lv2 / 2";
		public static string m3_lv3 = "M3 Lv3 / 3";
		public static string m3_lv4 = "M3 Lv4 / 4";
		public static string awp_lv1 = "AWP Lv1 / 3";
		public static string awp_lv2 = "AWP Lv2 / 3";
		public static string awp_lv3 = "AWP Lv3 / 3";
		public static string kiss_lv1 = "KRISS SUPER Lv1 / 3";
		public static string kiss_lv2 = "KRISS SUPER Lv2 / 3";
		public static string kiss_lv3 = "KRISS SUPER Lv3 / 3";
		public static string mp5_lv1 = "MP5 Lv1 / 2";
		public static string mp5_lv2 = "MP5 Lv2 / 2";
		public static string uzi_lv1 = "UZI Lv1 / 3";
		public static string uzi_lv2 = "UZI Lv2 / 3";
		public static string uzi_lv3 = "UZI Lv3 / 3";
		public static string wa_lv1 = "WA2000 Lv1 / 3";
		public static string wa_lv2 = "WA2000 Lv2 / 3";
		public static string wa_lv3 = "WA2000 Lv3 / 3";
		public static string bazooka = "BAZOOKA Lv1 / 1";	
	public static string vip1 = "HEADS SNAKE Lv1 / 1";
	public static string vip2 = "LINEAR GUN Lv1 / 1";
	public static string vip3 = "TRIO MISSILES Lv1 / 1";
		// Name of Clothers
		public static string sport = "Sport";
		public static string cowboy = "Cowboy";
		public static string mer = "Mercenaries";
	    public static string luigi = "Luigi";
		public static string gangster = "Gangster";
		public static string agent = "Agent";
		public static string mario = "I'm true plumber man.";
		public static string pijama = "Pijama";
		public static string mar = "Mar";
		public static string solider = "Solider";
		public static string tuxedo = "Tuxedo";
		public static string swat = "Swat";
	  
	    

		
		//Daily Offers
		public static int dailyCount = 1;
		public static string day1 = "You have 2 HP";
		public static string day2 = "You have 500 dollar in game";
		public static string day3 = "You have 5 grenade";
		public static string day4 = "You have 500 dollar in game";
		public static string day5 = "You have 1.000 dollar in game";
		public static string day6 = "You have 1.500 dollar in game";
		public static string day7 = "You have 2.000 dollar in game";
		public static string day8 = "You have Gangster suite";
		public static string day9 = "You have Rifle Scar gun";
		public static string day10 = "You have 100 Rifle Ammo, 100 Pistol Ammo";
		public static string day11 = "You have 100 Shotgun Ammo,15 Rocket,15 Sniper Ammo";
		public static string day12 = "You have 50 HP";
		public static string day13 = "You have 200 Sniper Ammo";
		public static string day14 = "You have Sniper AWP gun";

	    
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
		
		}
}
