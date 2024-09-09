using UnityEngine;
using System.Collections;

using OnePF;

public class ShowRoom : MonoBehaviour
{
		public GameObject panelRotation, panelFashion, panelItems, panelWeapon, panelInfoGun, panelInfoItems;
		public float rotateSpeed = -4f;
		public GameObject[] items;
		public GameObject Character;
		public dfLabel lblNumberBulletOfPistol, lblNumberBulletOfM3, lblNumberBulletOfMP5, lblNumberBulletOfUZI, lblNumberBulletOfKISS, lblNumberBulletOfM4A1, lblNumberBulletOfSCAR, lblNumberBulletOfAWP, lblNumberBulletOfWA, lblNumberBulletOfBAZOOKA, lblNumberBulletOfVip1, lblNumberBulletOfVip2, lblNumberBulletOfVip3;
		public dfLabel moneyText, labelName, labelNameOfClothers, lblUpdatePistol, lblUpdateM4a1, lblUpdateScar, lblUpdateM3, lblUpdateAwp, lblUpdateMp5, lblUpdateUzi, lblUpdateKiss, lblUpdateWa;
		public dfButton btnBuyPistol, btnBuyM4A1, btnBuyM3, btnBuyScar, btnBuyMP5, btnBuyAWP, btnBuyUZI, btnKiss, btnWa, btnBuyBazooka, btnBuyVip1, btnBuyVip2, btnBuyVip3;
		public dfButton iconPistol, iconM4A1, iconM3, iconScar, iconMP5, iconAWP, iconUZI, iconKiss, iconWA, iconBazooka, iconvip1, iconvip2, iconvip3;
		public dfPanel pistollv, scar_lv, m4a1_lv, m3_lv, awp_lv, mp5_lv, uzi_lv, kiss_lv, wa_lv;
		public dfPanel panelPistol, panelM3, panelMP5, panelUZI, panelKISS, panelM4A1, panelSCAR, panelAWP, panelWA, panelBazooka, panelVip1, panelVip2, panelVip3;
		public GameObject[] spEquip;
		public dfButton btnItems, btnWeapon, btnFashion, btnBuySport, btnBuyCowboy, btnBuyMer, btnBuyLuigi, btnBuyGangster, btnBuyAgent, btnBuyMario, btnBuyPijama, btnBuyMar, btnBuySolider, btnBuyTuxedo, btnBuySwat, btnBuysanta;
		public dfProgressBar DMG, ACC, SPEED, CATRIDGE;
		public dfPanel panelSport, panelCowboy, panelMer, panelLuigi, panelGangster, panelAgent, panelMario, panelPijama, panelMar, panelSolider, panelTuxedo, panelSwat, panelSanta;
		private int gunIndex = 0;
		public Texture[] clothes;
		public Material mt_rambo;
		public dfLabel numberofbomb, numberofshield, numberofthunder, numberofheart;
		int chiso1, chiso2, chiso3, chiso4;
		bool check_thongbao;
		float time_thongbao;
		bool check_chonsung;
		float time_chonsung;

    private static ShowRoom instance = null;
    public static ShowRoom Instance {
        get {
            if (instance == null)
                instance = new ShowRoom();
            return instance;
        }
    }

    private static int dem = 0;
		void Start ()
    {
       
        if (GoogleAnalytics.instance) {
						GoogleAnalytics.instance.LogScreen ("Screen Shop");
			
				}

				if (RamboState.huongdanshop == 0) {
						RamboState.gun_buy [1] = 0;

				}

		


				//if (RamboState.check_ads == 1) {
				//		Destroy (GameObject.Find ("Adsbolao"));
			
				//	}
				check_thongbao = false;
				time_thongbao = 0;
				//	GoogleAnalytics.instance.LogScreen ("Screen Shop");
				

				gunIndex = RamboState.state_sung;
				items [gunIndex].SetActive (true);

				#region Set Active Clothers
				if (RamboState.clothes_buy [1] == 1)
						btnBuyCowboy.Text = "EQUIP";
				else
						btnBuyCowboy.Text = "BUY";
				if (RamboState.clothes_buy [2] == 1)
						btnBuyMer.Text = "EQUIP";
				else
						btnBuyMer.Text = "BUY";
				if (RamboState.clothes_buy [3] == 1)
						btnBuyLuigi.Text = "EQUIP";
				else
						btnBuyLuigi.Text = "BUY";
				if (RamboState.clothes_buy [4] == 1)
						btnBuyGangster.Text = "EQUIP";
				else
						btnBuyGangster.Text = "BUY";
				if (RamboState.clothes_buy [5] == 1)
						btnBuyAgent.Text = "EQUIP";
				else
						btnBuyAgent.Text = "BUY";
				if (RamboState.clothes_buy [6] == 1)
						btnBuyMario.Text = "EQUIP";
				else
						btnBuyMario.Text = "BUY";
				if (RamboState.clothes_buy [7] == 1)
						btnBuyPijama.Text = "EQUIP";
				else
						btnBuyPijama.Text = "BUY";
				if (RamboState.clothes_buy [8] == 1)
						btnBuyMar.Text = "EQUIP";
				else
						btnBuyMar.Text = "BUY";
				if (RamboState.clothes_buy [9] == 1)
						btnBuySolider.Text = "EQUIP";
				else
						btnBuySolider.Text = "BUY";
				if (RamboState.clothes_buy [10] == 1)
						btnBuyTuxedo.Text = "EQUIP";
				else
						btnBuyTuxedo.Text = "BUY";
				if (RamboState.clothes_buy [11] == 1)
						btnBuySwat.Text = "EQUIP";
				else
						btnBuySwat.Text = "BUY";
				if (RamboState.clothes_buy [12] == 1)
						btnBuysanta.Text = "EQUIP";
				else
						btnBuysanta.Text = "BUY";
				if (RamboState.state_clothes == 0) {
						spEquip [10].SetActive (true);
						spEquip [11].SetActive (false);
						spEquip [12].SetActive (false);
						spEquip [13].SetActive (false);
						spEquip [14].SetActive (false);
						spEquip [15].SetActive (false);
						spEquip [16].SetActive (false);
						spEquip [17].SetActive (false);
						spEquip [18].SetActive (false);
						spEquip [19].SetActive (false);
						spEquip [20].SetActive (false);
						spEquip [21].SetActive (false);
						spEquip [22].SetActive (false);
						panelSport.BackgroundSprite = "bb_equipped";
						panelCowboy.BackgroundSprite = "bb_unequip_2";
						panelMer.BackgroundSprite = "bb_unequip_2";
						panelLuigi.BackgroundSprite = "bb_unequip_2";
						panelGangster.BackgroundSprite = "bb_unequip_2";
						panelAgent.BackgroundSprite = "bb_unequip_2";
						panelMario.BackgroundSprite = "bb_unequip_2";
						panelPijama.BackgroundSprite = "bb_unequip_2";
						panelMar.BackgroundSprite = "bb_unequip_2";
						panelSolider.BackgroundSprite = "bb_unequip_2";
						panelTuxedo.BackgroundSprite = "bb_unequip_2";
						panelSwat.BackgroundSprite = "bb_unequip_2";
						panelSanta.BackgroundSprite = "bb_unequip_2";
						mt_rambo.SetTexture (0, clothes [0]);
						btnBuySport.Text = "EQUIP";
				}
				if (RamboState.state_clothes == 1) {
						spEquip [10].SetActive (false);
						spEquip [11].SetActive (true);
						spEquip [12].SetActive (false);
						spEquip [13].SetActive (false);
						spEquip [14].SetActive (false);
						spEquip [15].SetActive (false);
						spEquip [16].SetActive (false);
						spEquip [17].SetActive (false);
						spEquip [18].SetActive (false);
						spEquip [19].SetActive (false);
						spEquip [20].SetActive (false);
						spEquip [21].SetActive (false);
						spEquip [22].SetActive (false);
						panelSport.BackgroundSprite = "bb_unequip_2";
						panelCowboy.BackgroundSprite = "bb_equipped";
						panelMer.BackgroundSprite = "bb_unequip_2";
						panelLuigi.BackgroundSprite = "bb_unequip_2";
						panelGangster.BackgroundSprite = "bb_unequip_2";
						panelAgent.BackgroundSprite = "bb_unequip_2";
						panelMario.BackgroundSprite = "bb_unequip_2";
						panelPijama.BackgroundSprite = "bb_unequip_2";
						panelMar.BackgroundSprite = "bb_unequip_2";
						panelSolider.BackgroundSprite = "bb_unequip_2";
						panelTuxedo.BackgroundSprite = "bb_unequip_2";
						panelSwat.BackgroundSprite = "bb_unequip_2";
						panelSanta.BackgroundSprite = "bb_unequip_2";
						mt_rambo.SetTexture (0, clothes [1]);
						RamboState.clothes_buy [1] = 1;
						btnBuyCowboy.Text = "EQUIP";
				}
				if (RamboState.state_clothes == 2) {
						spEquip [10].SetActive (false);
						spEquip [11].SetActive (false);
						spEquip [12].SetActive (true);
						spEquip [13].SetActive (false);
						spEquip [14].SetActive (false);
						spEquip [15].SetActive (false);
						spEquip [16].SetActive (false);
						spEquip [17].SetActive (false);
						spEquip [18].SetActive (false);
						spEquip [19].SetActive (false);
						spEquip [20].SetActive (false);
						spEquip [21].SetActive (false);
						spEquip [22].SetActive (false);
						panelSport.BackgroundSprite = "bb_unequip_2";
						panelCowboy.BackgroundSprite = "bb_unequip_2";
						panelMer.BackgroundSprite = "bb_equipped";
						panelLuigi.BackgroundSprite = "bb_unequip_2";
						panelGangster.BackgroundSprite = "bb_unequip_2";
						panelAgent.BackgroundSprite = "bb_unequip_2";
						panelMario.BackgroundSprite = "bb_unequip_2";
						panelPijama.BackgroundSprite = "bb_unequip_2";
						panelMar.BackgroundSprite = "bb_unequip_2";
						panelSolider.BackgroundSprite = "bb_unequip_2";
						panelTuxedo.BackgroundSprite = "bb_unequip_2";
						panelSwat.BackgroundSprite = "bb_unequip_2";
						panelSanta.BackgroundSprite = "bb_unequip_2";
						mt_rambo.SetTexture (0, clothes [2]);
						RamboState.clothes_buy [2] = 1;
						btnBuyMer.Text = "EQUIP";
				}
				if (RamboState.state_clothes == 3) {
						spEquip [10].SetActive (false);
						spEquip [11].SetActive (false);
						spEquip [12].SetActive (false);
						spEquip [13].SetActive (true);
						spEquip [14].SetActive (false);
						spEquip [15].SetActive (false);
						spEquip [16].SetActive (false);
						spEquip [17].SetActive (false);
						spEquip [18].SetActive (false);
						spEquip [19].SetActive (false);
						spEquip [20].SetActive (false);
						spEquip [21].SetActive (false);
						spEquip [22].SetActive (false);
						panelSport.BackgroundSprite = "bb_unequip_2";
						panelCowboy.BackgroundSprite = "bb_unequip_2";
						panelMer.BackgroundSprite = "bb_unequip_2";
						panelLuigi.BackgroundSprite = "bb_equipped";
						panelGangster.BackgroundSprite = "bb_unequip_2";
						panelAgent.BackgroundSprite = "bb_unequip_2";
						panelMario.BackgroundSprite = "bb_unequip_2";
						panelPijama.BackgroundSprite = "bb_unequip_2";
						panelMar.BackgroundSprite = "bb_unequip_2";
						panelSolider.BackgroundSprite = "bb_unequip_2";
						panelTuxedo.BackgroundSprite = "bb_unequip_2";
						panelSwat.BackgroundSprite = "bb_unequip_2";
						panelSanta.BackgroundSprite = "bb_unequip_2";
						mt_rambo.SetTexture (0, clothes [3]);
						RamboState.clothes_buy [3] = 1;
						btnBuyLuigi.Text = "EQUIP";
				}
				if (RamboState.state_clothes == 4) {
						spEquip [10].SetActive (false);
						spEquip [11].SetActive (false);
						spEquip [12].SetActive (false);
						spEquip [13].SetActive (false);
						spEquip [14].SetActive (true);
						spEquip [15].SetActive (false);
						spEquip [16].SetActive (false);
						spEquip [17].SetActive (false);
						spEquip [18].SetActive (false);
						spEquip [19].SetActive (false);
						spEquip [20].SetActive (false);
						spEquip [21].SetActive (false);
						spEquip [22].SetActive (false);
						panelSport.BackgroundSprite = "bb_unequip_2";
						panelCowboy.BackgroundSprite = "bb_unequip_2";
						panelMer.BackgroundSprite = "bb_unequip_2";
						panelLuigi.BackgroundSprite = "bb_unequip_2";
						panelGangster.BackgroundSprite = "bb_equipped";
						panelAgent.BackgroundSprite = "bb_unequip_2";
						panelMario.BackgroundSprite = "bb_unequip_2";
						panelPijama.BackgroundSprite = "bb_unequip_2";
						panelMar.BackgroundSprite = "bb_unequip_2";
						panelSolider.BackgroundSprite = "bb_unequip_2";
						panelTuxedo.BackgroundSprite = "bb_unequip_2";
						panelSwat.BackgroundSprite = "bb_unequip_2";
						panelSanta.BackgroundSprite = "bb_unequip_2";
						mt_rambo.SetTexture (0, clothes [4]);
						RamboState.clothes_buy [4] = 1;
						btnBuyGangster.Text = "EQUIP";
				}
				if (RamboState.state_clothes == 5) {
						spEquip [10].SetActive (false);
						spEquip [11].SetActive (false);
						spEquip [12].SetActive (false);
						spEquip [13].SetActive (false);
						spEquip [14].SetActive (false);
						spEquip [15].SetActive (true);
						spEquip [16].SetActive (false);
						spEquip [17].SetActive (false);
						spEquip [18].SetActive (false);
						spEquip [19].SetActive (false);
						spEquip [20].SetActive (false);
						spEquip [21].SetActive (false);
						spEquip [22].SetActive (false);
						panelSport.BackgroundSprite = "bb_unequip_2";
						panelCowboy.BackgroundSprite = "bb_unequip_2";
						panelMer.BackgroundSprite = "bb_unequip_2";
						panelLuigi.BackgroundSprite = "bb_unequip_2";
						panelGangster.BackgroundSprite = "bb_unequip_2";
						panelAgent.BackgroundSprite = "bb_equipped";
						panelMario.BackgroundSprite = "bb_unequip_2";
						panelPijama.BackgroundSprite = "bb_unequip_2";
						panelMar.BackgroundSprite = "bb_unequip_2";
						panelSolider.BackgroundSprite = "bb_unequip_2";
						panelTuxedo.BackgroundSprite = "bb_unequip_2";
						panelSwat.BackgroundSprite = "bb_unequip_2";
						panelSanta.BackgroundSprite = "bb_unequip_2";
						mt_rambo.SetTexture (0, clothes [5]);
						RamboState.clothes_buy [5] = 1;
						btnBuyAgent.Text = "EQUIP";
				}
				if (RamboState.state_clothes == 6) {
						spEquip [10].SetActive (false);
						spEquip [11].SetActive (false);
						spEquip [12].SetActive (false);
						spEquip [13].SetActive (false);
						spEquip [14].SetActive (false);
						spEquip [15].SetActive (false);
						spEquip [16].SetActive (true);
						spEquip [17].SetActive (false);
						spEquip [18].SetActive (false);
						spEquip [19].SetActive (false);
						spEquip [20].SetActive (false);
						spEquip [21].SetActive (false);
						spEquip [22].SetActive (false);
						panelSport.BackgroundSprite = "bb_unequip_2";
						panelCowboy.BackgroundSprite = "bb_unequip_2";
						panelMer.BackgroundSprite = "bb_unequip_2";
						panelLuigi.BackgroundSprite = "bb_unequip_2";
						panelGangster.BackgroundSprite = "bb_unequip_2";
						panelAgent.BackgroundSprite = "bb_unequip_2";
						panelMario.BackgroundSprite = "bb_equipped";
						panelPijama.BackgroundSprite = "bb_unequip_2";
						panelMar.BackgroundSprite = "bb_unequip_2";
						panelSolider.BackgroundSprite = "bb_unequip_2";
						panelTuxedo.BackgroundSprite = "bb_unequip_2";
						panelSwat.BackgroundSprite = "bb_unequip_2";
						panelSanta.BackgroundSprite = "bb_unequip_2";
						mt_rambo.SetTexture (0, clothes [6]);
						RamboState.clothes_buy [6] = 1;
						btnBuyMario.Text = "EQUIP";
				}
				if (RamboState.state_clothes == 7) {
						spEquip [10].SetActive (false);
						spEquip [11].SetActive (false);
						spEquip [12].SetActive (false);
						spEquip [13].SetActive (false);
						spEquip [14].SetActive (false);
						spEquip [15].SetActive (false);
						spEquip [16].SetActive (false);
						spEquip [17].SetActive (true);
						spEquip [18].SetActive (false);
						spEquip [19].SetActive (false);
						spEquip [20].SetActive (false);
						spEquip [21].SetActive (false);
						spEquip [22].SetActive (false);
						panelSport.BackgroundSprite = "bb_unequip_2";
						panelCowboy.BackgroundSprite = "bb_unequip_2";
						panelMer.BackgroundSprite = "bb_unequip_2";
						panelLuigi.BackgroundSprite = "bb_unequip_2";
						panelGangster.BackgroundSprite = "bb_unequip_2";
						panelAgent.BackgroundSprite = "bb_unequip_2";
						panelMario.BackgroundSprite = "bb_unequip_2";
						panelPijama.BackgroundSprite = "bb_equipped";
						panelMar.BackgroundSprite = "bb_unequip_2";
						panelSolider.BackgroundSprite = "bb_unequip_2";
						panelTuxedo.BackgroundSprite = "bb_unequip_2";
						panelSwat.BackgroundSprite = "bb_unequip_2";
						panelSanta.BackgroundSprite = "bb_unequip_2";
						mt_rambo.SetTexture (0, clothes [7]);
						RamboState.clothes_buy [7] = 1;
						btnBuyPijama.Text = "EQUIP";
				}
				if (RamboState.state_clothes == 8) {
						spEquip [10].SetActive (false);
						spEquip [11].SetActive (false);
						spEquip [12].SetActive (false);
						spEquip [13].SetActive (false);
						spEquip [14].SetActive (false);
						spEquip [15].SetActive (false);
						spEquip [16].SetActive (false);
						spEquip [17].SetActive (false);
						spEquip [18].SetActive (true);
						spEquip [19].SetActive (false);
						spEquip [20].SetActive (false);
						spEquip [21].SetActive (false);
						spEquip [22].SetActive (false);
						panelSport.BackgroundSprite = "bb_unequip_2";
						panelCowboy.BackgroundSprite = "bb_unequip_2";
						panelMer.BackgroundSprite = "bb_unequip_2";
						panelLuigi.BackgroundSprite = "bb_unequip_2";
						panelGangster.BackgroundSprite = "bb_unequip_2";
						panelAgent.BackgroundSprite = "bb_unequip_2";
						panelMario.BackgroundSprite = "bb_unequip_2";
						panelPijama.BackgroundSprite = "bb_unequip_2";
						panelMar.BackgroundSprite = "bb_equipped";
						panelSolider.BackgroundSprite = "bb_unequip_2";
						panelTuxedo.BackgroundSprite = "bb_unequip_2";
						panelSwat.BackgroundSprite = "bb_unequip_2";
						panelSanta.BackgroundSprite = "bb_unequip_2";
						mt_rambo.SetTexture (0, clothes [8]);
						RamboState.clothes_buy [8] = 1;
						btnBuyMar.Text = "EQUIP";
				}
				if (RamboState.state_clothes == 9) {
						spEquip [10].SetActive (false);
						spEquip [11].SetActive (false);
						spEquip [12].SetActive (false);
						spEquip [13].SetActive (false);
						spEquip [14].SetActive (false);
						spEquip [15].SetActive (false);
						spEquip [16].SetActive (false);
						spEquip [17].SetActive (false);
						spEquip [18].SetActive (false);
						spEquip [19].SetActive (true);
						spEquip [20].SetActive (false);
						spEquip [21].SetActive (false);
						spEquip [22].SetActive (false);
						panelSport.BackgroundSprite = "bb_unequip_2";
						panelCowboy.BackgroundSprite = "bb_unequip_2";
						panelMer.BackgroundSprite = "bb_unequip_2";
						panelLuigi.BackgroundSprite = "bb_unequip_2";
						panelGangster.BackgroundSprite = "bb_unequip_2";
						panelAgent.BackgroundSprite = "bb_unequip_2";
						panelMario.BackgroundSprite = "bb_unequip_2";
						panelPijama.BackgroundSprite = "bb_unequip_2";
						panelMar.BackgroundSprite = "bb_unequip_2";
						panelSolider.BackgroundSprite = "bb_equipped";
						panelTuxedo.BackgroundSprite = "bb_unequip_2";
						panelSwat.BackgroundSprite = "bb_unequip_2";
						panelSanta.BackgroundSprite = "bb_unequip_2";
						mt_rambo.SetTexture (0, clothes [9]);
						RamboState.clothes_buy [9] = 1;
						btnBuySolider.Text = "EQUIP";
				}
				if (RamboState.state_clothes == 10) {
						spEquip [10].SetActive (false);
						spEquip [11].SetActive (false);
						spEquip [12].SetActive (false);
						spEquip [13].SetActive (false);
						spEquip [14].SetActive (false);
						spEquip [15].SetActive (false);
						spEquip [16].SetActive (false);
						spEquip [17].SetActive (false);
						spEquip [18].SetActive (false);
						spEquip [19].SetActive (false);
						spEquip [20].SetActive (true);
						spEquip [21].SetActive (false);
						spEquip [22].SetActive (false);
						panelSport.BackgroundSprite = "bb_unequip_2";
						panelCowboy.BackgroundSprite = "bb_unequip_2";
						panelMer.BackgroundSprite = "bb_unequip_2";
						panelLuigi.BackgroundSprite = "bb_unequip_2";
						panelGangster.BackgroundSprite = "bb_unequip_2";
						panelAgent.BackgroundSprite = "bb_unequip_2";
						panelMario.BackgroundSprite = "bb_unequip_2";
						panelPijama.BackgroundSprite = "bb_unequip_2";
						panelMar.BackgroundSprite = "bb_unequip_2";
						panelSolider.BackgroundSprite = "bb_unequip_2";
						panelTuxedo.BackgroundSprite = "bb_equipped";
						panelSwat.BackgroundSprite = "bb_unequip_2";
						panelSanta.BackgroundSprite = "bb_unequip_2";
						mt_rambo.SetTexture (0, clothes [10]);
						RamboState.clothes_buy [10] = 1;
						btnBuyTuxedo.Text = "EQUIP";
				}
				if (RamboState.state_clothes == 11) {
						spEquip [10].SetActive (false);
						spEquip [11].SetActive (false);
						spEquip [12].SetActive (false);
						spEquip [13].SetActive (false);
						spEquip [14].SetActive (false);
						spEquip [15].SetActive (false);
						spEquip [16].SetActive (false);
						spEquip [17].SetActive (false);
						spEquip [18].SetActive (false);
						spEquip [19].SetActive (false);
						spEquip [20].SetActive (false);
						spEquip [21].SetActive (true);
						spEquip [22].SetActive (false);
						panelSport.BackgroundSprite = "bb_unequip_2";
						panelCowboy.BackgroundSprite = "bb_unequip_2";
						panelMer.BackgroundSprite = "bb_unequip_2";
						panelLuigi.BackgroundSprite = "bb_unequip_2";
						panelGangster.BackgroundSprite = "bb_unequip_2";
						panelAgent.BackgroundSprite = "bb_unequip_2";
						panelMario.BackgroundSprite = "bb_unequip_2";
						panelPijama.BackgroundSprite = "bb_unequip_2";
						panelMar.BackgroundSprite = "bb_unequip_2";
						panelSolider.BackgroundSprite = "bb_unequip_2";
						panelTuxedo.BackgroundSprite = "bb_unequip_2";
						panelSwat.BackgroundSprite = "bb_equipped";
						panelSanta.BackgroundSprite = "bb_unequip_2";
						mt_rambo.SetTexture (0, clothes [11]);
						RamboState.clothes_buy [11] = 1;
						btnBuySwat.Text = "EQUIP";
				}

				if (RamboState.state_clothes == 12) {
						spEquip [10].SetActive (false);
						spEquip [11].SetActive (false);
						spEquip [12].SetActive (false);
						spEquip [13].SetActive (false);
						spEquip [14].SetActive (false);
						spEquip [15].SetActive (false);
						spEquip [16].SetActive (false);
						spEquip [17].SetActive (false);
						spEquip [18].SetActive (false);
						spEquip [19].SetActive (false);
						spEquip [20].SetActive (false);
						spEquip [21].SetActive (false);
						spEquip [22].SetActive (true);
						panelSport.BackgroundSprite = "bb_unequip_2";
						panelCowboy.BackgroundSprite = "bb_unequip_2";
						panelMer.BackgroundSprite = "bb_unequip_2";
						panelLuigi.BackgroundSprite = "bb_unequip_2";
						panelGangster.BackgroundSprite = "bb_unequip_2";
						panelAgent.BackgroundSprite = "bb_unequip_2";
						panelMario.BackgroundSprite = "bb_unequip_2";
						panelPijama.BackgroundSprite = "bb_unequip_2";
						panelMar.BackgroundSprite = "bb_unequip_2";
						panelSolider.BackgroundSprite = "bb_unequip_2";
						panelTuxedo.BackgroundSprite = "bb_unequip_2";
						panelSwat.BackgroundSprite = "bb_unequip_2";
						panelSanta.BackgroundSprite = "bb_equipped";
						mt_rambo.SetTexture (0, clothes [12]);
						RamboState.clothes_buy [12] = 1;
						btnBuysanta.Text = "EQUIP";
				}

				#endregion

				#region Load Equip Gun
				if (RamboState.state_sung == 0 || RamboState.state_sung == 1 || RamboState.state_sung == 2) {
						#region Pistol
						spEquip [0].SetActive (true);
						spEquip [1].SetActive (false);
						spEquip [2].SetActive (false);
						spEquip [3].SetActive (false);
						spEquip [4].SetActive (false);
						spEquip [5].SetActive (false);
						spEquip [6].SetActive (false);
						spEquip [7].SetActive (false);
						spEquip [8].SetActive (false);
						spEquip [9].SetActive (false);
						spEquip [23].SetActive (false);
						spEquip [24].SetActive (false);
						spEquip [25].SetActive (false);

						panelVip1.BackgroundSprite = "bb_unequip";
						panelVip2.BackgroundSprite = "bb_unequip";
						panelVip3.BackgroundSprite = "bb_unequip";

						panelPistol.BackgroundSprite = "bb_equip";
						panelM3.BackgroundSprite = "bb_unequip";
						panelMP5.BackgroundSprite = "bb_unequip";
						panelUZI.BackgroundSprite = "bb_unequip";
						panelKISS.BackgroundSprite = "bb_unequip";
						panelAWP.BackgroundSprite = "bb_unequip";
						panelSCAR.BackgroundSprite = "bb_unequip";
						panelWA.BackgroundSprite = "bb_unequip";
						panelBazooka.BackgroundSprite = "bb_unequip";
						panelM4A1.BackgroundSprite = "bb_unequip";

						DMG.Value = 1f;




						if (RamboState.state_sung == 1) {
								DMG.Value = 0.4f;
								SPEED.Value = 0.4f;
								ACC.Value = 0.2f;
								CATRIDGE.Value = 0.2f;
								labelName.Text = RamboState.pistol_lv2;
								pistollv.BackgroundSprite = "Pistol_FiveSeven_2";
								chiso1 = 0;
								chiso2 = 2;
								chiso3 = 0;
								chiso4 = 2;
						} else if (RamboState.state_sung == 2) {
								pistollv.BackgroundSprite = "Pistol_FiveSeven_3";
								DMG.Value = 0.4f;
								SPEED.Value = 0.4f;
								ACC.Value = 0.2f;
								CATRIDGE.Value = 0.4f;
								labelName.Text = RamboState.pistol_lv3;
								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 0;
								chiso4 = 0;
						}
						#endregion
				} else if (RamboState.state_sung == 3 || RamboState.state_sung == 4 || RamboState.state_sung == 5 || RamboState.state_sung == 6) {
						#region M3
						spEquip [0].SetActive (false);
						spEquip [1].SetActive (true);
						spEquip [2].SetActive (false);
						spEquip [3].SetActive (false);
						spEquip [4].SetActive (false);
						spEquip [5].SetActive (false);
						spEquip [6].SetActive (false);
						spEquip [7].SetActive (false);
						spEquip [8].SetActive (false);
						spEquip [9].SetActive (false);
						spEquip [23].SetActive (false);
						spEquip [24].SetActive (false);
						spEquip [25].SetActive (false);
			
						panelVip1.BackgroundSprite = "bb_unequip";
						panelVip2.BackgroundSprite = "bb_unequip";
						panelVip3.BackgroundSprite = "bb_unequip";
						panelPistol.BackgroundSprite = "bb_unequip";
						panelM3.BackgroundSprite = "bb_equip";
						panelMP5.BackgroundSprite = "bb_unequip";
						panelUZI.BackgroundSprite = "bb_unequip";
						panelKISS.BackgroundSprite = "bb_unequip";
						panelAWP.BackgroundSprite = "bb_unequip";
						panelSCAR.BackgroundSprite = "bb_unequip";
						panelWA.BackgroundSprite = "bb_unequip";
						panelBazooka.BackgroundSprite = "bb_unequip";
						panelM4A1.BackgroundSprite = "bb_unequip";

						if (RamboState.state_sung == 3) {
								DMG.Value = 0.6f;
								SPEED.Value = 0.2f;
								ACC.Value = 0.2f;
								CATRIDGE.Value = 0.2f;
								labelName.Text = RamboState.m3_lv1;
								chiso1 = 0;
								chiso2 = 2;
								chiso3 = 0;
								chiso4 = 0;
						} else 
						if (RamboState.state_sung == 4) {
								DMG.Value = 0.6f;
								SPEED.Value = 0.4f;
								ACC.Value = 0.2f;
								CATRIDGE.Value = 0.2f;
								labelName.Text = RamboState.m3_lv2;
								chiso1 = 2;
								chiso2 = 0;
								chiso3 = 0;
								chiso4 = 4;
								m3_lv.BackgroundSprite = "ShortGun_M3_2";

						} else if (RamboState.state_sung == 5) {
								DMG.Value = 0.8f;
								SPEED.Value = 0.4f;
								ACC.Value = 0.2f;
								CATRIDGE.Value = 0.6f;
								labelName.Text = RamboState.m3_lv3;
								chiso1 = 0;
								chiso2 = 2;
								chiso3 = 0;
								chiso4 = 0;
								m3_lv.BackgroundSprite = "ShortGun_M3_3";
						} else if (RamboState.state_sung == 6) {
								DMG.Value = 0.8f;
								SPEED.Value = 0.6f;
								ACC.Value = 0.2f;
								CATRIDGE.Value = 0.6f;
								labelName.Text = RamboState.m3_lv4;
								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 0;
								chiso4 = 0;
								m3_lv.BackgroundSprite = "ShortGun_M3_4";
						}
						#endregion
				} else if (RamboState.state_sung == 7 || RamboState.state_sung == 8) {
						#region MP5
						spEquip [0].SetActive (false);
						spEquip [1].SetActive (false);
						spEquip [2].SetActive (true);
						spEquip [3].SetActive (false);
						spEquip [4].SetActive (false);
						spEquip [5].SetActive (false);
						spEquip [6].SetActive (false);
						spEquip [7].SetActive (false);
						spEquip [8].SetActive (false);
						spEquip [9].SetActive (false);
						spEquip [23].SetActive (false);
						spEquip [24].SetActive (false);
						spEquip [25].SetActive (false);
			
						panelVip1.BackgroundSprite = "bb_unequip";
						panelVip2.BackgroundSprite = "bb_unequip";
						panelVip3.BackgroundSprite = "bb_unequip";
						panelPistol.BackgroundSprite = "bb_unequip";
						panelM3.BackgroundSprite = "bb_unequip";
						panelMP5.BackgroundSprite = "bb_equip";
						panelUZI.BackgroundSprite = "bb_unequip";
						panelKISS.BackgroundSprite = "bb_unequip";
						panelAWP.BackgroundSprite = "bb_unequip";
						panelSCAR.BackgroundSprite = "bb_unequip";
						panelWA.BackgroundSprite = "bb_unequip";
						panelBazooka.BackgroundSprite = "bb_unequip";
						panelM4A1.BackgroundSprite = "bb_unequip";
						if (RamboState.state_sung == 7) {
								DMG.Value = 0.2f;
								SPEED.Value = 0.2f;
								ACC.Value = 0.6f;
								CATRIDGE.Value = 0.2f;
								labelName.Text = RamboState.mp5_lv1;
								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 4;
								chiso4 = 0;
						} else 
						if (RamboState.state_sung == 8) {
								DMG.Value = 0.2f;
								SPEED.Value = 0.2f;
								ACC.Value = 1;
								CATRIDGE.Value = 0.2f;
								labelName.Text = RamboState.mp5_lv2;
						}
						#endregion
				} else if (RamboState.state_sung == 9 || RamboState.state_sung == 10 || RamboState.state_sung == 11) {
						#region UZI
						spEquip [0].SetActive (false);
						spEquip [1].SetActive (false);
						spEquip [2].SetActive (false);
						spEquip [3].SetActive (true);
						spEquip [4].SetActive (false);
						spEquip [5].SetActive (false);
						spEquip [6].SetActive (false);
						spEquip [7].SetActive (false);
						spEquip [8].SetActive (false);
						spEquip [9].SetActive (false);
						spEquip [23].SetActive (false);
						spEquip [24].SetActive (false);
						spEquip [25].SetActive (false);
			
						panelVip1.BackgroundSprite = "bb_unequip";
						panelVip2.BackgroundSprite = "bb_unequip";
						panelVip3.BackgroundSprite = "bb_unequip";
						panelPistol.BackgroundSprite = "bb_unequip";
						panelM3.BackgroundSprite = "bb_unequip";
						panelMP5.BackgroundSprite = "bb_unequip";
						panelUZI.BackgroundSprite = "bb_equip";
						panelKISS.BackgroundSprite = "bb_unequip";
						panelAWP.BackgroundSprite = "bb_unequip";
						panelSCAR.BackgroundSprite = "bb_unequip";
						panelWA.BackgroundSprite = "bb_unequip";
						panelBazooka.BackgroundSprite = "bb_unequip";
						panelM4A1.BackgroundSprite = "bb_unequip";
						if (RamboState.state_sung == 9) {
								DMG.Value = 0.2f;
								SPEED.Value = 0.2f;
								ACC.Value = 0.4f;
								CATRIDGE.Value = 0.4f;
								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 2;
								chiso4 = 2;
								labelName.Text = RamboState.uzi_lv1;
						} else 

						
						if (RamboState.state_sung == 10) {
								DMG.Value = 0.2f;
								SPEED.Value = 0.2f;
								ACC.Value = 0.6f;
								CATRIDGE.Value = 0.6f;
								labelName.Text = RamboState.uzi_lv2;
								chiso1 = 4;
								chiso2 = 0;
								chiso3 = 0;
								chiso4 = 0;
						} else if (RamboState.state_sung == 11) {
								DMG.Value = 0.6f;
								SPEED.Value = 0.2f;
								ACC.Value = 0.6f;
								CATRIDGE.Value = 0.6f;
								labelName.Text = RamboState.uzi_lv3;
								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 0;
								chiso4 = 0;
						}
						#endregion
				} else if (RamboState.state_sung == 12 || RamboState.state_sung == 13 || RamboState.state_sung == 14) {
						#region KISS
						spEquip [0].SetActive (false);
						spEquip [1].SetActive (false);
						spEquip [2].SetActive (false);
						spEquip [3].SetActive (false);
						spEquip [4].SetActive (true);
						spEquip [5].SetActive (false);
						spEquip [6].SetActive (false);
						spEquip [7].SetActive (false);
						spEquip [8].SetActive (false);
						spEquip [9].SetActive (false);
						spEquip [23].SetActive (false);
						spEquip [24].SetActive (false);
						spEquip [25].SetActive (false);
			
						panelVip1.BackgroundSprite = "bb_unequip";
						panelVip2.BackgroundSprite = "bb_unequip";
						panelVip3.BackgroundSprite = "bb_unequip";
						panelPistol.BackgroundSprite = "bb_unequip";
						panelM3.BackgroundSprite = "bb_unequip";
						panelMP5.BackgroundSprite = "bb_unequip";
						panelUZI.BackgroundSprite = "bb_unequip";
						panelKISS.BackgroundSprite = "bb_equip";
						panelAWP.BackgroundSprite = "bb_unequip";
						panelSCAR.BackgroundSprite = "bb_unequip";
						panelWA.BackgroundSprite = "bb_unequip";
						panelBazooka.BackgroundSprite = "bb_unequip";
						panelM4A1.BackgroundSprite = "bb_unequip";
						if (RamboState.state_sung == 12) {
								DMG.Value = 0.2f;
								SPEED.Value = 0.6f;
								ACC.Value = 0.2f;
								CATRIDGE.Value = 0.2f;
								labelName.Text = RamboState.kiss_lv1;
								chiso1 = 0;
								chiso2 = 2;
								chiso3 = 0;
								chiso4 = 0;
						} else
						if (RamboState.state_sung == 13) {
								DMG.Value = 0.2f;
								SPEED.Value = 0.8f;
								ACC.Value = 0.2f;
								CATRIDGE.Value = 0.2f;
								labelName.Text = RamboState.kiss_lv2;
								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 0;
								chiso4 = 2;
						} else if (RamboState.state_sung == 14) {
								DMG.Value = 0.2f;
								SPEED.Value = 0.8f;
								ACC.Value = 0.2f;
								CATRIDGE.Value = 0.4f;
								labelName.Text = RamboState.kiss_lv3;
						}
						#endregion
				} else if (RamboState.state_sung == 15 || RamboState.state_sung == 16 || RamboState.state_sung == 17 || RamboState.state_sung == 18) {
						#region M4A1
						spEquip [0].SetActive (false);
						spEquip [1].SetActive (false);
						spEquip [2].SetActive (false);
						spEquip [3].SetActive (false);
						spEquip [4].SetActive (false);
						spEquip [5].SetActive (true);
						spEquip [6].SetActive (false);
						spEquip [7].SetActive (false);
						spEquip [8].SetActive (false);
						spEquip [9].SetActive (false);
						spEquip [23].SetActive (false);
						spEquip [24].SetActive (false);
						spEquip [25].SetActive (false);
			
						panelVip1.BackgroundSprite = "bb_unequip";
						panelVip2.BackgroundSprite = "bb_unequip";
						panelVip3.BackgroundSprite = "bb_unequip";
						panelPistol.BackgroundSprite = "bb_unequip";
						panelM3.BackgroundSprite = "bb_unequip";
						panelMP5.BackgroundSprite = "bb_unequip";
						panelUZI.BackgroundSprite = "bb_unequip";
						panelKISS.BackgroundSprite = "bb_unequip";
						panelAWP.BackgroundSprite = "bb_unequip";
						panelSCAR.BackgroundSprite = "bb_unequip";
						panelWA.BackgroundSprite = "bb_unequip";
						panelBazooka.BackgroundSprite = "bb_unequip";
						panelM4A1.BackgroundSprite = "bb_equip";
						if (RamboState.state_sung == 15) {
								DMG.Value = 0.6f;
								SPEED.Value = 0.4f;
								ACC.Value = 0.2f;
								CATRIDGE.Value = 0.2f;
								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 2;
								chiso4 = 0;

								labelName.Text = RamboState.m4a1_lv1;
						} else 
						if (RamboState.state_sung == 16) {
								DMG.Value = 0.6f;
								SPEED.Value = 0.4f;
								ACC.Value = 0.4f;
								CATRIDGE.Value = 0.2f;
								labelName.Text = RamboState.m4a1_lv2;
								m4a1_lv.BackgroundSprite = "Rifle_M4A1_2";
								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 0;
								chiso4 = 2;
						} else if (RamboState.state_sung == 17) {
								DMG.Value = 0.6f;
								SPEED.Value = 0.4f;
								ACC.Value = 0.4f;
								CATRIDGE.Value = 0.4f;
								labelName.Text = RamboState.m4a1_lv3;
								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 0;
								chiso4 = 2;
								m4a1_lv.BackgroundSprite = "Rifle_M4A1_3";
						} else if (RamboState.state_sung == 18) {
								DMG.Value = 0.6f;
								SPEED.Value = 0.4f;
								ACC.Value = 0.4f;
								CATRIDGE.Value = 0.6f;
								labelName.Text = RamboState.m4a1_lv4;
								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 0;
								chiso4 = 0;
								m4a1_lv.BackgroundSprite = "Rifle_M4A1_4";
						}
						#endregion
				} else if (RamboState.state_sung == 19 || RamboState.state_sung == 20 || RamboState.state_sung == 21 || RamboState.state_sung == 22) {
						#region SCAR
						spEquip [0].SetActive (false);
						spEquip [1].SetActive (false);
						spEquip [2].SetActive (false);
						spEquip [3].SetActive (false);
						spEquip [4].SetActive (false);
						spEquip [5].SetActive (false);
						spEquip [6].SetActive (true);
						spEquip [7].SetActive (false);
						spEquip [8].SetActive (false);
						spEquip [9].SetActive (false);
						spEquip [23].SetActive (false);
						spEquip [24].SetActive (false);
						spEquip [25].SetActive (false);
			
						panelVip1.BackgroundSprite = "bb_unequip";
						panelVip2.BackgroundSprite = "bb_unequip";
						panelVip3.BackgroundSprite = "bb_unequip";
						panelPistol.BackgroundSprite = "bb_unequip";
						panelM3.BackgroundSprite = "bb_unequip";
						panelMP5.BackgroundSprite = "bb_unequip";
						panelUZI.BackgroundSprite = "bb_unequip";
						panelKISS.BackgroundSprite = "bb_unequip";
						panelAWP.BackgroundSprite = "bb_unequip";
						panelSCAR.BackgroundSprite = "bb_equip";
						panelWA.BackgroundSprite = "bb_unequip";
						panelBazooka.BackgroundSprite = "bb_unequip";
						panelM4A1.BackgroundSprite = "bb_unequip";
						if (RamboState.state_sung == 19) {
								DMG.Value = 0.6f;
								SPEED.Value = 0.6f;
								ACC.Value = 0.2f;
								CATRIDGE.Value = 0.2f;
								chiso1 = 0;
								chiso2 = 2;
								chiso3 = 0;
								chiso4 = 0;

								labelName.Text = RamboState.scar_lv1;
						} else 
						if (RamboState.state_sung == 20) {
								DMG.Value = 0.6f;
								SPEED.Value = 0.8f;
								ACC.Value = 0.2f;
								CATRIDGE.Value = 0.2f;
								labelName.Text = RamboState.scar_lv2;
								scar_lv.BackgroundSprite = "Rifle_Scar_2";
								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 2;
								chiso4 = 0;
						} else if (RamboState.state_sung == 21) {
								DMG.Value = 0.6f;
								SPEED.Value = 0.8f;
								ACC.Value = 0.4f;
								CATRIDGE.Value = 0.2f;
								labelName.Text = RamboState.scar_lv3;
								scar_lv.BackgroundSprite = "Rifle_Scar_3";
								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 2;
								chiso4 = 0;
						} else if (RamboState.state_sung == 22) {
								DMG.Value = 0.6f;
								SPEED.Value = 0.8f;
								ACC.Value = 0.6f;
								CATRIDGE.Value = 0.2f;
								labelName.Text = RamboState.scar_lv4;
								scar_lv.BackgroundSprite = "Rifle_Scar_4";
								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 0;
								chiso4 = 0;
						}
						#endregion
				} else if (RamboState.state_sung == 23 || RamboState.state_sung == 24 || RamboState.state_sung == 25) {
						#region AWP
						spEquip [0].SetActive (false);
						spEquip [1].SetActive (false);
						spEquip [2].SetActive (false);
						spEquip [3].SetActive (false);
						spEquip [4].SetActive (false);
						spEquip [5].SetActive (false);
						spEquip [6].SetActive (false);
						spEquip [7].SetActive (true);
						spEquip [8].SetActive (false);
						spEquip [9].SetActive (false);
						spEquip [23].SetActive (false);
						spEquip [24].SetActive (false);
						spEquip [25].SetActive (false);
			
						panelVip1.BackgroundSprite = "bb_unequip";
						panelVip2.BackgroundSprite = "bb_unequip";
						panelVip3.BackgroundSprite = "bb_unequip";
						panelPistol.BackgroundSprite = "bb_unequip";
						panelM3.BackgroundSprite = "bb_unequip";
						panelMP5.BackgroundSprite = "bb_unequip";
						panelUZI.BackgroundSprite = "bb_unequip";
						panelKISS.BackgroundSprite = "bb_unequip";
						panelAWP.BackgroundSprite = "bb_equip";
						panelSCAR.BackgroundSprite = "bb_unequip";
						panelWA.BackgroundSprite = "bb_unequip";
						panelBazooka.BackgroundSprite = "bb_unequip";
						panelM4A1.BackgroundSprite = "bb_unequip";
						if (RamboState.state_sung == 23) {
								DMG.Value = 1f;
								SPEED.Value = 0.2f;
								ACC.Value = 0.6f;
								CATRIDGE.Value = 0.2f;
								labelName.Text = RamboState.awp_lv1;
								chiso1 = 0;
								chiso2 = 2;
								chiso3 = 0;
								chiso4 = 0;
						} else 
						if (RamboState.state_sung == 24) {
								DMG.Value = 1f;
								SPEED.Value = 0.4f;
								ACC.Value = 0.6f;
								CATRIDGE.Value = 0.2f;
								labelName.Text = RamboState.awp_lv2;
								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 0;
								chiso4 = 2;
						} else if (RamboState.state_sung == 25) {
								DMG.Value = 1f;
								SPEED.Value = 0.4f;
								ACC.Value = 0.6f;
								CATRIDGE.Value = 0.4f;
								labelName.Text = RamboState.awp_lv3;
								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 0;
								chiso4 = 0;
						}
						#endregion
				} else if (RamboState.state_sung == 26 || RamboState.state_sung == 27 || RamboState.state_sung == 28) {
						#region WA
						spEquip [0].SetActive (false);
						spEquip [1].SetActive (false);
						spEquip [2].SetActive (false);
						spEquip [3].SetActive (false);
						spEquip [4].SetActive (false);
						spEquip [5].SetActive (false);
						spEquip [6].SetActive (false);
						spEquip [7].SetActive (false);
						spEquip [8].SetActive (true);
						spEquip [9].SetActive (false);
						spEquip [23].SetActive (false);
						spEquip [24].SetActive (false);
						spEquip [25].SetActive (false);
			
						panelVip1.BackgroundSprite = "bb_unequip";
						panelVip2.BackgroundSprite = "bb_unequip";
						panelVip3.BackgroundSprite = "bb_unequip";
						panelPistol.BackgroundSprite = "bb_unequip";
						panelM3.BackgroundSprite = "bb_unequip";
						panelMP5.BackgroundSprite = "bb_unequip";
						panelUZI.BackgroundSprite = "bb_unequip";
						panelKISS.BackgroundSprite = "bb_unequip";
						panelAWP.BackgroundSprite = "bb_unequip";
						panelSCAR.BackgroundSprite = "bb_unequip";
						panelWA.BackgroundSprite = "bb_equip";
						panelBazooka.BackgroundSprite = "bb_unequip";
						panelM4A1.BackgroundSprite = "bb_unequip";
						if (RamboState.state_sung == 26) {
								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 0;
								chiso4 = 4;

								DMG.Value = 0.8f;
								SPEED.Value = 0.2f;
								ACC.Value = 0.6f;
								CATRIDGE.Value = 0.2f;
								labelName.Text = RamboState.wa_lv1;
						} else 
						if (RamboState.state_sung == 27) {
								DMG.Value = 0.8f;
								SPEED.Value = 0.2f;
								ACC.Value = 0.6f;
								CATRIDGE.Value = 0.6f;
								labelName.Text = RamboState.wa_lv2;
								chiso1 = 2;
								chiso2 = 0;
								chiso3 = 2;
								chiso4 = 0;
						} else if (RamboState.state_sung == 28) {
								DMG.Value = 1f;
								SPEED.Value = 0.2f;
								ACC.Value = 0.8f;
								CATRIDGE.Value = 0.6f;
								labelName.Text = RamboState.wa_lv3;
								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 0;
								chiso4 = 0;
						}
						#endregion
				} else if (RamboState.state_sung == 29) {
						#region Bazooka
						spEquip [0].SetActive (false);
						spEquip [1].SetActive (false);
						spEquip [2].SetActive (false);
						spEquip [3].SetActive (false);
						spEquip [4].SetActive (false);
						spEquip [5].SetActive (false);
						spEquip [6].SetActive (false);
						spEquip [7].SetActive (false);
						spEquip [8].SetActive (false);
						spEquip [9].SetActive (true);
						spEquip [23].SetActive (false);
						spEquip [24].SetActive (false);
						spEquip [25].SetActive (false);
			
						panelVip1.BackgroundSprite = "bb_unequip";
						panelVip2.BackgroundSprite = "bb_unequip";
						panelVip3.BackgroundSprite = "bb_unequip";
						panelPistol.BackgroundSprite = "bb_unequip";
						panelM3.BackgroundSprite = "bb_unequip";
						panelMP5.BackgroundSprite = "bb_unequip";
						panelUZI.BackgroundSprite = "bb_unequip";
						panelKISS.BackgroundSprite = "bb_unequip";
						panelAWP.BackgroundSprite = "bb_unequip";
						panelSCAR.BackgroundSprite = "bb_unequip";
						panelWA.BackgroundSprite = "bb_unequip";
						panelBazooka.BackgroundSprite = "bb_equip";
						panelM4A1.BackgroundSprite = "bb_unequip";
						DMG.Value = 1f;
						SPEED.Value = 0.2f;
						ACC.Value = 1f;
						CATRIDGE.Value = 0.2f;
						labelName.Text = RamboState.bazooka;
						chiso1 = 0;
						chiso2 = 0;
						chiso3 = 0;
						chiso4 = 0;
						#endregion
				} else if (RamboState.state_sung == 30) {
						#region Vip1
						spEquip [0].SetActive (false);
						spEquip [1].SetActive (false);
						spEquip [2].SetActive (false);
						spEquip [3].SetActive (false);
						spEquip [4].SetActive (false);
						spEquip [5].SetActive (false);
						spEquip [6].SetActive (false);
						spEquip [7].SetActive (false);
						spEquip [8].SetActive (false);
						spEquip [9].SetActive (false);
						spEquip [23].SetActive (true);
						spEquip [24].SetActive (false);
						spEquip [25].SetActive (false);
			
						panelVip1.BackgroundSprite = "bb_equip";
						panelVip2.BackgroundSprite = "bb_unequip";
						panelVip3.BackgroundSprite = "bb_unequip";
						panelPistol.BackgroundSprite = "bb_unequip";
						panelM3.BackgroundSprite = "bb_unequip";
						panelMP5.BackgroundSprite = "bb_unequip";
						panelUZI.BackgroundSprite = "bb_unequip";
						panelKISS.BackgroundSprite = "bb_unequip";
						panelAWP.BackgroundSprite = "bb_unequip";
						panelSCAR.BackgroundSprite = "bb_unequip";
						panelWA.BackgroundSprite = "bb_unequip";
						panelBazooka.BackgroundSprite = "bb_unequip";
						panelM4A1.BackgroundSprite = "bb_unequip";
						DMG.Value = 1f;
						SPEED.Value = 0.2f;
						ACC.Value = 1f;
						CATRIDGE.Value = 0.2f;
						labelName.Text = RamboState.vip1;
						chiso1 = 0;
						chiso2 = 0;
						chiso3 = 0;
						chiso4 = 0;
						#endregion
				} else if (RamboState.state_sung == 31) {
						#region Vip2
						spEquip [0].SetActive (false);
						spEquip [1].SetActive (false);
						spEquip [2].SetActive (false);
						spEquip [3].SetActive (false);
						spEquip [4].SetActive (false);
						spEquip [5].SetActive (false);
						spEquip [6].SetActive (false);
						spEquip [7].SetActive (false);
						spEquip [8].SetActive (false);
						spEquip [9].SetActive (false);
						spEquip [23].SetActive (false);
						spEquip [24].SetActive (true);
						spEquip [25].SetActive (false);
			
						panelVip1.BackgroundSprite = "bb_unequip";
						panelVip2.BackgroundSprite = "bb_equip";
						panelVip3.BackgroundSprite = "bb_unequip";
						panelPistol.BackgroundSprite = "bb_unequip";
						panelM3.BackgroundSprite = "bb_unequip";
						panelMP5.BackgroundSprite = "bb_unequip";
						panelUZI.BackgroundSprite = "bb_unequip";
						panelKISS.BackgroundSprite = "bb_unequip";
						panelAWP.BackgroundSprite = "bb_unequip";
						panelSCAR.BackgroundSprite = "bb_unequip";
						panelWA.BackgroundSprite = "bb_unequip";
						panelBazooka.BackgroundSprite = "bb_unequip";
						panelM4A1.BackgroundSprite = "bb_unequip";
						DMG.Value = 1f;
						SPEED.Value = 0.2f;
						ACC.Value = 1f;
						CATRIDGE.Value = 0.2f;
						labelName.Text = RamboState.vip2;
						chiso1 = 0;
						chiso2 = 0;
						chiso3 = 0;
						chiso4 = 0;
						#endregion
				} else if (RamboState.state_sung == 32) {
						#region Bazooka
						spEquip [0].SetActive (false);
						spEquip [1].SetActive (false);
						spEquip [2].SetActive (false);
						spEquip [3].SetActive (false);
						spEquip [4].SetActive (false);
						spEquip [5].SetActive (false);
						spEquip [6].SetActive (false);
						spEquip [7].SetActive (false);
						spEquip [8].SetActive (false);
						spEquip [9].SetActive (false);
						spEquip [23].SetActive (false);
						spEquip [24].SetActive (false);
						spEquip [25].SetActive (true);
			
						panelVip1.BackgroundSprite = "bb_unequip";
						panelVip2.BackgroundSprite = "bb_unequip";
						panelVip3.BackgroundSprite = "bb_equip";
						panelPistol.BackgroundSprite = "bb_unequip";
						panelM3.BackgroundSprite = "bb_unequip";
						panelMP5.BackgroundSprite = "bb_unequip";
						panelUZI.BackgroundSprite = "bb_unequip";
						panelKISS.BackgroundSprite = "bb_unequip";
						panelAWP.BackgroundSprite = "bb_unequip";
						panelSCAR.BackgroundSprite = "bb_unequip";
						panelWA.BackgroundSprite = "bb_unequip";
						panelBazooka.BackgroundSprite = "bb_unequip";
						panelM4A1.BackgroundSprite = "bb_unequip";
						DMG.Value = 1f;
						SPEED.Value = 0.2f;
						ACC.Value = 1f;
						CATRIDGE.Value = 0.2f;
						labelName.Text = RamboState.vip3;
						chiso1 = 0;
						chiso2 = 0;
						chiso3 = 0;
						chiso4 = 0;
						#endregion
				}
				#endregion

				#region Load Gun
				#region Load Pistol
				if (RamboState.gun_buy [0] == 1) {
						lblUpdatePistol.Text = "300";
						btnBuyPistol.Text = "UPGRADE";

//						DMG.Value = 0.2f;
//						SPEED.Value = 0.2f;
//						ACC.Value = 0.2f;
//						CATRIDGE.Value = 0.2f;
						lblNumberBulletOfPistol.Text = RamboState.total_bullet_sungluc.ToString ();
				} else if (RamboState.gun_buy [0] == 2) {
						lblUpdatePistol.Text = "400";
						btnBuyPistol.Text = "UPGRADE";

//						DMG.Value = 0.4f;
//						SPEED.Value = 0.4f;
//						ACC.Value = 0.2f;
//						CATRIDGE.Value = 0.2f;
						lblNumberBulletOfPistol.Text = RamboState.total_bullet_sungluc.ToString ();
				} else if (RamboState.gun_buy [0] == 3) {
						lblUpdatePistol.Text = "";
						btnBuyPistol.IsVisible = false;

//						DMG.Value = 0.4f;
//						SPEED.Value = 0.4f;
//						ACC.Value = 0.2f;
//						CATRIDGE.Value = 0.4f;
						lblNumberBulletOfPistol.Text = RamboState.total_bullet_sungluc.ToString ();
				}
				#endregion

				#region Load M3
				if (RamboState.gun_buy [1] == 0) {
						lblUpdateM3.Text = "300";
//						DMG.Value = 0.6f;
//						SPEED.Value = 0.2f;
//						ACC.Value = 0.2f;
//						CATRIDGE.Value = 0.2f;
				} else if (RamboState.gun_buy [1] == 1) {
						lblUpdateM3.Text = "300";
						btnBuyM3.Text = "UPGRADE";
//						DMG.Value = 0.6f;
//						SPEED.Value = 0.2f;
//						ACC.Value = 0.2f;
//						CATRIDGE.Value = 0.2f;
						lblNumberBulletOfM3.Text = RamboState.total_bullet_sungshotgun.ToString ();
				} else if (RamboState.gun_buy [1] == 2) {
						lblUpdateM3.Text = "500";
						btnBuyM3.Text = "UPGRADE";
//						DMG.Value = 0.6f;
//						SPEED.Value = 0.4f;
//						ACC.Value = 0.2f;
//						CATRIDGE.Value = 0.2f;
						lblNumberBulletOfM3.Text = RamboState.total_bullet_sungshotgun.ToString ();
				} else if (RamboState.gun_buy [1] == 3) {
						lblUpdateM3.Text = "1.000";
						btnBuyM3.Text = "UPGRADE";
//						DMG.Value = 0.8f;
//						SPEED.Value = 0.4f;
//						ACC.Value = 0.2f;
//						CATRIDGE.Value = 0.6f;
						lblNumberBulletOfM3.Text = RamboState.total_bullet_sungshotgun.ToString ();
				} else if (RamboState.gun_buy [1] == 4) {
						lblUpdateM3.Text = "";
						btnBuyM3.IsVisible = false;
//						DMG.Value = 0.8f;
//						SPEED.Value = 0.6f;
//						ACC.Value = 0.2f;
//						CATRIDGE.Value = 0.6f;
						lblNumberBulletOfM3.Text = RamboState.total_bullet_sungshotgun.ToString ();
				}
				#endregion

				#region Load MP5
				//MP5
				if (RamboState.gun_buy [2] == 0) {
						lblUpdateMp5.Text = "1.000";
//						DMG.Value = 0.2f;
//						SPEED.Value = 0.2f;
//						ACC.Value = 0.6f;
//						CATRIDGE.Value = 0.2f;
				} else if (RamboState.gun_buy [2] == 1) {
						lblUpdateMp5.Text = "500";
						btnBuyMP5.Text = "UPGRADE";
//						DMG.Value = 0.2f;
//						SPEED.Value = 0.2f;
//						ACC.Value = 0.6f;
//						CATRIDGE.Value = 0.2f;
						lblNumberBulletOfMP5.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfUZI.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfKISS.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfM4A1.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfSCAR.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfWA.Text = RamboState.total_bullet_sungtia.ToString ();
				} else if (RamboState.gun_buy [2] == 2) {
						lblUpdateMp5.Text = "";
						btnBuyMP5.IsVisible = false;
//						DMG.Value = 0.2f;
//						SPEED.Value = 0.2f;
//						ACC.Value = 1;
//						CATRIDGE.Value = 0.2f;
						lblNumberBulletOfMP5.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfUZI.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfKISS.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfM4A1.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfSCAR.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfWA.Text = RamboState.total_bullet_sungtia.ToString ();
				}
				#endregion

				#region Load UZI
				//UZI
				if (RamboState.gun_buy [3] == 0) {
						lblUpdateUzi.Text = "1.500";

//						DMG.Value = 0.2f;
//						SPEED.Value = 0.2f;
//						ACC.Value = 0.4f;
//						CATRIDGE.Value = 0.4f;
				} else if (RamboState.gun_buy [3] == 1) {
						lblUpdateUzi.Text = "500";
						btnBuyUZI.Text = "UPGRADE";
//						DMG.Value = 0.2f;
//						SPEED.Value = 0.2f;
//						ACC.Value = 0.4f;
//						CATRIDGE.Value = 0.4f;
						lblNumberBulletOfMP5.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfUZI.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfKISS.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfM4A1.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfSCAR.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfWA.Text = RamboState.total_bullet_sungtia.ToString ();
				} else if (RamboState.gun_buy [3] == 2) {
						lblUpdateUzi.Text = "1.000";
						btnBuyUZI.Text = "UPGRADE";
//						DMG.Value = 0.2f;
//						SPEED.Value = 0.2f;
//						ACC.Value = 0.6f;
//						CATRIDGE.Value = 0.6f;
						lblNumberBulletOfMP5.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfUZI.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfKISS.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfM4A1.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfSCAR.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfWA.Text = RamboState.total_bullet_sungtia.ToString ();
				} else if (RamboState.gun_buy [3] == 3) {
						lblUpdateUzi.Text = "";
						btnBuyUZI.IsVisible = false;
//						DMG.Value = 0.6f;
//						SPEED.Value = 0.2f;
//						ACC.Value = 0.6f;
//						CATRIDGE.Value = 0.6f;
						lblNumberBulletOfMP5.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfUZI.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfKISS.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfM4A1.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfSCAR.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfWA.Text = RamboState.total_bullet_sungtia.ToString ();
				}
				#endregion

				#region Load KISS
				//Kiss
				if (RamboState.gun_buy [4] == 0) {
						lblUpdateKiss.Text = "2.500";

//						DMG.Value = 0.2f;
//						SPEED.Value = 0.6f;
//						ACC.Value = 0.2f;
//						CATRIDGE.Value = 0.2f;
				} else if (RamboState.gun_buy [4] == 1) {
						lblUpdateKiss.Text = "500";
						btnKiss.Text = "UPGRADE";

//						DMG.Value = 0.2f;
//						SPEED.Value = 0.6f;
//						ACC.Value = 0.2f;
//						CATRIDGE.Value = 0.2f;
						lblNumberBulletOfMP5.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfUZI.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfKISS.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfM4A1.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfSCAR.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfWA.Text = RamboState.total_bullet_sungtia.ToString ();
				} else if (RamboState.gun_buy [4] == 2) {
						lblUpdateKiss.Text = "1.000";
						btnKiss.Text = "UPGRADE";
//
//						DMG.Value = 0.2f;
//						SPEED.Value = 0.8f;
//						ACC.Value = 0.2f;
//						CATRIDGE.Value = 0.2f;
						lblNumberBulletOfMP5.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfUZI.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfKISS.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfM4A1.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfSCAR.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfWA.Text = RamboState.total_bullet_sungtia.ToString ();
				} else if (RamboState.gun_buy [4] == 3) {
						lblUpdateKiss.Text = "";
						btnKiss.IsVisible = false;

//						DMG.Value = 0.2f;
//						SPEED.Value = 0.8f;
//						ACC.Value = 0.2f;
//						CATRIDGE.Value = 0.4f;
						lblNumberBulletOfMP5.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfUZI.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfKISS.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfM4A1.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfSCAR.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfWA.Text = RamboState.total_bullet_sungtia.ToString ();
				}
				#endregion

				#region Load M4A1
				//M4A1
				if (RamboState.gun_buy [5] == 0) {
						lblUpdateM4a1.Text = "5.000";

//						DMG.Value = 0.6f;
//						SPEED.Value = 0.4f;
//						ACC.Value = 0.2f;
//						CATRIDGE.Value = 0.2f;
				} else if (RamboState.gun_buy [5] == 1) {
						lblUpdateM4a1.Text = "500";
						btnBuyM4A1.Text = "UPGRADE";

//						DMG.Value = 0.6f;
//						SPEED.Value = 0.4f;
//						ACC.Value = 0.2f;
//						CATRIDGE.Value = 0.2f;
						lblNumberBulletOfMP5.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfUZI.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfKISS.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfM4A1.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfSCAR.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfWA.Text = RamboState.total_bullet_sungtia.ToString ();
				} else if (RamboState.gun_buy [5] == 2) {
						lblUpdateM4a1.Text = "1.000";
						btnBuyM4A1.Text = "UPGRADE";

//						DMG.Value = 0.6f;
//						SPEED.Value = 0.4f;
//						ACC.Value = 0.4f;
//						CATRIDGE.Value = 0.2f;
						lblNumberBulletOfMP5.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfUZI.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfKISS.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfM4A1.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfSCAR.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfWA.Text = RamboState.total_bullet_sungtia.ToString ();
			
				} else if (RamboState.gun_buy [5] == 3) {
						lblUpdateM4a1.Text = "1.500";
						btnBuyM4A1.Text = "UPGRADE";

//						DMG.Value = 0.6f;
//						SPEED.Value = 0.4f;
//						ACC.Value = 0.4f;
//						CATRIDGE.Value = 0.4f;
						lblNumberBulletOfMP5.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfUZI.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfKISS.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfM4A1.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfSCAR.Text = RamboState.total_bullet_sungtia.ToString ();
				} else if (RamboState.gun_buy [5] == 4) {
						lblUpdateM4a1.Text = "";
						btnBuyM4A1.IsVisible = false;

//						DMG.Value = 0.6f;
//						SPEED.Value = 0.4f;
//						ACC.Value = 0.4f;
//						CATRIDGE.Value = 0.6f;
						lblNumberBulletOfMP5.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfUZI.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfKISS.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfM4A1.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfSCAR.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfWA.Text = RamboState.total_bullet_sungtia.ToString ();
				}
				#endregion

				#region Load Scar
				//Scar
				if (RamboState.gun_buy [6] == 0) {
						lblUpdateScar.Text = "7.500";
//
//						DMG.Value = 0.6f;
//						SPEED.Value = 0.6f;
//						ACC.Value = 0.2f;
//						CATRIDGE.Value = 0.2f;
				} else if (RamboState.gun_buy [6] == 1) {
						lblUpdateScar.Text = "1.000";
						btnBuyScar.Text = "UPGRADE";

//						DMG.Value = 0.6f;
//						SPEED.Value = 0.6f;
//						ACC.Value = 0.2f;
//						CATRIDGE.Value = 0.2f;
						lblNumberBulletOfMP5.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfUZI.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfKISS.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfM4A1.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfSCAR.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfWA.Text = RamboState.total_bullet_sungtia.ToString ();
				} else if (RamboState.gun_buy [6] == 2) {
						lblUpdateScar.Text = "2.000";
						btnBuyScar.Text = "UPGRADE";

//						DMG.Value = 0.6f;
//						SPEED.Value = 0.8f;
//						ACC.Value = 0.2f;
//						CATRIDGE.Value = 0.2f;
						lblNumberBulletOfMP5.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfUZI.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfKISS.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfM4A1.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfSCAR.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfWA.Text = RamboState.total_bullet_sungtia.ToString ();
				} else if (RamboState.gun_buy [6] == 3) {
						lblUpdateScar.Text = "3.000";
						btnBuyScar.Text = "UPGRADE";

//						DMG.Value = 0.6f;
//						SPEED.Value = 0.8f;
//						ACC.Value = 0.4f;
//						CATRIDGE.Value = 0.2f;
						lblNumberBulletOfMP5.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfUZI.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfKISS.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfM4A1.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfSCAR.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfWA.Text = RamboState.total_bullet_sungtia.ToString ();
				} else if (RamboState.gun_buy [6] == 4) {
						lblUpdateScar.Text = "";
						btnBuyScar.IsVisible = false;

//						DMG.Value = 0.6f;
//						SPEED.Value = 0.8f;
//						ACC.Value = 0.6f;
//						CATRIDGE.Value = 0.2f;
						lblNumberBulletOfMP5.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfUZI.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfKISS.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfM4A1.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfSCAR.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfWA.Text = RamboState.total_bullet_sungtia.ToString ();
				}
				#endregion

				#region Load AWP
				//AWP
				if (RamboState.gun_buy [7] == 0) {
						lblUpdateAwp.Text = "25.000";
//
//						DMG.Value = 1f;
//						SPEED.Value = 0.2f;
//						ACC.Value = 0.6f;
//						CATRIDGE.Value = 0.2f;
				} else if (RamboState.gun_buy [7] == 1) {
						lblUpdateAwp.Text = "5.000";
						btnBuyAWP.Text = "UPGRADE";

//						DMG.Value = 1f;
//						SPEED.Value = 0.2f;
//						ACC.Value = 0.6f;
//						CATRIDGE.Value = 0.2f;
						lblNumberBulletOfAWP.Text = RamboState.total_bullet_sungngam.ToString ();
						
				} else if (RamboState.gun_buy [7] == 2) {
						lblUpdateAwp.Text = "5.000";
						btnBuyAWP.Text = "UPGRADE";

//						DMG.Value = 1f;
//						SPEED.Value = 0.4f;
//						ACC.Value = 0.6f;
//						CATRIDGE.Value = 0.2f;
						lblNumberBulletOfAWP.Text = RamboState.total_bullet_sungngam.ToString ();
						
				} else if (RamboState.gun_buy [7] == 3) {
						lblUpdateAwp.Text = "";
						btnBuyAWP.IsVisible = false;

//						DMG.Value = 1f;
//						SPEED.Value = 0.4f;
//						ACC.Value = 0.6f;
//						CATRIDGE.Value = 0.4f;
						lblNumberBulletOfAWP.Text = RamboState.total_bullet_sungngam.ToString ();
					
				}
				#endregion

				#region Load WA
				//WA2000
				if (RamboState.gun_buy [8] == 0) {
						lblUpdateWa.Text = "45.000";

//						DMG.Value = 0.8f;
//						SPEED.Value = 0.2f;
//						ACC.Value = 0.6f;
//						CATRIDGE.Value = 0.2f;
				} else if (RamboState.gun_buy [8] == 1) {
						lblUpdateWa.Text = "5.000";
						btnWa.Text = "UPGRADE";

//						DMG.Value = 0.8f;
//						SPEED.Value = 0.2f;
//						ACC.Value = 0.6f;
//						CATRIDGE.Value = 0.2f;
					
						lblNumberBulletOfWA.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfMP5.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfUZI.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfKISS.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfM4A1.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfSCAR.Text = RamboState.total_bullet_sungtia.ToString ();
				} else if (RamboState.gun_buy [8] == 2) {
						lblUpdateWa.Text = "5.000";
						btnWa.Text = "UPGRADE";

//						DMG.Value = 0.8f;
//						SPEED.Value = 0.2f;
//						ACC.Value = 0.6f;
//						CATRIDGE.Value = 0.6f;
						
						lblNumberBulletOfWA.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfMP5.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfUZI.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfKISS.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfM4A1.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfSCAR.Text = RamboState.total_bullet_sungtia.ToString ();
				} else if (RamboState.gun_buy [8] == 3) {
						lblUpdateWa.Text = "";
						btnWa.IsVisible = false;

//						DMG.Value = 1f;
//						SPEED.Value = 0.2f;
//						ACC.Value = 0.8f;
//						CATRIDGE.Value = 0.6f;
						
						lblNumberBulletOfWA.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfMP5.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfUZI.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfKISS.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfM4A1.Text = RamboState.total_bullet_sungtia.ToString ();
						lblNumberBulletOfSCAR.Text = RamboState.total_bullet_sungtia.ToString ();
				}
				#endregion
		
				#region Load BAZOOKA
				//Bazooka
				if (RamboState.gun_buy [9] == 1) {
						btnBuyBazooka.IsVisible = false;
//						DMG.Value = 1f;
//						SPEED.Value = 0.2f;
//						ACC.Value = 1f;
//						CATRIDGE.Value = 0.2f;
						lblNumberBulletOfBAZOOKA.Text = RamboState.total_bullet_sung_tenlua.ToString ();
				} else {
						btnBuyBazooka.IsVisible = true;
//						DMG.Value = 1f;
//						SPEED.Value = 0.2f;
//						ACC.Value = 1f;
//						CATRIDGE.Value = 0.2f;
				}
				#endregion
				#region Load Vip1
				//Bazooka
				if (RamboState.gun_buy [10] == 1) {
						btnBuyVip1.IsVisible = false;
						//						DMG.Value = 1f;
						//						SPEED.Value = 0.2f;
						//						ACC.Value = 1f;
						//						CATRIDGE.Value = 0.2f;
						lblNumberBulletOfVip1.Text = RamboState.total_bullet_sungtia.ToString ();
				} else {
						btnBuyVip1.IsVisible = true;
						//						DMG.Value = 1f;
						//						SPEED.Value = 0.2f;
						//						ACC.Value = 1f;
						//						CATRIDGE.Value = 0.2f;
				}
				#endregion
				#region Load Vip2
				//Bazooka
				if (RamboState.gun_buy [11] == 1) {
						btnBuyVip2.IsVisible = false;
						//						DMG.Value = 1f;
						//						SPEED.Value = 0.2f;
						//						ACC.Value = 1f;
						//						CATRIDGE.Value = 0.2f;
						lblNumberBulletOfVip2.Text = RamboState.total_bullet_sungtia.ToString ();
				} else {
						btnBuyVip2.IsVisible = true;
						//						DMG.Value = 1f;
						//						SPEED.Value = 0.2f;
						//						ACC.Value = 1f;
						//						CATRIDGE.Value = 0.2f;
				}
				#endregion
				#region Load Vip3
				//Bazooka
				if (RamboState.gun_buy [12] == 1) {
						btnBuyVip3.IsVisible = false;
						//						DMG.Value = 1f;
						//						SPEED.Value = 0.2f;
						//						ACC.Value = 1f;
						//						CATRIDGE.Value = 0.2f;
						lblNumberBulletOfVip3.Text = RamboState.total_bullet_sung_tenlua.ToString ();
				} else {
						btnBuyVip3.IsVisible = true;
						//						DMG.Value = 1f;
						//						SPEED.Value = 0.2f;
						//						ACC.Value = 1f;
						//						CATRIDGE.Value = 0.2f;
				}
				#endregion
				#endregion

				check_chonsung = false;
				time_chonsung = 0;

				if (RamboState.check_chonsung) {


						RamboState.check_chonsung = false;
						chonsung6 ();
				} //else GameObject.Find ("Scroll Panel weapon").GetComponent<dfScrollPanel> ().ScrollPosition=new Vector2(0,0);

        //chonsung6 ();

        if (dem == 0)
        {
            dem++;
        }
        else
        {            
            GoogleMobileAdControll.AdmobControll.ShowInterstitial();
        }
		  
		}

		void Update ()
		{
				numberofheart.Text = "x" + RamboState.HP_RAMBO.ToString ();

				//if (RamboState.huongdanshop == 0) {
				//		if (GameObject.Find ("Scroll Panel weapon") != null)
				//				GameObject.Find ("Scroll Panel weapon").GetComponent<dfScrollPanel> ().ScrollPosition = new Vector2 (0, 0);
				//}
				//if (RamboState.huongdan_fashion == 0 && RamboState.level == 4) {
				//		if (GameObject.Find ("Scroll Panel fashion") != null)
				//				GameObject.Find ("Scroll Panel fashion").GetComponent<dfScrollPanel> ().ScrollPosition = new Vector2 (0, 0);
				//		if (GameObject.Find ("Scroll Panel weapon") != null)
				//				GameObject.Find ("Scroll Panel weapon").GetComponent<dfScrollPanel> ().ScrollPosition = new Vector2 (0, 0);
				//}

				if (check_chonsung) {
						time_chonsung += Time.deltaTime;
						if (time_chonsung < 1) {
								GameObject.Find ("Scroll Panel weapon").GetComponent<dfScrollPanel> ().ScrollPosition = new Vector2 (0, 630);


						} else {
								check_chonsung = false;
			
						}

				}
				if (check_thongbao) {
						time_thongbao += Time.deltaTime;
						if (time_thongbao > 3)
								next ();


				}
				if (GameObject.Find ("numberdamage") != null) {   
						GameObject.Find ("numberdamage").GetComponent<dfLabel> ().Text = (DMG.Value * 10) + "/10";
						GameObject.Find ("numberspeed").GetComponent<dfLabel> ().Text = (SPEED.Value * 10) + "/10";
						GameObject.Find ("numbercatridge").GetComponent<dfLabel> ().Text = (CATRIDGE.Value * 10) + "/10";
						GameObject.Find ("numberaccuracy").GetComponent<dfLabel> ().Text = (ACC.Value * 10) + "/10";

						if (chiso1 > 0)
								GameObject.Find ("numberdamage1").GetComponent<dfLabel> ().Text = "+" + chiso1;
						else
								GameObject.Find ("numberdamage1").GetComponent<dfLabel> ().Text = "";
		
						if (chiso2 > 0)
								GameObject.Find ("numberspeed1").GetComponent<dfLabel> ().Text = "+" + chiso2;
						else
								GameObject.Find ("numberspeed1").GetComponent<dfLabel> ().Text = "";
		
						if (chiso4 > 0)
								GameObject.Find ("numbercatridge1").GetComponent<dfLabel> ().Text = "+" + chiso4;
						else
								GameObject.Find ("numbercatridge1").GetComponent<dfLabel> ().Text = "";
		
						if (chiso3 > 0)
								GameObject.Find ("numberaccuracy1").GetComponent<dfLabel> ().Text = "+" + chiso3;
						else
								GameObject.Find ("numberaccuracy1").GetComponent<dfLabel> ().Text = "";


				}

				panelRotation.transform.Rotate (new Vector3 (0, 0, rotateSpeed));
				transform.Rotate (new Vector3 (0, 1f, 0));
				moneyText.Text = formatString (RamboState.dola);

				//Back to the menu
				if (Input.GetKeyDown (KeyCode.Escape)) {
						if (RamboState.huongdanshop == 1) {
								if (RamboState.level == 4) {
										if (RamboState.huongdan_fashion == 1) {
												AutoFade.LoadLevel ("ChooseMap", 0.8f, 0.8f, Color.black);
												LoadInfo.SaveShop ();
										}

								} else {
										AutoFade.LoadLevel ("ChooseMap", 0.8f, 0.8f, Color.black);
										LoadInfo.SaveShop ();
								}
						}

				}
		
		}

		public string formatString (int numb)
		{
				string s = "" + numb;
				string r = "";
				int j = 0;
				for (int i = s.Length - 1; i >= 0; i--) {
						j++;
						if (j % 3 == 0 && j != s.Length) {
								r = r + s [i] + ",";
						} else {
								r = r + s [i];
						}
				}
				string str = "";
				for (int i = r.Length - 1; i >= 0; i--) {
						str = str + r [i];
				}
				return str;
		}

    #region Buy Gun
		public void OnClick (dfControl control, dfMouseEventArgs mouseEvent)
		{     // mua sung
				GameObject.Find ("Click").GetComponent<SoundClick> ().play ();
				if (control.name == "Button Buy Pistol") {
						#region Buy Pistol
						if (RamboState.gun_buy [0] == 1) {
								if (RamboState.dola >= 300) {
										items [gunIndex].SetActive (false);
										iconPistol.BackgroundSprite = "ss2";
										pistollv.BackgroundSprite = "Pistol_FiveSeven_2";
										btnBuyPistol.Text = "UPGRADE";
										RamboState.dola -= 300;
										RamboState.gun_buy [0] = 2;
										lblUpdatePistol.Text = "400";
										PlayerPrefs.SetInt ("statesung", 1);
										PlayerPrefs.SetInt ("gunBuy" + 0, 2);
										gunIndex = 2;
										items [gunIndex].SetActive (true);
										labelName.Text = RamboState.pistol_lv2;
										RamboState.state_sung = 1;
										lblNumberBulletOfPistol.Text = RamboState.total_bullet_sungluc.ToString ();
										spEquip [0].SetActive (true);
										spEquip [1].SetActive (false);
										spEquip [2].SetActive (false);
										spEquip [3].SetActive (false);
										spEquip [4].SetActive (false);
										spEquip [5].SetActive (false);
										spEquip [6].SetActive (false);
										spEquip [7].SetActive (false);
										spEquip [8].SetActive (false);
										spEquip [9].SetActive (false);
										spEquip [23].SetActive (false);
										spEquip [24].SetActive (false);
										spEquip [25].SetActive (false);

										DMG.Value = 0.4f;
										SPEED.Value = 0.4f;
										ACC.Value = 0.2f;
										CATRIDGE.Value = 0.2f;
										chiso1 = 0;
										chiso2 = 0;
										chiso3 = 0;
										chiso4 = 2;
								} else {
										naptien ();
								}
						} else if (RamboState.gun_buy [0] == 2) {
								if (RamboState.dola >= 400) {
										items [gunIndex].SetActive (false);
										iconPistol.BackgroundSprite = "ss3";
										pistollv.BackgroundSprite = "Pistol_FiveSeven_3";
										RamboState.dola -= 400;
										gunIndex = 3;
										items [gunIndex].SetActive (true);
										labelName.Text = RamboState.pistol_lv3;
										lblUpdatePistol.Text = "";
										btnBuyPistol.IsVisible = false;
										RamboState.gun_buy [0] = 3;
										PlayerPrefs.SetInt ("gunBuy" + 0, 3);
										PlayerPrefs.SetInt ("statesung", 2);
										RamboState.state_sung = 2;

										DMG.Value = 0.4f;
										SPEED.Value = 0.4f;
										ACC.Value = 0.2f;
										CATRIDGE.Value = 0.4f;
										chiso1 = 0;
										chiso2 = 0;
										chiso3 = 0;
										chiso4 = 0;
								} else {
										naptien ();
								}
						}
						#endregion
				} else if (control.name == "Button Buy M3") {
            #region Buy M3
            if (RamboState.gun_buy[1] == 0)
            {
                //if (RamboState.huongdanshop == 0 && GameObject.Find("Tutorial").GetComponent<TutorialShop>().state == 1)
                //{
                //    GameObject.Find("Tutorial").GetComponent<TutorialShop>().state = 2;

                    items[gunIndex].SetActive(false);

                    btnBuyM3.Text = "Upgrade";
                    gunIndex = 3;
                    items[gunIndex].SetActive(true);
                    labelName.Text = RamboState.m3_lv1;
                    RamboState.gun_buy[1] = 1;
                    PlayerPrefs.SetInt("gunBuy" + 1, 1);
                    RamboState.state_sung = 3;
                RamboState.dola -= 300;
                RamboState.total_bullet_sungshotgun += 25;
                    lblNumberBulletOfM3.Text = RamboState.total_bullet_sungshotgun.ToString();
                    spEquip[0].SetActive(false);
                    spEquip[1].SetActive(true);
                    spEquip[2].SetActive(false);
                    spEquip[3].SetActive(false);
                    spEquip[4].SetActive(false);
                    spEquip[5].SetActive(false);
                    spEquip[6].SetActive(false);
                    spEquip[7].SetActive(false);
                    spEquip[8].SetActive(false);
                    spEquip[9].SetActive(false);
                    spEquip[23].SetActive(false);
                    spEquip[24].SetActive(false);
                    spEquip[25].SetActive(false);
                    PlayerPrefs.SetInt("statesung", 3);

                    DMG.Value = 0.6f;
                    SPEED.Value = 0.2f;
                    ACC.Value = 0.2f;
                    CATRIDGE.Value = 0.2f;

                    chiso1 = 0;
                    chiso2 = 2;
                    chiso3 = 0;
                    chiso4 = 0;
                //}

            }
            else if (RamboState.gun_buy[1] == 1)
            {
                //if (RamboState.huongdanshop == 0 && GameObject.Find("Tutorial").GetComponent<TutorialShop>().state == 3)
                //{
                //    GameObject.Find("Tutorial").GetComponent<TutorialShop>().state = 4;
                    RamboState.huongdanshop = 1;
                    PlayerPrefs.SetInt("huongdanshop", 1);
                    //RamboState.dola += 1000;

                    items[gunIndex].SetActive(false);
                    iconM3.BackgroundSprite = "ss2";
                    m3_lv.BackgroundSprite = "ShortGun_M3_2";
                    btnBuyM3.Text = "Upgrade";
                    lblUpdateM3.Text = "500";
                    RamboState.dola -= 300;
                    gunIndex = 4;
                    items[gunIndex].SetActive(true);
                    labelName.Text = RamboState.m3_lv2;
                    RamboState.gun_buy[1] = 2;
                    PlayerPrefs.SetInt("gunBuy" + 1, 2);
                    PlayerPrefs.SetInt("statesung", 4);
                    RamboState.state_sung = 4;

                    DMG.Value = 0.6f;
                    SPEED.Value = 0.4f;
                    ACC.Value = 0.2f;
                    CATRIDGE.Value = 0.2f;
                    chiso1 = 2;
                    chiso2 = 0;
                    chiso3 = 0;
                    chiso4 = 4;
                //}
            }
            else if(RamboState.gun_buy[1] == 2 && GameObject.Find("TutorialFashion") == null) {
                if (RamboState.dola >= 500)
                {
                    items [gunIndex].SetActive (false);
										RamboState.dola -= 500;
										iconM3.BackgroundSprite = "ss3";
										m3_lv.BackgroundSprite = "ShortGun_M3_3";
										btnBuyM3.Text = "Upgrade";
										gunIndex = 5;
										items [gunIndex].SetActive (true);
										labelName.Text = RamboState.m3_lv3;
										lblUpdateM3.Text = "1000";
										RamboState.gun_buy [1] = 3;
										PlayerPrefs.SetInt ("gunBuy" + 1, 3);
										PlayerPrefs.SetInt ("statesung", 5);
										RamboState.state_sung = 5;

										DMG.Value = 0.8f;
										SPEED.Value = 0.4f;
										ACC.Value = 0.2f;
										CATRIDGE.Value = 0.6f;
										chiso1 = 0;
										chiso2 = 2;
										chiso3 = 0;
										chiso4 = 0;
								} else {
										naptien ();

								}
						} else if (RamboState.gun_buy [1] == 3 && GameObject.Find ("TutorialFashion") == null) {
								if (RamboState.dola >= 1000) {
										items [gunIndex].SetActive (false);
										RamboState.dola -= 1000;
										iconM3.BackgroundSprite = "ss4";
										m3_lv.BackgroundSprite = "ShortGun_M3_4";
										btnBuyM3.IsVisible = false;
										lblUpdateM3.Text = "";
										gunIndex = 6;
										items [gunIndex].SetActive (true);
										labelName.Text = RamboState.m3_lv4;
										RamboState.gun_buy [1] = 4;
										PlayerPrefs.SetInt ("gunBuy" + 1, 4);
										PlayerPrefs.SetInt ("statesung", 6);
										RamboState.state_sung = 6;

										DMG.Value = 0.8f;
										SPEED.Value = 0.6f;
										ACC.Value = 0.2f;
										CATRIDGE.Value = 0.6f;
								} else {
										naptien ();

								}
						}
						#endregion
				} else if (control.name == "Button Buy MP5") {
						#region Buy MP5
						if (RamboState.gun_buy [2] == 0) {
                print("check unlock gun____________________ " + RamboState.check_unlock_gun[0]);
                if (RamboState.check_unlock_gun [0] == 1 || RamboState.state_level1 [3] > 0 || RamboState.state_level2 [3] > 0 || RamboState.state_level3 [3] > 0) {  
										if (RamboState.dola >= 1000) {
												items [gunIndex].SetActive (false);
												RamboState.dola -= 1000;
												btnBuyMP5.Text = "Upgrade";
												gunIndex = 7;
												items [gunIndex].SetActive (true);
												lblUpdateMp5.Text = "500";
												labelName.Text = RamboState.mp5_lv1;
												RamboState.gun_buy [2] = 1;
												PlayerPrefs.SetInt ("gunBuy" + 2, 1);
												PlayerPrefs.SetInt ("statesung", 7);
												RamboState.state_sung = 7;
												RamboState.total_bullet_sungtia += 20;
												lblNumberBulletOfMP5.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfUZI.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfKISS.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfM4A1.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfSCAR.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfWA.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfVip1.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfVip2.Text = RamboState.total_bullet_sungtia.ToString ();
												spEquip [23].SetActive (false);
												spEquip [24].SetActive (false);
												spEquip [25].SetActive (false);
												spEquip [0].SetActive (false);
												spEquip [1].SetActive (false);
												spEquip [2].SetActive (true);
												spEquip [3].SetActive (false);
												spEquip [4].SetActive (false);
												spEquip [5].SetActive (false);
												spEquip [6].SetActive (false);
												spEquip [7].SetActive (false);
												spEquip [8].SetActive (false);
												spEquip [9].SetActive (false);


												DMG.Value = 0.2f;
												SPEED.Value = 0.2f;
												ACC.Value = 0.6f;
												CATRIDGE.Value = 0.2f;
												chiso1 = 0;
												chiso2 = 0;
												chiso3 = 4;
												chiso4 = 0;
										} else {
												naptien ();
										}
								} else {
										GameObject.Find ("Unlockgun").GetComponent<dfTweenVector3> ().Play ();
										GameObject.Find ("textunlock").GetComponent<dfLabel> ().Text = "Unlock at level 5 chapter one";
										GameObject.Find ("Camera 3D").GetComponent<Camera> ().enabled = false;
										RamboState.state_unlock = 1;

								}
						} else if (RamboState.gun_buy [2] == 1) {
								if (RamboState.dola >= 500) {
										items [gunIndex].SetActive (false);
										iconMP5.BackgroundSprite = "ss2";
										mp5_lv.BackgroundSprite = "SMG_MP5_2";
										btnBuyMP5.IsVisible = false;
										RamboState.dola -= 500;
										gunIndex = 8;
										lblUpdateMp5.Text = "";
										lblNumberBulletOfMP5.Text = RamboState.total_bullet_sungtia.ToString ();
										lblNumberBulletOfUZI.Text = RamboState.total_bullet_sungtia.ToString ();
										lblNumberBulletOfKISS.Text = RamboState.total_bullet_sungtia.ToString ();
										lblNumberBulletOfM4A1.Text = RamboState.total_bullet_sungtia.ToString ();
										lblNumberBulletOfSCAR.Text = RamboState.total_bullet_sungtia.ToString ();
										lblNumberBulletOfWA.Text = RamboState.total_bullet_sungtia.ToString ();
										lblNumberBulletOfVip1.Text = RamboState.total_bullet_sungtia.ToString ();
										lblNumberBulletOfVip2.Text = RamboState.total_bullet_sungtia.ToString ();
										items [gunIndex].SetActive (true);
										labelName.Text = RamboState.mp5_lv2;
										RamboState.gun_buy [2] = 2;
										PlayerPrefs.SetInt ("gunBuy" + 2, 2);
										PlayerPrefs.SetInt ("statesung", 8);
										RamboState.state_sung = 8;

										DMG.Value = 0.2f;
										SPEED.Value = 0.2f;
										ACC.Value = 1;
										CATRIDGE.Value = 0.2f;
										chiso1 = 0;
										chiso2 = 0;
										chiso3 = 4;
										chiso4 = 0;
								} else {
										naptien ();
								}
						}
						#endregion
				} else if (control.name == "Button Buy UZI") {
						#region Buy UZI
						if (RamboState.gun_buy [3] == 0) {
                print("check unlock gun____________________ " + RamboState.check_unlock_gun[1]);
                if (RamboState.check_unlock_gun [1] == 1 || RamboState.state_level1 [5] > 0 || RamboState.state_level2 [5] > 0 || RamboState.state_level3 [5] > 0) {  

										if (RamboState.dola >= 1500) {
												items [gunIndex].SetActive (false);
												RamboState.dola -= 1500;
												btnBuyUZI.Text = "Upgrade";
												lblUpdateUzi.Text = "500";
												gunIndex = 9;
												items [gunIndex].SetActive (true);
												labelName.Text = RamboState.uzi_lv1;
												RamboState.gun_buy [3] = 1;
												PlayerPrefs.SetInt ("gunBuy" + 3, 1);
												PlayerPrefs.SetInt ("statesung", 9);
												RamboState.state_sung = 9;
												RamboState.total_bullet_sungtia += 20;
												lblNumberBulletOfMP5.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfUZI.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfKISS.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfM4A1.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfSCAR.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfWA.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfVip1.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfVip2.Text = RamboState.total_bullet_sungtia.ToString ();
												spEquip [0].SetActive (false);
												spEquip [1].SetActive (false);
												spEquip [2].SetActive (false);
												spEquip [3].SetActive (true);
												spEquip [4].SetActive (false);
												spEquip [5].SetActive (false);
												spEquip [6].SetActive (false);
												spEquip [7].SetActive (false);
												spEquip [8].SetActive (false);
												spEquip [9].SetActive (false);
												spEquip [23].SetActive (false);
												spEquip [24].SetActive (false);
												spEquip [25].SetActive (false);
												DMG.Value = 0.2f;
												SPEED.Value = 0.2f;
												ACC.Value = 0.4f;
												CATRIDGE.Value = 0.4f;
												chiso1 = 0;
												chiso2 = 0;
												chiso3 = 2;
												chiso4 = 2;
										} else {
												naptien ();
										}
								} else {
										GameObject.Find ("Unlockgun").GetComponent<dfTweenVector3> ().Play ();
										GameObject.Find ("textunlock").GetComponent<dfLabel> ().Text = "Unlock at level 7 chapter one";
										GameObject.Find ("Camera 3D").GetComponent<Camera> ().enabled = false;
										RamboState.state_unlock = 2;
                    print("state unlock gun____________________ " + RamboState.state_unlock);
					
								}
						} else if (RamboState.gun_buy [3] == 1) {
								if (RamboState.dola >= 500) {
										items [gunIndex].SetActive (false);
										iconUZI.BackgroundSprite = "ss2";
										uzi_lv.BackgroundSprite = "SMG_UZI_2";
										btnBuyUZI.Text = "Upgrade";
										lblUpdateUzi.Text = "1000";
										RamboState.dola -= 500;
										gunIndex = 10;
										items [gunIndex].SetActive (true);
										labelName.Text = RamboState.uzi_lv2;
										RamboState.gun_buy [3] = 2;
										PlayerPrefs.SetInt ("gunBuy" + 3, 2);
										PlayerPrefs.SetInt ("statesung", 10);
										RamboState.state_sung = 10;

										DMG.Value = 0.2f;
										SPEED.Value = 0.2f;
										ACC.Value = 0.6f;
										CATRIDGE.Value = 0.6f;
										chiso1 = 4;
										chiso2 = 0;
										chiso3 = 0;
										chiso4 = 0;
								} else {
										naptien ();

								}
						} else if (RamboState.gun_buy [3] == 2) {
								if (RamboState.dola >= 1000) {
										items [gunIndex].SetActive (false);
										RamboState.dola -= 1000;
										iconUZI.BackgroundSprite = "ss3";
										uzi_lv.BackgroundSprite = "SMG_UZI_3";
										btnBuyUZI.IsVisible = false;
										lblUpdateUzi.Text = "";
										gunIndex = 11;
										items [gunIndex].SetActive (true);
										labelName.Text = RamboState.uzi_lv3;
										RamboState.gun_buy [3] = 3;
										PlayerPrefs.SetInt ("gunBuy" + 3, 3);
										PlayerPrefs.SetInt ("statesung", 11);
										RamboState.state_sung = 11;

										DMG.Value = 0.6f;
										SPEED.Value = 0.2f;
										ACC.Value = 0.6f;
										CATRIDGE.Value = 0.6f;
										chiso1 = 0;
										chiso2 = 0;
										chiso3 = 0;
										chiso4 = 0;
								} else {
										naptien ();

								}
						}
						#endregion
				} else if (control.name == "Button Buy Kiss") {
						#region Buy KISS
						if (RamboState.gun_buy [4] == 0) {
                print("check unlock gun____________________ " + RamboState.check_unlock_gun[2]);
                if (RamboState.check_unlock_gun [2] == 1 || RamboState.state_level1 [9] > 0 || RamboState.state_level2 [9] > 0 || RamboState.state_level3 [9] > 0) {  
										if (RamboState.dola >= 2500) {
												items [gunIndex].SetActive (false);
												RamboState.dola -= 2500;
												btnKiss.Text = "Upgrade";
												lblUpdateKiss.Text = "500";
												gunIndex = 12;
												items [gunIndex].SetActive (true);
												labelName.Text = RamboState.kiss_lv1;
												RamboState.gun_buy [4] = 1;
												PlayerPrefs.SetInt ("gunBuy" + 4, 1);
												PlayerPrefs.SetInt ("statesung", 12);
												RamboState.state_sung = 12;
												RamboState.total_bullet_sungtia += 20;
												lblNumberBulletOfMP5.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfUZI.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfKISS.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfM4A1.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfSCAR.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfWA.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfVip1.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfVip2.Text = RamboState.total_bullet_sungtia.ToString ();
												spEquip [0].SetActive (false);
												spEquip [1].SetActive (false);
												spEquip [2].SetActive (false);
												spEquip [3].SetActive (false);
												spEquip [4].SetActive (true);
												spEquip [5].SetActive (false);
												spEquip [6].SetActive (false);
												spEquip [7].SetActive (false);
												spEquip [8].SetActive (false);
												spEquip [9].SetActive (false);
												spEquip [23].SetActive (false);
												spEquip [24].SetActive (false);
												spEquip [25].SetActive (false);
												DMG.Value = 0.2f;
												SPEED.Value = 0.6f;
												ACC.Value = 0.2f;
												CATRIDGE.Value = 0.2f;
												chiso1 = 0;
												chiso2 = 2;
												chiso3 = 0;
												chiso4 = 0;
										} else {
												naptien ();
										}
								} else {
										GameObject.Find ("Unlockgun").GetComponent<dfTweenVector3> ().Play ();
										GameObject.Find ("textunlock").GetComponent<dfLabel> ().Text = "Unlock at chapter 2";
										GameObject.Find ("Camera 3D").GetComponent<Camera> ().enabled = false;
										RamboState.state_unlock = 3;
                    print("state unlock gun____________________ " + RamboState.state_unlock);

                }
						} else if (RamboState.gun_buy [4] == 1) {
								if (RamboState.dola >= 500) {
										items [gunIndex].SetActive (false);
										iconKiss.BackgroundSprite = "ss2";
										kiss_lv.BackgroundSprite = "SMG_KISS_SUPER_2";
										btnKiss.Text = "Upgrade";
										RamboState.dola -= 500;
										lblUpdateKiss.Text = "500";
										gunIndex = 13;
										items [gunIndex].SetActive (true);
										labelName.Text = RamboState.kiss_lv2;
										RamboState.gun_buy [4] = 2;
										PlayerPrefs.SetInt ("gunBuy" + 4, 2);
										PlayerPrefs.SetInt ("statesung", 13);
										RamboState.state_sung = 13;

										DMG.Value = 0.2f;
										SPEED.Value = 0.8f;
										ACC.Value = 0.2f;
										CATRIDGE.Value = 0.2f;
										chiso1 = 0;
										chiso2 = 0;
										chiso3 = 0;
										chiso4 = 2;
								} else {
										naptien ();
								}
						} else if (RamboState.gun_buy [4] == 2) {
								if (RamboState.dola >= 500) {
										items [gunIndex].SetActive (false);
										RamboState.dola -= 500;
										lblUpdateKiss.Text = "";
										iconKiss.BackgroundSprite = "ss3";
										kiss_lv.BackgroundSprite = "SMG_KISS_SUPPER_3";
										btnKiss.IsVisible = false;
										gunIndex = 14;
										items [gunIndex].SetActive (true);
										labelName.Text = RamboState.kiss_lv3;
										RamboState.gun_buy [4] = 3;
										PlayerPrefs.SetInt ("gunBuy" + 4, 3);
										PlayerPrefs.SetInt ("statesung", 14);
										RamboState.state_sung = 14;

										DMG.Value = 0.2f;
										SPEED.Value = 0.8f;
										ACC.Value = 0.2f;
										CATRIDGE.Value = 0.4f;
										chiso1 = 0;
										chiso2 = 0;
										chiso3 = 0;
										chiso4 = 0;
								} else {
										naptien ();
								}
						}
						#endregion
				} else if (control.name == "Button Buy M4A1") {
						#region Buy M4A1
						if (RamboState.gun_buy [5] == 0) {
                print("check unlock gun____________________ " + RamboState.check_unlock_gun[3]);
                if (RamboState.check_unlock_gun [3] == 1 || RamboState.state_level1 [9] > 0 || RamboState.state_level2 [9] > 0 || RamboState.state_level3 [9] > 0) {  
										if (RamboState.dola >= 5000) {
												items [gunIndex].SetActive (false);
												RamboState.dola -= 5000;
												btnBuyM4A1.Text = "EQUIP";
												lblUpdateM4a1.Text = "500";
												gunIndex = 15;
												items [gunIndex].SetActive (true);
												labelName.Text = RamboState.m4a1_lv1;
												RamboState.gun_buy [5] = 1;
												PlayerPrefs.SetInt ("gunBuy" + 5, 1);
												PlayerPrefs.SetInt ("statesung", 15);
												RamboState.state_sung = 15;
												RamboState.total_bullet_sungtia += 20;
												lblNumberBulletOfMP5.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfUZI.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfKISS.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfM4A1.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfSCAR.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfWA.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfVip1.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfVip2.Text = RamboState.total_bullet_sungtia.ToString ();
												spEquip [0].SetActive (false);
												spEquip [1].SetActive (false);
												spEquip [2].SetActive (false);
												spEquip [3].SetActive (false);
												spEquip [4].SetActive (false);
												spEquip [5].SetActive (true);
												spEquip [6].SetActive (false);
												spEquip [7].SetActive (false);
												spEquip [8].SetActive (false);
												spEquip [9].SetActive (false);
												spEquip [23].SetActive (false);
												spEquip [24].SetActive (false);
												spEquip [25].SetActive (false);
												DMG.Value = 0.6f;
												SPEED.Value = 0.4f;
												ACC.Value = 0.2f;
												CATRIDGE.Value = 0.2f;
												chiso1 = 0;
												chiso2 = 0;
												chiso3 = 2;
												chiso4 = 0;
										} else {
												naptien ();
										}
								} else {
										GameObject.Find ("Unlockgun").GetComponent<dfTweenVector3> ().Play ();
										GameObject.Find ("textunlock").GetComponent<dfLabel> ().Text = "Unlock at chapter 2";
										GameObject.Find ("Camera 3D").GetComponent<Camera> ().enabled = false;
										RamboState.state_unlock = 4;
                    print("state unlock gun____________________ " + RamboState.state_unlock);
                }
						} else if (RamboState.gun_buy [5] == 1) {
								if (RamboState.dola >= 500) {
										items [gunIndex].SetActive (false);
										iconM4A1.BackgroundSprite = "ss2";
										m4a1_lv.BackgroundSprite = "Rifle_M4A1_2";
										btnBuyM4A1.Text = "Upgrade";
										RamboState.dola -= 500;
										lblUpdateM4a1.Text = "1.000";
										gunIndex = 16;
										items [gunIndex].SetActive (true);
										labelName.Text = RamboState.m4a1_lv2;
										RamboState.gun_buy [5] = 2;
										PlayerPrefs.SetInt ("gunBuy" + 5, 2);
										PlayerPrefs.SetInt ("statesung", 16);
										RamboState.state_sung = 16;

										DMG.Value = 0.6f;
										SPEED.Value = 0.4f;
										ACC.Value = 0.4f;
										CATRIDGE.Value = 0.2f;
										chiso1 = 0;
										chiso2 = 0;
										chiso3 = 0;
										chiso4 = 2;
								} else {
										naptien ();
								}
						} else if (RamboState.gun_buy [5] == 2) {
								if (RamboState.dola >= 1000) {
										items [gunIndex].SetActive (false);
										RamboState.dola -= 1000;
										iconM4A1.BackgroundSprite = "ss3";
										m4a1_lv.BackgroundSprite = "Rifle_M4A1_3";
										gunIndex = 17;
										lblUpdateM4a1.Text = "1.500";
										items [gunIndex].SetActive (true);
										labelName.Text = RamboState.m4a1_lv3;
										RamboState.gun_buy [5] = 3;
										PlayerPrefs.SetInt ("gunBuy" + 5, 3);
										PlayerPrefs.SetInt ("statesung", 17);
										RamboState.state_sung = 17;

										DMG.Value = 0.6f;
										SPEED.Value = 0.4f;
										ACC.Value = 0.4f;
										CATRIDGE.Value = 0.4f;
										chiso1 = 0;
										chiso2 = 0;
										chiso3 = 0;
										chiso4 = 2;
								} else {
										naptien ();

								}
						} else if (RamboState.gun_buy [5] == 3) {
								if (RamboState.dola >= 1500) {
										items [gunIndex].SetActive (false);
										RamboState.dola -= 1500;
										iconM4A1.BackgroundSprite = "ss4";
										m4a1_lv.BackgroundSprite = "Rifle_M4A1_4";
										btnBuyM4A1.IsVisible = false;
										lblUpdateM4a1.Text = "";
										gunIndex = 18;
										items [gunIndex].SetActive (true);
										btnBuyM4A1.IsVisible = false;
										labelName.Text = RamboState.m4a1_lv4;
										RamboState.gun_buy [5] = 4;
										PlayerPrefs.SetInt ("gunBuy" + 5, 4);
										PlayerPrefs.SetInt ("statesung", 18);
										RamboState.state_sung = 18;

										DMG.Value = 0.6f;
										SPEED.Value = 0.4f;
										ACC.Value = 0.4f;
										CATRIDGE.Value = 0.6f;
										chiso1 = 0;
										chiso2 = 0;
										chiso3 = 0;
										chiso4 = 0;
								} else {
										naptien ();
								}
						}
						#endregion
				} else if (control.name == "Button Buy Scar") {
						#region Buy Scar
						if (RamboState.gun_buy [6] == 0) {
                print("check unlock gun____________________ " + RamboState.check_unlock_gun[4]);
                if (RamboState.check_unlock_gun [4] == 1 || RamboState.state_level1 [19] > 0 || RamboState.state_level2 [19] > 0 || RamboState.state_level3 [19] > 0) {  
										if (RamboState.dola >= 7500) {
												items [gunIndex].SetActive (false);
												RamboState.dola -= 7500;
												btnBuyScar.Text = "Upgrade";
												lblUpdateScar.Text = "1.000";
												gunIndex = 19;
												items [gunIndex].SetActive (true);
												labelName.Text = RamboState.scar_lv1;
												RamboState.gun_buy [6] = 1;
												PlayerPrefs.SetInt ("gunBuy" + 6, 1);
												PlayerPrefs.SetInt ("statesung", 19);
												RamboState.state_sung = 19;
												RamboState.total_bullet_sungtia += 20;
												lblNumberBulletOfMP5.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfUZI.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfKISS.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfM4A1.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfSCAR.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfWA.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfVip1.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfVip2.Text = RamboState.total_bullet_sungtia.ToString ();
												spEquip [0].SetActive (false);
												spEquip [1].SetActive (false);
												spEquip [2].SetActive (false);
												spEquip [3].SetActive (false);
												spEquip [4].SetActive (false);
												spEquip [5].SetActive (false);
												spEquip [6].SetActive (true);
												spEquip [7].SetActive (false);
												spEquip [8].SetActive (false);
												spEquip [9].SetActive (false);
												spEquip [23].SetActive (false);
												spEquip [24].SetActive (false);
												spEquip [25].SetActive (false);
												DMG.Value = 0.6f;
												SPEED.Value = 0.6f;
												ACC.Value = 0.2f;
												CATRIDGE.Value = 0.2f;
												chiso1 = 0;
												chiso2 = 2;
												chiso3 = 0;
												chiso4 = 0;
										} else {
												naptien ();

										}
								} else {
										GameObject.Find ("Unlockgun").GetComponent<dfTweenVector3> ().Play ();
										GameObject.Find ("textunlock").GetComponent<dfLabel> ().Text = "Unlock at chapter 3";
										GameObject.Find ("Camera 3D").GetComponent<Camera> ().enabled = false;
										RamboState.state_unlock = 5;
                    print("state unlock gun____________________ " + RamboState.state_unlock);
                }
						} else if (RamboState.gun_buy [6] == 1) {
								if (RamboState.dola >= 1000) {
										items [gunIndex].SetActive (false);
										iconScar.BackgroundSprite = "ss2";
										scar_lv.BackgroundSprite = "Rifle_Scar_2";
										btnBuyScar.Text = "Upgrade";
										lblUpdateScar.Text = "2.000";
										RamboState.dola -= 1000;
										gunIndex = 20;
										items [gunIndex].SetActive (true);
										labelName.Text = RamboState.scar_lv2;
										RamboState.gun_buy [6] = 2;
										PlayerPrefs.SetInt ("gunBuy" + 6, 2);
										PlayerPrefs.SetInt ("statesung", 20);
										RamboState.state_sung = 20;

										DMG.Value = 0.6f;
										SPEED.Value = 0.8f;
										ACC.Value = 0.2f;
										CATRIDGE.Value = 0.2f;
										chiso1 = 0;
										chiso2 = 0;
										chiso3 = 2;
										chiso4 = 0;
								} else {
										naptien ();

								}
						} else if (RamboState.gun_buy [6] == 2) {
								if (RamboState.dola >= 2000) {
										items [gunIndex].SetActive (false);
										RamboState.dola -= 2000;
										iconScar.BackgroundSprite = "ss3";
										scar_lv.BackgroundSprite = "Rifle_Scar_3";
										btnBuyScar.Text = "Upgrade";
										lblUpdateScar.Text = "3.000";
										gunIndex = 21;
										items [gunIndex].SetActive (true);
										labelName.Text = RamboState.scar_lv3;
										RamboState.gun_buy [6] = 3;
										PlayerPrefs.SetInt ("gunBuy" + 6, 3);
										PlayerPrefs.SetInt ("statesung", 21);
										RamboState.state_sung = 21;

										DMG.Value = 0.6f;
										SPEED.Value = 0.8f;
										ACC.Value = 0.4f;
										CATRIDGE.Value = 0.2f;
										chiso1 = 0;
										chiso2 = 0;
										chiso3 = 2;
										chiso4 = 0;
								} else {
										naptien ();

								}
						} else if (RamboState.gun_buy [6] == 3) {
								if (RamboState.dola >= 3000) {
										items [gunIndex].SetActive (false);
										RamboState.dola -= 3000;
										iconScar.BackgroundSprite = "ss4";
										scar_lv.BackgroundSprite = "Rifle_Scar_4";
										btnBuyScar.IsVisible = false;
										lblUpdateScar.Text = "";
										gunIndex = 22;
										items [gunIndex].SetActive (true);
										labelName.Text = RamboState.scar_lv4;
										btnBuyM4A1.IsVisible = false;
										RamboState.gun_buy [6] = 4;
										PlayerPrefs.SetInt ("gunBuy" + 6, 4);
										PlayerPrefs.SetInt ("statesung", 22);
										RamboState.state_sung = 22;

										DMG.Value = 0.6f;
										SPEED.Value = 0.8f;
										ACC.Value = 0.6f;
										CATRIDGE.Value = 0.2f;
										chiso1 = 0;
										chiso2 = 0;
										chiso3 = 0;
										chiso4 = 0;
								} else {
										naptien ();

								}
						}
						#endregion
				} else if (control.name == "Button Buy AWP") {
						#region Buy AWP
						if (RamboState.gun_buy [7] == 0) {
                print("check unlock gun____________________ " + RamboState.check_unlock_gun[5]);
                if (RamboState.check_unlock_gun [5] == 1 || RamboState.state_level1 [19] > 0 || RamboState.state_level2 [19] > 0 || RamboState.state_level3 [19] > 0) {  
										if (RamboState.dola >= 25000) {
												items [gunIndex].SetActive (false);
												RamboState.dola -= 25000;
												btnBuyAWP.Text = "Upgrade";
												lblUpdateAwp.Text = "5.000";
												gunIndex = 23;
												items [gunIndex].SetActive (true);
												labelName.Text = RamboState.awp_lv1;
												RamboState.gun_buy [7] = 1;
												PlayerPrefs.SetInt ("gunBuy" + 7, 1);
												PlayerPrefs.SetInt ("statesung", 23);
												RamboState.state_sung = 23;
												RamboState.total_bullet_sungngam += 5;
												lblNumberBulletOfAWP.Text = RamboState.total_bullet_sungngam.ToString ();
									
												spEquip [0].SetActive (false);
												spEquip [1].SetActive (false);
												spEquip [2].SetActive (false);
												spEquip [3].SetActive (false);
												spEquip [4].SetActive (false);
												spEquip [5].SetActive (false);
												spEquip [6].SetActive (false);
												spEquip [7].SetActive (true);
												spEquip [8].SetActive (false);
												spEquip [9].SetActive (false);
												spEquip [23].SetActive (false);
												spEquip [24].SetActive (false);
												spEquip [25].SetActive (false);
												DMG.Value = 1f;
												SPEED.Value = 0.2f;
												ACC.Value = 0.6f;
												CATRIDGE.Value = 0.2f;
												chiso1 = 0;
												chiso2 = 2;
												chiso3 = 0;
												chiso4 = 0;
										} else {
												naptien ();

										}
								} else {
										GameObject.Find ("Unlockgun").GetComponent<dfTweenVector3> ().Play ();
										GameObject.Find ("textunlock").GetComponent<dfLabel> ().Text = "Unlock at chapter 3";
										GameObject.Find ("Camera 3D").GetComponent<Camera> ().enabled = false;
										RamboState.state_unlock = 6;
                    print("state unlock gun____________________ " + RamboState.state_unlock);
                }
						} else if (RamboState.gun_buy [7] == 1) {
								if (RamboState.dola >= 5000) {
										items [gunIndex].SetActive (false);
										iconAWP.BackgroundSprite = "ss2";
										awp_lv.BackgroundSprite = "SMG_AWP2";
										btnBuyAWP.Text = "Upgrade";
										lblUpdateAwp.Text = "5.000";
										RamboState.dola -= 5000;
										gunIndex = 24;
										items [gunIndex].SetActive (true);
										labelName.Text = RamboState.awp_lv2;
										RamboState.gun_buy [7] = 2;
										PlayerPrefs.SetInt ("gunBuy" + 7, 2);
										PlayerPrefs.SetInt ("statesung", 24);
										RamboState.state_sung = 24;

										DMG.Value = 1f;
										SPEED.Value = 0.4f;
										ACC.Value = 0.6f;
										CATRIDGE.Value = 0.2f;
										chiso1 = 0;
										chiso2 = 0;
										chiso3 = 0;
										chiso4 = 2;
								} else {
										naptien ();
								}
						} else if (RamboState.gun_buy [7] == 2) {
								if (RamboState.dola >= 5000) {
										items [gunIndex].SetActive (false);
										RamboState.dola -= 5000;
										iconAWP.BackgroundSprite = "ss3";
										awp_lv.BackgroundSprite = "SMG_AWP3";
										btnBuyAWP.IsVisible = false;
										lblUpdateAwp.Text = "";
										gunIndex = 25;
										items [gunIndex].SetActive (true);
										labelName.Text = RamboState.awp_lv3;
										RamboState.gun_buy [7] = 3;
										PlayerPrefs.SetInt ("gunBuy" + 7, 3);
										PlayerPrefs.SetInt ("statesung", 25);
										RamboState.state_sung = 25;

										DMG.Value = 1f;
										SPEED.Value = 0.4f;
										ACC.Value = 0.6f;
										CATRIDGE.Value = 0.4f;
										chiso1 = 0;
										chiso2 = 0;
										chiso3 = 0;
										chiso4 = 0;
								} else {
										naptien ();
								}
						}
						#endregion
				} else if (control.name == "Button Buy WA") {
						#region Buy Wa
						if (RamboState.gun_buy [8] == 0) {
                print("check unlock gun____________________ " + RamboState.check_unlock_gun[6]);
                if (RamboState.check_unlock_gun [6] == 1 || RamboState.state_level1 [29] > 0 || RamboState.state_level2 [29] > 0 || RamboState.state_level3 [29] > 0) {  
										if (RamboState.dola >= 45000) {
												items [gunIndex].SetActive (false);
												RamboState.dola -= 45000;
												btnWa.Text = "Upgrade";
												lblUpdateWa.Text = "5.000";
												RamboState.total_bullet_sungtia += 30;
										
												lblNumberBulletOfWA.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfMP5.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfUZI.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfKISS.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfM4A1.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfSCAR.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfVip1.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfVip2.Text = RamboState.total_bullet_sungtia.ToString ();
												gunIndex = 26;
												items [gunIndex].SetActive (true);
												labelName.Text = RamboState.wa_lv1;
												RamboState.gun_buy [8] = 1;
												PlayerPrefs.SetInt ("gunBuy" + 8, 1);
												PlayerPrefs.SetInt ("statesung", 26);
												RamboState.state_sung = 26;
												spEquip [0].SetActive (false);
												spEquip [1].SetActive (false);
												spEquip [2].SetActive (false);
												spEquip [3].SetActive (false);
												spEquip [4].SetActive (false);
												spEquip [5].SetActive (false);
												spEquip [6].SetActive (false);
												spEquip [7].SetActive (false);
												spEquip [8].SetActive (true);
												spEquip [9].SetActive (false);
												spEquip [23].SetActive (false);
												spEquip [24].SetActive (false);
												spEquip [25].SetActive (false);
												DMG.Value = 0.8f;
												SPEED.Value = 0.2f;
												ACC.Value = 0.6f;
												CATRIDGE.Value = 0.2f;
												chiso1 = 0;
												chiso2 = 0;
												chiso3 = 0;
												chiso4 = 4;
										} else {
												naptien ();

										}
								} else {
										GameObject.Find ("Unlockgun").GetComponent<dfTweenVector3> ().Play ();
										GameObject.Find ("textunlock").GetComponent<dfLabel> ().Text = "Unlock at chapter 4";
										GameObject.Find ("Camera 3D").GetComponent<Camera> ().enabled = false;
										RamboState.state_unlock = 7;
                    print("state unlock gun____________________ " + RamboState.state_unlock);
                }
						} else if (RamboState.gun_buy [8] == 1) {
								if (RamboState.dola >= 5000) {
										items [gunIndex].SetActive (false);
										iconWA.BackgroundSprite = "ss2";
										wa_lv.BackgroundSprite = "SNIPER_WA2000_2";
										btnWa.Text = "Upgrade";
										lblUpdateWa.Text = "5.000";
										RamboState.dola -= 5000;
										gunIndex = 27;
										items [gunIndex].SetActive (true);
										labelName.Text = RamboState.wa_lv2;
										RamboState.gun_buy [8] = 2;
										PlayerPrefs.SetInt ("gunBuy" + 8, 2);
										PlayerPrefs.SetInt ("statesung", 27);
										RamboState.state_sung = 27;

										DMG.Value = 0.8f;
										SPEED.Value = 0.2f;
										ACC.Value = 0.6f;
										CATRIDGE.Value = 0.6f;
										chiso1 = 2;
										chiso2 = 0;
										chiso3 = 2;
										chiso4 = 0;
								} else {
										naptien ();

								}
						} else if (RamboState.gun_buy [8] == 2) {
								if (RamboState.dola >= 5000) {
										items [gunIndex].SetActive (false);
										RamboState.dola -= 5000;
										iconWA.BackgroundSprite = "ss3";
										wa_lv.BackgroundSprite = "SNIPER_WA2000_3";
										btnWa.IsVisible = false;
										lblUpdateWa.Text = "";
										gunIndex = 28;
										items [gunIndex].SetActive (true);
										labelName.Text = RamboState.wa_lv3;
										RamboState.gun_buy [8] = 3;
										PlayerPrefs.SetInt ("gunBuy" + 8, 3);
										PlayerPrefs.SetInt ("statesung", 28);
										RamboState.state_sung = 28;

										DMG.Value = 1f;
										SPEED.Value = 0.2f;
										ACC.Value = 0.8f;
										CATRIDGE.Value = 0.6f;
										chiso1 = 0;
										chiso2 = 0;
										chiso3 = 0;
										chiso4 = 0;
								} else {
										naptien ();

								}
						}
						#endregion
				} else if (control.name == "Button Buy Bazooka") {  
						OpenIAB.purchaseProduct (OpenIABTest.BUYBAZOOKA);   

//						if (RamboState.gun_buy [9] == 0) {
//				if (RamboState.check_unlock_gun [3] == 1 || RamboState.state_level1 [29] > 0|| RamboState.state_level2 [29] > 0|| RamboState.state_level3 [29] > 0) {  
//										if (RamboState.dola >= 55000) {
//												items [gunIndex].SetActive (false);
//												RamboState.dola -= 55000;
//					
//												gunIndex = 29;
//												items [gunIndex].SetActive (true);
//												btnBuyBazooka.IsVisible = false;
//												labelName.Text = RamboState.bazooka;
//												RamboState.total_bullet_sung_tenlua += 5;
//												lblNumberBulletOfBAZOOKA.Text = RamboState.total_bullet_sung_tenlua.ToString ();
//												RamboState.gun_buy [9] = 1;
//												PlayerPrefs.SetInt ("gunBuy" + 9, 1);
//												PlayerPrefs.SetInt ("statesung", 29);
//												iconBazooka.BackgroundSprite = "ss4";
//												RamboState.state_sung = 29;
//												spEquip [0].SetActive (false);
//												spEquip [1].SetActive (false);
//												spEquip [2].SetActive (false);
//												spEquip [3].SetActive (false);
//												spEquip [4].SetActive (false);
//												spEquip [5].SetActive (false);
//												spEquip [6].SetActive (false);
//												spEquip [7].SetActive (false);
//												spEquip [8].SetActive (false);
//												spEquip [9].SetActive (true);
//						
//												DMG.Value = 1f;
//												SPEED.Value = 0.2f;
//												ACC.Value = 1f;
//												CATRIDGE.Value = 0.2f;
//										} else {
//												naptien ();
//						
//										}
//								} else {
//										GameObject.Find ("Unlockgun").GetComponent<dfTweenVector3> ().Play ();
//										GameObject.Find ("textunlock").GetComponent<dfLabel> ().Text = "Unlock at chapter 4";
//										GameObject.Find ("Camera 3D").GetComponent<Camera> ().enabled = false;
//										RamboState.state_unlock = 4;
//					
//								}
//						}





				} else if (control.name == "Button Buy Headsnake") {  
						OpenIAB.purchaseProduct (OpenIABTest.BUYGUNVIP1);   		
			
				} else if (control.name == "Button Buy Lineargun") {  
						OpenIAB.purchaseProduct (OpenIABTest.BUYGUNVIP2);   		
			
				} else if (control.name == "Button Buy Triomissiles") {  
						OpenIAB.purchaseProduct (OpenIABTest.BUYGUNVIP3);   		
			
				}



		}
    #endregion

    #region View Gun
		public void ViewGun (dfControl control, dfMouseEventArgs mouseEvent)
		{       // xem sung
				GameObject.Find ("Click").GetComponent<SoundClick> ().play ();  
				if (control.name == "Panel 0") {
						#region View Pistol
						panelPistol.BackgroundSprite = "bb_equip";
						panelM3.BackgroundSprite = "bb_unequip";
						panelMP5.BackgroundSprite = "bb_unequip";
						panelUZI.BackgroundSprite = "bb_unequip";
						panelKISS.BackgroundSprite = "bb_unequip";
						panelAWP.BackgroundSprite = "bb_unequip";
						panelSCAR.BackgroundSprite = "bb_unequip";
						panelWA.BackgroundSprite = "bb_unequip";
						panelBazooka.BackgroundSprite = "bb_unequip";
						panelM4A1.BackgroundSprite = "bb_unequip";
						panelVip1.BackgroundSprite = "bb_unequip";
						panelVip2.BackgroundSprite = "bb_unequip";
						panelVip3.BackgroundSprite = "bb_unequip";
						for (int i = 0; i < items.Length; i++) {
								if (i == 0 || i == 1 || i == 2) {
										if (RamboState.state_sung == 0 || RamboState.state_sung == 1 || RamboState.state_sung == 2) {
												items [RamboState.state_sung].SetActive (true);
										}
								} else {
										items [i].SetActive (false);
								}

						}
						if (RamboState.gun_buy [0] == 1) {    
								spEquip [0].SetActive (true);
								spEquip [1].SetActive (false);
								spEquip [2].SetActive (false);
								spEquip [3].SetActive (false);
								spEquip [4].SetActive (false);
								spEquip [5].SetActive (false);
								spEquip [6].SetActive (false);
								spEquip [7].SetActive (false);
								spEquip [8].SetActive (false);
								spEquip [9].SetActive (false);

								DMG.Value = 0.2f;
								SPEED.Value = 0.2f;
								ACC.Value = 0.2f;
								CATRIDGE.Value = 0.2f;
								chiso1 = 2;
								chiso2 = 2;
								chiso3 = 0;
								chiso4 = 0;
								btnBuyPistol.Text = "UPGRADE";
								lblUpdatePistol.Text = "300";

								labelName.Text = RamboState.pistol_lv1;
								for (int i = 0; i < items.Length; i++) {
										if (i == 0)
												items [i].SetActive (true);
										else
												items [i].SetActive (false);
								}
								RamboState.state_sung = 0;
						} else if (RamboState.gun_buy [0] == 2) {
								spEquip [0].SetActive (true);
								spEquip [1].SetActive (false);
								spEquip [2].SetActive (false);
								spEquip [3].SetActive (false);
								spEquip [4].SetActive (false);
								spEquip [5].SetActive (false);
								spEquip [6].SetActive (false);
								spEquip [7].SetActive (false);
								spEquip [8].SetActive (false);
								spEquip [9].SetActive (false);
								spEquip [23].SetActive (false);
								spEquip [24].SetActive (false);
								spEquip [25].SetActive (false);
								DMG.Value = 0.4f;
								SPEED.Value = 0.4f;
								ACC.Value = 0.2f;
								CATRIDGE.Value = 0.2f;
								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 0;
								chiso4 = 2;

								btnBuyPistol.Text = "UPGRADE";
								lblUpdatePistol.Text = "400";
								iconPistol.BackgroundSprite = "ss2";
								pistollv.BackgroundSprite = "Pistol_FiveSeven_2";

								labelName.Text = RamboState.pistol_lv2;
								items [0].SetActive (false);
								items [1].SetActive (true);
								items [2].SetActive (false);
								RamboState.state_sung = 1;
						} else if (RamboState.gun_buy [0] == 3) {
								spEquip [0].SetActive (true);
								spEquip [1].SetActive (false);
								spEquip [2].SetActive (false);
								spEquip [3].SetActive (false);
								spEquip [4].SetActive (false);
								spEquip [5].SetActive (false);
								spEquip [6].SetActive (false);
								spEquip [7].SetActive (false);
								spEquip [8].SetActive (false);
								spEquip [9].SetActive (false);
								spEquip [23].SetActive (false);
								spEquip [24].SetActive (false);
								spEquip [25].SetActive (false);
								DMG.Value = 0.4f;
								SPEED.Value = 0.4f;
								ACC.Value = 0.2f;
								CATRIDGE.Value = 0.4f;
								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 0;
								chiso4 = 0;

								labelName.Text = RamboState.pistol_lv3;
								iconPistol.BackgroundSprite = "ss3";
								pistollv.BackgroundSprite = "Pistol_FiveSeven_3";
								btnBuyPistol.IsVisible = false;
								lblUpdatePistol.Text = "";
								items [0].SetActive (false);
								items [1].SetActive (false);
								items [2].SetActive (true);
								RamboState.state_sung = 2;
						}
						#endregion
				} else if (control.name == "Panel 1") {     
						#region View M3
						//if (RamboState.huongdanshop == 0 && GameObject.Find ("Tutorial").GetComponent<TutorialShop> ().state == 0)

						//		GameObject.Find ("Tutorial").GetComponent<TutorialShop> ().state = 1;

						panelM3.BackgroundSprite = "bb_equip";
						panelPistol.BackgroundSprite = "bb_unequip";
						panelMP5.BackgroundSprite = "bb_unequip";
						panelUZI.BackgroundSprite = "bb_unequip";
						panelKISS.BackgroundSprite = "bb_unequip";
						panelAWP.BackgroundSprite = "bb_unequip";
						panelSCAR.BackgroundSprite = "bb_unequip";
						panelWA.BackgroundSprite = "bb_unequip";
						panelVip1.BackgroundSprite = "bb_unequip";
						panelVip2.BackgroundSprite = "bb_unequip";
						panelVip3.BackgroundSprite = "bb_unequip";


						panelBazooka.BackgroundSprite = "bb_unequip";
						panelM4A1.BackgroundSprite = "bb_unequip";
						for (int i = 0; i < items.Length; i++) {
								if (i == 3 || i == 4 || i == 5 || i == 6) {
										if (RamboState.state_sung == 3 || RamboState.state_sung == 4 || RamboState.state_sung == 5 || RamboState.state_sung == 6) {
												items [RamboState.state_sung].SetActive (true);
										}
								} else {
										items [i].SetActive (false);
								}
						}
						if (RamboState.gun_buy [1] == 0) {
								lblUpdateM3.Text = "300";
								labelName.Text = RamboState.m3_lv1;
								m3_lv.BackgroundSprite = "ShortGun_M3";
								DMG.Value = 0.6f;
								SPEED.Value = 0.2f;
								ACC.Value = 0.2f;
								CATRIDGE.Value = 0.2f;
								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 0;
								chiso4 = 0;
								for (int i = 0; i < items.Length; i++) {
										if (i == 3)
												items [i].SetActive (true);
										else
												items [i].SetActive (false);
								}
						} else if (RamboState.gun_buy [1] == 1) {
								spEquip [0].SetActive (false);
								spEquip [1].SetActive (true);
								spEquip [2].SetActive (false);
								spEquip [3].SetActive (false);
								spEquip [4].SetActive (false);
								spEquip [5].SetActive (false);
								spEquip [6].SetActive (false);
								spEquip [7].SetActive (false);
								spEquip [8].SetActive (false);
								spEquip [9].SetActive (false);
								spEquip [23].SetActive (false);
								spEquip [24].SetActive (false);
								spEquip [25].SetActive (false);
								m3_lv.BackgroundSprite = "ShortGun_M3";
								DMG.Value = 0.6f;
								SPEED.Value = 0.2f;
								ACC.Value = 0.2f;
								CATRIDGE.Value = 0.2f;
								chiso1 = 0;
								chiso2 = 2;
								chiso3 = 0;
								chiso4 = 0;
								lblUpdateM3.Text = "300";
								labelName.Text = RamboState.m3_lv1;
								btnBuyM3.Text = "UPGRADE";
								items [3].SetActive (true);
								items [4].SetActive (false);
								items [5].SetActive (false);
								items [6].SetActive (false);
								RamboState.state_sung = 3;
						} else if (RamboState.gun_buy [1] == 2) {
								spEquip [0].SetActive (false);
								spEquip [1].SetActive (true);
								spEquip [2].SetActive (false);
								spEquip [3].SetActive (false);
								spEquip [4].SetActive (false);
								spEquip [5].SetActive (false);
								spEquip [6].SetActive (false);
								spEquip [7].SetActive (false);
								spEquip [8].SetActive (false);
								spEquip [9].SetActive (false);
								spEquip [23].SetActive (false);
								spEquip [24].SetActive (false);
								spEquip [25].SetActive (false);
								DMG.Value = 0.6f;
								SPEED.Value = 0.4f;
								ACC.Value = 0.2f;
								CATRIDGE.Value = 0.2f;
								chiso1 = 2;
								chiso2 = 0;
								chiso3 = 0;
								chiso4 = 4;

								lblUpdateM3.Text = "500";
								labelName.Text = RamboState.m3_lv2;
								iconM3.BackgroundSprite = "ss2";
								m3_lv.BackgroundSprite = "ShortGun_M3_2";
								btnBuyM3.Text = "UPGRADE";
								items [3].SetActive (false);
								items [4].SetActive (true);
								items [5].SetActive (false);
								items [6].SetActive (false);
								RamboState.state_sung = 4;
						} else if (RamboState.gun_buy [1] == 3) {
								spEquip [0].SetActive (false);
								spEquip [1].SetActive (true);
								spEquip [2].SetActive (false);
								spEquip [3].SetActive (false);
								spEquip [4].SetActive (false);
								spEquip [5].SetActive (false);
								spEquip [6].SetActive (false);
								spEquip [7].SetActive (false);
								spEquip [8].SetActive (false);
								spEquip [9].SetActive (false);
								spEquip [23].SetActive (false);
								spEquip [24].SetActive (false);
								spEquip [25].SetActive (false);
								DMG.Value = 0.8f;
								SPEED.Value = 0.4f;
								ACC.Value = 0.2f;
								CATRIDGE.Value = 0.6f;
								chiso1 = 0;
								chiso2 = 2;
								chiso3 = 0;
								chiso4 = 0;

								lblUpdateM3.Text = "1000";
								labelName.Text = RamboState.m3_lv3;
								iconM3.BackgroundSprite = "ss3";
								m3_lv.BackgroundSprite = "ShortGun_M3_3";
								btnBuyM3.Text = "UPGRADE";
								items [3].SetActive (false);
								items [4].SetActive (false);
								items [5].SetActive (true);
								items [6].SetActive (false);
								RamboState.state_sung = 5;
						} else if (RamboState.gun_buy [1] == 4) {
								spEquip [0].SetActive (false);
								spEquip [1].SetActive (true);
								spEquip [2].SetActive (false);
								spEquip [3].SetActive (false);
								spEquip [4].SetActive (false);
								spEquip [5].SetActive (false);
								spEquip [6].SetActive (false);
								spEquip [7].SetActive (false);
								spEquip [8].SetActive (false);
								spEquip [9].SetActive (false);
								spEquip [23].SetActive (false);
								spEquip [24].SetActive (false);
								spEquip [25].SetActive (false);
								DMG.Value = 0.8f;
								SPEED.Value = 0.6f;
								ACC.Value = 0.2f;
								CATRIDGE.Value = 0.6f;
								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 0;
								chiso4 = 0;
								lblUpdateM3.Text = "";
								labelName.Text = RamboState.m3_lv4;
								iconM3.BackgroundSprite = "ss4";
								m3_lv.BackgroundSprite = "ShortGun_M3_4";
								btnBuyM3.IsVisible = false;
								items [3].SetActive (false);
								items [4].SetActive (false);
								items [5].SetActive (false);
								items [6].SetActive (true);
								RamboState.state_sung = 6;

						}
						#endregion
				} else if (control.name == "Panel 2") {
						#region View MP5
						panelM3.BackgroundSprite = "bb_unequip";
						panelPistol.BackgroundSprite = "bb_unequip";
						panelMP5.BackgroundSprite = "bb_equip";
						panelUZI.BackgroundSprite = "bb_unequip";
						panelKISS.BackgroundSprite = "bb_unequip";
						panelAWP.BackgroundSprite = "bb_unequip";
						panelSCAR.BackgroundSprite = "bb_unequip";
						panelWA.BackgroundSprite = "bb_unequip";
						panelBazooka.BackgroundSprite = "bb_unequip";
						panelM4A1.BackgroundSprite = "bb_unequip";
						panelVip1.BackgroundSprite = "bb_unequip";
						panelVip2.BackgroundSprite = "bb_unequip";
						panelVip3.BackgroundSprite = "bb_unequip";
						for (int i = 0; i < items.Length; i++) {
								if (i == 7 || i == 8) {
										if (RamboState.state_sung == 7 || RamboState.state_sung == 8) {
												items [RamboState.state_sung].SetActive (true);
										}
								} else {
										items [i].SetActive (false);
								}

						}
						if (RamboState.gun_buy [2] == 0) {
								lblUpdateMp5.Text = "1.000";
								labelName.Text = RamboState.mp5_lv1;

								DMG.Value = 0.2f;
								SPEED.Value = 0.2f;
								ACC.Value = 0.6f;
								CATRIDGE.Value = 0.2f;
								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 0;
								chiso4 = 0;

								for (int i = 0; i < items.Length; i++) {
										if (i == 7)
												items [i].SetActive (true);
										else
												items [i].SetActive (false);
								}
						} else if (RamboState.gun_buy [2] == 1) {

								spEquip [0].SetActive (false);
								spEquip [1].SetActive (false);
								spEquip [2].SetActive (true);
								spEquip [3].SetActive (false);
								spEquip [4].SetActive (false);
								spEquip [5].SetActive (false);
								spEquip [6].SetActive (false);
								spEquip [7].SetActive (false);
								spEquip [8].SetActive (false);
								spEquip [9].SetActive (false);
								spEquip [23].SetActive (false);
								spEquip [24].SetActive (false);
								spEquip [25].SetActive (false);
								DMG.Value = 0.2f;
								SPEED.Value = 0.2f;
								ACC.Value = 0.6f;
								CATRIDGE.Value = 0.2f;
								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 4;
								chiso4 = 0;

								lblUpdateMp5.Text = "500";
								labelName.Text = RamboState.mp5_lv1;
								btnBuyMP5.Text = "UPGRADE";
								items [7].SetActive (true);
								items [8].SetActive (false);
								RamboState.state_sung = 7;

						} else if (RamboState.gun_buy [2] == 2) {
								spEquip [0].SetActive (false);
								spEquip [1].SetActive (false);
								spEquip [2].SetActive (true);
								spEquip [3].SetActive (false);
								spEquip [4].SetActive (false);
								spEquip [5].SetActive (false);
								spEquip [6].SetActive (false);
								spEquip [7].SetActive (false);
								spEquip [8].SetActive (false);
								spEquip [9].SetActive (false);

								DMG.Value = 0.2f;
								SPEED.Value = 0.2f;
								ACC.Value = 1;
								CATRIDGE.Value = 0.2f;

								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 0;
								chiso4 = 0;
								lblUpdateMp5.Text = "";
								labelName.Text = RamboState.mp5_lv2;
								iconMP5.BackgroundSprite = "ss2";
								mp5_lv.BackgroundSprite = "SMG_MP5_2";
								btnBuyMP5.IsVisible = false;
								items [7].SetActive (false);
								items [8].SetActive (true);
								RamboState.state_sung = 8;

						}
						#endregion
				} else if (control.name == "Panel 3") {
						#region View UZI
						panelM3.BackgroundSprite = "bb_unequip";
						panelPistol.BackgroundSprite = "bb_unequip";
						panelMP5.BackgroundSprite = "bb_unequip";
						panelUZI.BackgroundSprite = "bb_equip";
						panelKISS.BackgroundSprite = "bb_unequip";
						panelAWP.BackgroundSprite = "bb_unequip";
						panelSCAR.BackgroundSprite = "bb_unequip";
						panelWA.BackgroundSprite = "bb_unequip";
						panelBazooka.BackgroundSprite = "bb_unequip";
						panelM4A1.BackgroundSprite = "bb_unequip";
						panelVip1.BackgroundSprite = "bb_unequip";
						panelVip2.BackgroundSprite = "bb_unequip";
						panelVip3.BackgroundSprite = "bb_unequip";
						for (int i = 0; i < items.Length; i++) {
								if (i == 9 || i == 10 || i == 11) {
										if (RamboState.state_sung == 9 || RamboState.state_sung == 10 || RamboState.state_sung == 11)
												items [RamboState.state_sung].SetActive (true);
								} else {
										items [i].SetActive (false);
								}

						}
						if (RamboState.gun_buy [3] == 0) {
								lblUpdateUzi.Text = "1.500";
								labelName.Text = RamboState.uzi_lv1;

								DMG.Value = 0.2f;
								SPEED.Value = 0.2f;
								ACC.Value = 0.4f;
								CATRIDGE.Value = 0.4f;
								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 0;
								chiso4 = 0;
								for (int i = 0; i < items.Length; i++) {
										if (i == 9)
												items [i].SetActive (true);
										else
												items [i].SetActive (false);
								}
						} else if (RamboState.gun_buy [3] == 1) {
								spEquip [0].SetActive (false);
								spEquip [1].SetActive (false);
								spEquip [2].SetActive (false);
								spEquip [3].SetActive (true);
								spEquip [4].SetActive (false);
								spEquip [5].SetActive (false);
								spEquip [6].SetActive (false);
								spEquip [7].SetActive (false);
								spEquip [8].SetActive (false);
								spEquip [9].SetActive (false);
								spEquip [23].SetActive (false);
								spEquip [24].SetActive (false);
								spEquip [25].SetActive (false);
								DMG.Value = 0.2f;
								SPEED.Value = 0.2f;
								ACC.Value = 0.4f;
								CATRIDGE.Value = 0.4f;
								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 2;
								chiso4 = 2;
								lblUpdateUzi.Text = "500";
								labelName.Text = RamboState.uzi_lv1;
								btnBuyUZI.Text = "UPGRADE";
								items [9].SetActive (true);
								items [10].SetActive (false);
								items [11].SetActive (false);
								RamboState.state_sung = 9;
						} else if (RamboState.gun_buy [3] == 2) {
								spEquip [0].SetActive (false);
								spEquip [1].SetActive (false);
								spEquip [2].SetActive (false);
								spEquip [3].SetActive (true);
								spEquip [4].SetActive (false);
								spEquip [5].SetActive (false);
								spEquip [6].SetActive (false);
								spEquip [7].SetActive (false);
								spEquip [8].SetActive (false);
								spEquip [9].SetActive (false);
								spEquip [23].SetActive (false);
								spEquip [24].SetActive (false);
								spEquip [25].SetActive (false);

								DMG.Value = 0.2f;
								SPEED.Value = 0.2f;
								ACC.Value = 0.6f;
								CATRIDGE.Value = 0.6f;
								chiso1 = 4;
								chiso2 = 0;
								chiso3 = 0;
								chiso4 = 0;

								lblUpdateUzi.Text = "1.000";
								labelName.Text = RamboState.uzi_lv2;
								iconUZI.BackgroundSprite = "ss2";
								uzi_lv.BackgroundSprite = "SMG_UZI_2";
								btnBuyUZI.Text = "UPGRADE";
								items [9].SetActive (false);
								items [10].SetActive (true);
								items [11].SetActive (false);
								RamboState.state_sung = 10;
						} else if (RamboState.gun_buy [3] == 3) {
								spEquip [0].SetActive (false);
								spEquip [1].SetActive (false);
								spEquip [2].SetActive (false);
								spEquip [3].SetActive (true);
								spEquip [4].SetActive (false);
								spEquip [5].SetActive (false);
								spEquip [6].SetActive (false);
								spEquip [7].SetActive (false);
								spEquip [8].SetActive (false);
								spEquip [9].SetActive (false);
								spEquip [23].SetActive (false);
								spEquip [24].SetActive (false);
								spEquip [25].SetActive (false);
								DMG.Value = 0.6f;
								SPEED.Value = 0.2f;
								ACC.Value = 0.6f;
								CATRIDGE.Value = 0.6f;
								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 0;
								chiso4 = 0;

								lblUpdateUzi.Text = "";
								labelName.Text = RamboState.uzi_lv3;
								iconUZI.BackgroundSprite = "ss3";
								uzi_lv.BackgroundSprite = "SMG_UZI_3";
								btnBuyUZI.IsVisible = false;
								items [9].SetActive (false);
								items [10].SetActive (false);
								items [11].SetActive (true);
								RamboState.state_sung = 11;
						}
						#endregion
				} else if (control.name == "Panel 4") {
						#region View KISS
						panelM3.BackgroundSprite = "bb_unequip";
						panelPistol.BackgroundSprite = "bb_unequip";
						panelMP5.BackgroundSprite = "bb_unequip";
						panelUZI.BackgroundSprite = "bb_unequip";
						panelKISS.BackgroundSprite = "bb_equip";
						panelAWP.BackgroundSprite = "bb_unequip";
						panelSCAR.BackgroundSprite = "bb_unequip";
						panelWA.BackgroundSprite = "bb_unequip";
						panelBazooka.BackgroundSprite = "bb_unequip";
						panelM4A1.BackgroundSprite = "bb_unequip";
						panelVip1.BackgroundSprite = "bb_unequip";
						panelVip2.BackgroundSprite = "bb_unequip";
						panelVip3.BackgroundSprite = "bb_unequip";
						for (int i = 0; i < items.Length; i++) {
								if (i == 12 || i == 13 || i == 14) {
										if (RamboState.state_sung == 12 || RamboState.state_sung == 13 || RamboState.state_sung == 14)
												items [RamboState.state_sung].SetActive (true);
								} else {
										items [i].SetActive (false);
								}
						}
						if (RamboState.gun_buy [4] == 0) {
								lblUpdateKiss.Text = "2.500";
								labelName.Text = RamboState.kiss_lv1;

								DMG.Value = 0.2f;
								SPEED.Value = 0.6f;
								ACC.Value = 0.2f;
								CATRIDGE.Value = 0.2f;
								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 0;
								chiso4 = 0;

								for (int i = 0; i < items.Length; i++) {
										if (i == 12)
												items [i].SetActive (true);
										else
												items [i].SetActive (false);
								}
						} else if (RamboState.gun_buy [4] == 1) {
								spEquip [0].SetActive (false);
								spEquip [1].SetActive (false);
								spEquip [2].SetActive (false);
								spEquip [3].SetActive (false);
								spEquip [4].SetActive (true);
								spEquip [5].SetActive (false);
								spEquip [6].SetActive (false);
								spEquip [7].SetActive (false);
								spEquip [8].SetActive (false);
								spEquip [9].SetActive (false);
								spEquip [23].SetActive (false);
								spEquip [24].SetActive (false);
								spEquip [25].SetActive (false);
								DMG.Value = 0.2f;
								SPEED.Value = 0.6f;
								ACC.Value = 0.2f;
								CATRIDGE.Value = 0.2f;
								chiso1 = 0;
								chiso2 = 2;
								chiso3 = 0;
								chiso4 = 0;

								lblUpdateKiss.Text = "500";
								labelName.Text = RamboState.kiss_lv1;
								btnKiss.Text = "UPGRADE";
								items [12].SetActive (true);
								items [13].SetActive (false);
								items [14].SetActive (false);
								RamboState.state_sung = 12;
						} else if (RamboState.gun_buy [4] == 2) {
								spEquip [0].SetActive (false);
								spEquip [1].SetActive (false);
								spEquip [2].SetActive (false);
								spEquip [3].SetActive (false);
								spEquip [4].SetActive (true);
								spEquip [5].SetActive (false);
								spEquip [6].SetActive (false);
								spEquip [7].SetActive (false);
								spEquip [8].SetActive (false);
								spEquip [9].SetActive (false);
								spEquip [23].SetActive (false);
								spEquip [24].SetActive (false);
								spEquip [25].SetActive (false);
								DMG.Value = 0.2f;
								SPEED.Value = 0.8f;
								ACC.Value = 0.2f;
								CATRIDGE.Value = 0.2f;
								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 0;
								chiso4 = 2;

								lblUpdateKiss.Text = "500";
								labelName.Text = RamboState.kiss_lv2;
								iconKiss.BackgroundSprite = "ss2";
								kiss_lv.BackgroundSprite = "SMG_KISS_SUPER_2";
								btnKiss.Text = "UPGRADE";
								items [12].SetActive (false);
								items [13].SetActive (true);
								items [14].SetActive (false);
								RamboState.state_sung = 13;
						} else if (RamboState.gun_buy [4] == 3) {
								spEquip [0].SetActive (false);
								spEquip [1].SetActive (false);
								spEquip [2].SetActive (false);
								spEquip [3].SetActive (false);
								spEquip [4].SetActive (true);
								spEquip [5].SetActive (false);
								spEquip [6].SetActive (false);
								spEquip [7].SetActive (false);
								spEquip [8].SetActive (false);
								spEquip [9].SetActive (false);
								spEquip [23].SetActive (false);
								spEquip [24].SetActive (false);
								spEquip [25].SetActive (false);
								DMG.Value = 0.2f;
								SPEED.Value = 0.8f;
								ACC.Value = 0.2f;
								CATRIDGE.Value = 0.4f;
								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 0;
								chiso4 = 0;

								lblUpdateKiss.Text = "";
								labelName.Text = RamboState.kiss_lv3;
								iconKiss.BackgroundSprite = "ss3";
								kiss_lv.BackgroundSprite = "SMG_KISS_SUPPER_3";
								btnKiss.IsVisible = false;
								items [12].SetActive (false);
								items [13].SetActive (false);
								items [14].SetActive (true);
								RamboState.state_sung = 14;
						}
						#endregion
				} else if (control.name == "Panel 5") {
						#region View M4A1
						panelM3.BackgroundSprite = "bb_unequip";
						panelPistol.BackgroundSprite = "bb_unequip";
						panelMP5.BackgroundSprite = "bb_unequip";
						panelUZI.BackgroundSprite = "bb_unequip";
						panelKISS.BackgroundSprite = "bb_unequip";
						panelAWP.BackgroundSprite = "bb_unequip";
						panelSCAR.BackgroundSprite = "bb_unequip";
						panelWA.BackgroundSprite = "bb_unequip";
						panelBazooka.BackgroundSprite = "bb_unequip";
						panelM4A1.BackgroundSprite = "bb_equip";
						panelVip1.BackgroundSprite = "bb_unequip";
						panelVip2.BackgroundSprite = "bb_unequip";
						panelVip3.BackgroundSprite = "bb_unequip";
						for (int i = 0; i < items.Length; i++) {
								if (i == 15 || i == 16 || i == 17 || i == 18) {
										if (RamboState.state_sung == 15 || RamboState.state_sung == 16 || RamboState.state_sung == 17 || RamboState.state_sung == 18)
												items [RamboState.state_sung].SetActive (true);
								} else {
										items [i].SetActive (false);
								}
						}
						if (RamboState.gun_buy [5] == 0) {
								lblUpdateM4a1.Text = "5.000";
								labelName.Text = RamboState.m4a1_lv1;

								DMG.Value = 0.6f;
								SPEED.Value = 0.4f;
								ACC.Value = 0.2f;
								CATRIDGE.Value = 0.2f;
								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 0;
								chiso4 = 0;

								for (int i = 0; i < items.Length; i++) {
										if (i == 15)
												items [i].SetActive (true);
										else
												items [i].SetActive (false);
								}
						} else if (RamboState.gun_buy [5] == 1) {
								spEquip [0].SetActive (false);
								spEquip [1].SetActive (false);
								spEquip [2].SetActive (false);
								spEquip [3].SetActive (false);
								spEquip [4].SetActive (false);
								spEquip [5].SetActive (true);
								spEquip [6].SetActive (false);
								spEquip [7].SetActive (false);
								spEquip [8].SetActive (false);
								spEquip [9].SetActive (false);
								spEquip [23].SetActive (false);
								spEquip [24].SetActive (false);
								spEquip [25].SetActive (false);
								DMG.Value = 0.6f;
								SPEED.Value = 0.4f;
								ACC.Value = 0.2f;
								CATRIDGE.Value = 0.2f;
								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 2;
								chiso4 = 0;

								lblUpdateM4a1.Text = "500";
								labelName.Text = RamboState.m4a1_lv1;
								btnBuyM4A1.Text = "UPGRADE";
								items [15].SetActive (true);
								items [16].SetActive (false);
								items [17].SetActive (false);
								items [18].SetActive (false);
								RamboState.state_sung = 15;
						} else if (RamboState.gun_buy [5] == 2) {
								spEquip [0].SetActive (false);
								spEquip [1].SetActive (false);
								spEquip [2].SetActive (false);
								spEquip [3].SetActive (false);
								spEquip [4].SetActive (false);
								spEquip [5].SetActive (true);
								spEquip [6].SetActive (false);
								spEquip [7].SetActive (false);
								spEquip [8].SetActive (false);
								spEquip [9].SetActive (false);
								spEquip [23].SetActive (false);
								spEquip [24].SetActive (false);
								spEquip [25].SetActive (false);
								DMG.Value = 0.6f;
								SPEED.Value = 0.4f;
								ACC.Value = 0.4f;
								CATRIDGE.Value = 0.2f;
								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 0;
								chiso4 = 2;

								lblUpdateM4a1.Text = "1.000";
								labelName.Text = RamboState.m4a1_lv2;
								iconM4A1.BackgroundSprite = "ss2";
								m4a1_lv.BackgroundSprite = "Rifle_M4A1_2";
								btnBuyM4A1.Text = "UPGRADE";
								items [15].SetActive (false);
								items [16].SetActive (true);
								items [17].SetActive (false);
								items [18].SetActive (false);
								RamboState.state_sung = 16;
						} else if (RamboState.gun_buy [5] == 3) {
								spEquip [0].SetActive (false);
								spEquip [1].SetActive (false);
								spEquip [2].SetActive (false);
								spEquip [3].SetActive (false);
								spEquip [4].SetActive (false);
								spEquip [5].SetActive (true);
								spEquip [6].SetActive (false);
								spEquip [7].SetActive (false);
								spEquip [8].SetActive (false);
								spEquip [9].SetActive (false);
								spEquip [23].SetActive (false);
								spEquip [24].SetActive (false);
								spEquip [25].SetActive (false);
								DMG.Value = 0.6f;
								SPEED.Value = 0.4f;
								ACC.Value = 0.4f;
								CATRIDGE.Value = 0.4f;
								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 0;
								chiso4 = 2;

								lblUpdateM4a1.Text = "1.500";
								labelName.Text = RamboState.m4a1_lv3;
								iconM4A1.BackgroundSprite = "ss3";
								m4a1_lv.BackgroundSprite = "Rifle_M4A1_3";
								btnBuyM4A1.Text = "UPGRADE";
								items [15].SetActive (false);
								items [16].SetActive (false);
								items [17].SetActive (true);
								items [18].SetActive (false);
								RamboState.state_sung = 17;
						} else if (RamboState.gun_buy [5] == 4) {
								spEquip [0].SetActive (false);
								spEquip [1].SetActive (false);
								spEquip [2].SetActive (false);
								spEquip [3].SetActive (false);
								spEquip [4].SetActive (false);
								spEquip [5].SetActive (true);
								spEquip [6].SetActive (false);
								spEquip [7].SetActive (false);
								spEquip [8].SetActive (false);
								spEquip [9].SetActive (false);
								spEquip [23].SetActive (false);
								spEquip [24].SetActive (false);
								spEquip [25].SetActive (false);
								DMG.Value = 0.6f;
								SPEED.Value = 0.4f;
								ACC.Value = 0.4f;
								CATRIDGE.Value = 0.6f;
								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 0;
								chiso4 = 0;

								lblUpdateM4a1.Text = "";
								labelName.Text = RamboState.m4a1_lv4;
								iconM4A1.BackgroundSprite = "ss4";
								m4a1_lv.BackgroundSprite = "Rifle_M4A1_4";
								btnBuyM4A1.IsVisible = false;
								items [15].SetActive (false);
								items [16].SetActive (false);
								items [17].SetActive (false);
								items [18].SetActive (true);
								RamboState.state_sung = 18;
						}
						#endregion
				} else if (control.name == "Panel 6") {
						#region View SCAR
						panelM3.BackgroundSprite = "bb_unequip";
						panelPistol.BackgroundSprite = "bb_unequip";
						panelMP5.BackgroundSprite = "bb_unequip";
						panelUZI.BackgroundSprite = "bb_unequip";
						panelKISS.BackgroundSprite = "bb_unequip";
						panelAWP.BackgroundSprite = "bb_unequip";
						panelSCAR.BackgroundSprite = "bb_equip";
						panelWA.BackgroundSprite = "bb_unequip";
						panelBazooka.BackgroundSprite = "bb_unequip";
						panelM4A1.BackgroundSprite = "bb_unequip";
						panelVip1.BackgroundSprite = "bb_unequip";
						panelVip2.BackgroundSprite = "bb_unequip";
						panelVip3.BackgroundSprite = "bb_unequip";
						for (int i = 0; i < items.Length; i++) {
								if (i == 19 || i == 20 || i == 21 || i == 22) {
										if (RamboState.state_sung == 19 || RamboState.state_sung == 20 || RamboState.state_sung == 21 || RamboState.state_sung == 22)
												items [RamboState.state_sung].SetActive (true);
								} else {
										items [i].SetActive (false);
								}
						}
						if (RamboState.gun_buy [6] == 0) {
								lblUpdateScar.Text = "7.500";
								labelName.Text = RamboState.scar_lv1;

								DMG.Value = 0.6f;
								SPEED.Value = 0.6f;
								ACC.Value = 0.2f;
								CATRIDGE.Value = 0.2f;

								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 0;
								chiso4 = 0;
								for (int i = 0; i < items.Length; i++) {
										if (i == 19)
												items [i].SetActive (true);
										else
												items [i].SetActive (false);
								}
						} else if (RamboState.gun_buy [6] == 1) {
								spEquip [0].SetActive (false);
								spEquip [1].SetActive (false);
								spEquip [2].SetActive (false);
								spEquip [3].SetActive (false);
								spEquip [4].SetActive (false);
								spEquip [5].SetActive (false);
								spEquip [6].SetActive (true);
								spEquip [7].SetActive (false);
								spEquip [8].SetActive (false);
								spEquip [9].SetActive (false);
								spEquip [23].SetActive (false);
								spEquip [24].SetActive (false);
								spEquip [25].SetActive (false);
								DMG.Value = 0.6f;
								SPEED.Value = 0.6f;
								ACC.Value = 0.2f;
								CATRIDGE.Value = 0.2f;
								chiso1 = 0;
								chiso2 = 2;
								chiso3 = 0;
								chiso4 = 0;

								lblUpdateScar.Text = "1.000";
								labelName.Text = RamboState.scar_lv1;
								btnBuyScar.Text = "UPGRADE";
								items [19].SetActive (true);
								items [20].SetActive (false);
								items [21].SetActive (false);
								items [22].SetActive (false);
								RamboState.state_sung = 19;
						} else if (RamboState.gun_buy [6] == 2) {
								spEquip [0].SetActive (false);
								spEquip [1].SetActive (false);
								spEquip [2].SetActive (false);
								spEquip [3].SetActive (false);
								spEquip [4].SetActive (false);
								spEquip [5].SetActive (false);
								spEquip [6].SetActive (true);
								spEquip [7].SetActive (false);
								spEquip [8].SetActive (false);
								spEquip [9].SetActive (false);

								DMG.Value = 0.6f;
								SPEED.Value = 0.8f;
								ACC.Value = 0.2f;
								CATRIDGE.Value = 0.2f;

								lblUpdateScar.Text = "2.000";
								labelName.Text = RamboState.scar_lv2;
								iconScar.BackgroundSprite = "ss2";
								scar_lv.BackgroundSprite = "Rifle_Scar_2";
								btnBuyScar.Text = "UPGRADE";
								items [19].SetActive (false);
								items [20].SetActive (true);
								items [21].SetActive (false);
								items [22].SetActive (false);
								RamboState.state_sung = 20;
						} else if (RamboState.gun_buy [6] == 3) {
								spEquip [0].SetActive (false);
								spEquip [1].SetActive (false);
								spEquip [2].SetActive (false);
								spEquip [3].SetActive (false);
								spEquip [4].SetActive (false);
								spEquip [5].SetActive (false);
								spEquip [6].SetActive (true);
								spEquip [7].SetActive (false);
								spEquip [8].SetActive (false);
								spEquip [9].SetActive (false);
								spEquip [23].SetActive (false);
								spEquip [24].SetActive (false);
								spEquip [25].SetActive (false);
								DMG.Value = 0.6f;
								SPEED.Value = 0.8f;
								ACC.Value = 0.4f;
								CATRIDGE.Value = 0.2f;
								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 2;
								chiso4 = 0;

								lblUpdateScar.Text = "3.000";
								labelName.Text = RamboState.scar_lv3;
								iconScar.BackgroundSprite = "ss3";
								scar_lv.BackgroundSprite = "Rifle_Scar_3";
								btnBuyScar.Text = "UPGRADE";
								items [19].SetActive (false);
								items [20].SetActive (false);
								items [21].SetActive (true);
								items [22].SetActive (false);
								RamboState.state_sung = 21;
						} else if (RamboState.gun_buy [6] == 4) {
								spEquip [0].SetActive (false);
								spEquip [1].SetActive (false);
								spEquip [2].SetActive (false);
								spEquip [3].SetActive (false);
								spEquip [4].SetActive (false);
								spEquip [5].SetActive (false);
								spEquip [6].SetActive (true);
								spEquip [7].SetActive (false);
								spEquip [8].SetActive (false);
								spEquip [9].SetActive (false);
								spEquip [23].SetActive (false);
								spEquip [24].SetActive (false);
								spEquip [25].SetActive (false);
								DMG.Value = 0.6f;
								SPEED.Value = 0.8f;
								ACC.Value = 0.6f;
								CATRIDGE.Value = 0.2f;
								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 0;
								chiso4 = 0;

								lblUpdateScar.Text = "";
								labelName.Text = RamboState.scar_lv4;
								iconScar.BackgroundSprite = "ss4";
								scar_lv.BackgroundSprite = "Rifle_Scar_4";
								btnBuyScar.IsVisible = false;
								items [19].SetActive (false);
								items [20].SetActive (false);
								items [21].SetActive (false);
								items [22].SetActive (true);
								RamboState.state_sung = 22;
						}
						#endregion
				} else if (control.name == "Panel 7") {
						#region View AWP
						panelM3.BackgroundSprite = "bb_unequip";
						panelPistol.BackgroundSprite = "bb_unequip";
						panelMP5.BackgroundSprite = "bb_unequip";
						panelUZI.BackgroundSprite = "bb_unequip";
						panelKISS.BackgroundSprite = "bb_unequip";
						panelAWP.BackgroundSprite = "bb_equip";
						panelSCAR.BackgroundSprite = "bb_unequip";
						panelWA.BackgroundSprite = "bb_unequip";
						panelBazooka.BackgroundSprite = "bb_unequip";
						panelM4A1.BackgroundSprite = "bb_unequip";
						panelVip1.BackgroundSprite = "bb_unequip";
						panelVip2.BackgroundSprite = "bb_unequip";
						panelVip3.BackgroundSprite = "bb_unequip";
						for (int i = 0; i < items.Length; i++) {
								if (i == 23 || i == 24 || i == 25) {
										if (RamboState.state_sung == 23 || RamboState.state_sung == 24 || RamboState.state_sung == 25)
												items [RamboState.state_sung].SetActive (true);
								} else {
										items [i].SetActive (false);
								}
						}
						if (RamboState.gun_buy [7] == 0) {
								lblUpdateAwp.Text = "25.000";
								labelName.Text = RamboState.awp_lv1;

								DMG.Value = 1f;
								SPEED.Value = 0.2f;
								ACC.Value = 0.6f;
								CATRIDGE.Value = 0.2f;
								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 0;
								chiso4 = 0;
								for (int i = 0; i < items.Length; i++) {
										if (i == 23)
												items [i].SetActive (true);
										else
												items [i].SetActive (false);
								}
						} else if (RamboState.gun_buy [7] == 1) {
								spEquip [0].SetActive (false);
								spEquip [1].SetActive (false);
								spEquip [2].SetActive (false);
								spEquip [3].SetActive (false);
								spEquip [4].SetActive (false);
								spEquip [5].SetActive (false);
								spEquip [6].SetActive (false);
								spEquip [7].SetActive (true);
								spEquip [8].SetActive (false);
								spEquip [9].SetActive (false);
								spEquip [23].SetActive (false);
								spEquip [24].SetActive (false);
								spEquip [25].SetActive (false);
								DMG.Value = 1f;
								SPEED.Value = 0.2f;
								ACC.Value = 0.6f;
								CATRIDGE.Value = 0.2f;
								chiso1 = 0;
								chiso2 = 2;
								chiso3 = 0;
								chiso4 = 0;
								lblUpdateAwp.Text = "5.000";
								labelName.Text = RamboState.awp_lv1;
								btnBuyAWP.Text = "UPGRADE";
								items [23].SetActive (true);
								items [24].SetActive (false);
								items [25].SetActive (false);
								RamboState.state_sung = 23;
						} else if (RamboState.gun_buy [7] == 2) {
								spEquip [0].SetActive (false);
								spEquip [1].SetActive (false);
								spEquip [2].SetActive (false);
								spEquip [3].SetActive (false);
								spEquip [4].SetActive (false);
								spEquip [5].SetActive (false);
								spEquip [6].SetActive (false);
								spEquip [7].SetActive (true);
								spEquip [8].SetActive (false);
								spEquip [9].SetActive (false);
								spEquip [23].SetActive (false);
								spEquip [24].SetActive (false);
								spEquip [25].SetActive (false);
								DMG.Value = 1f;
								SPEED.Value = 0.4f;
								ACC.Value = 0.6f;
								CATRIDGE.Value = 0.2f;
								chiso1 = 0;
								chiso2 = 2;
								chiso3 = 0;
								chiso4 = 2;
								lblUpdateAwp.Text = "5.000";
								labelName.Text = RamboState.awp_lv2;
								iconAWP.BackgroundSprite = "ss2";
								awp_lv.BackgroundSprite = "SMG_AWP2";
								btnBuyAWP.Text = "UPGRADE";
								items [23].SetActive (false);
								items [24].SetActive (true);
								items [25].SetActive (false);
								RamboState.state_sung = 24;
						} else if (RamboState.gun_buy [7] == 3) {
								spEquip [0].SetActive (false);
								spEquip [1].SetActive (false);
								spEquip [2].SetActive (false);
								spEquip [3].SetActive (false);
								spEquip [4].SetActive (false);
								spEquip [5].SetActive (false);
								spEquip [6].SetActive (false);
								spEquip [7].SetActive (true);
								spEquip [8].SetActive (false);
								spEquip [9].SetActive (false);
								spEquip [23].SetActive (false);
								spEquip [24].SetActive (false);
								spEquip [25].SetActive (false);
								DMG.Value = 1f;
								SPEED.Value = 0.4f;
								ACC.Value = 0.6f;
								CATRIDGE.Value = 0.4f;
								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 0;
								chiso4 = 0;

								lblUpdateAwp.Text = "";
								labelName.Text = RamboState.awp_lv3;
								iconAWP.BackgroundSprite = "ss3";
								awp_lv.BackgroundSprite = "SMG_AWP3";
								btnBuyAWP.IsVisible = false;
								items [23].SetActive (false);
								items [24].SetActive (false);
								items [25].SetActive (true);
								RamboState.state_sung = 25;
						}
						#endregion
				} else if (control.name == "Panel 8") {
						#region View WA2000
						panelM3.BackgroundSprite = "bb_unequip";
						panelPistol.BackgroundSprite = "bb_unequip";
						panelMP5.BackgroundSprite = "bb_unequip";
						panelUZI.BackgroundSprite = "bb_unequip";
						panelKISS.BackgroundSprite = "bb_unequip";
						panelAWP.BackgroundSprite = "bb_unequip";
						panelSCAR.BackgroundSprite = "bb_unequip";
						panelWA.BackgroundSprite = "bb_equip";
						panelBazooka.BackgroundSprite = "bb_unequip";
						panelM4A1.BackgroundSprite = "bb_unequip";
						panelVip1.BackgroundSprite = "bb_unequip";
						panelVip2.BackgroundSprite = "bb_unequip";
						panelVip3.BackgroundSprite = "bb_unequip";
						for (int i = 0; i < items.Length; i++) {
								if (i == 26 || i == 27 || i == 28) {
										if (RamboState.state_sung == 26 || RamboState.state_sung == 27 || RamboState.state_sung == 28)
												items [RamboState.state_sung].SetActive (true);
								} else {
										items [i].SetActive (false);
								}
						}
						if (RamboState.gun_buy [8] == 0) {
								lblUpdateWa.Text = "45.000";
								labelName.Text = RamboState.wa_lv1;

								DMG.Value = 0.8f;
								SPEED.Value = 0.2f;
								ACC.Value = 0.6f;
								CATRIDGE.Value = 0.2f;
								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 0;
								chiso4 = 0;
								for (int i = 0; i < items.Length; i++) {
										if (i == 26)
												items [i].SetActive (true);
										else
												items [i].SetActive (false);
								}
						} else if (RamboState.gun_buy [8] == 1) {
								spEquip [0].SetActive (false);
								spEquip [1].SetActive (false);
								spEquip [2].SetActive (false);
								spEquip [3].SetActive (false);
								spEquip [4].SetActive (false);
								spEquip [5].SetActive (false);
								spEquip [6].SetActive (false);
								spEquip [7].SetActive (false);
								spEquip [8].SetActive (true);
								spEquip [9].SetActive (false);
								spEquip [23].SetActive (false);
								spEquip [24].SetActive (false);
								spEquip [25].SetActive (false);
								DMG.Value = 0.8f;
								SPEED.Value = 0.2f;
								ACC.Value = 0.6f;
								CATRIDGE.Value = 0.2f;
								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 0;
								chiso4 = 4;
								lblUpdateWa.Text = "5.000";
								labelName.Text = RamboState.wa_lv1;
								btnWa.Text = "UPGRADE";
								items [26].SetActive (true);
								items [27].SetActive (false);
								items [28].SetActive (false);
								RamboState.state_sung = 26;
						} else if (RamboState.gun_buy [8] == 2) {
								lblUpdateWa.Text = "5.000";
								labelName.Text = RamboState.wa_lv2;
								iconWA.BackgroundSprite = "ss2";
								wa_lv.BackgroundSprite = "SNIPER_WA2000_2";
								btnWa.Text = "UPGRADE";
								items [26].SetActive (false);
								items [27].SetActive (true);
								items [28].SetActive (false);
								RamboState.state_sung = 27;

								DMG.Value = 0.8f;
								SPEED.Value = 0.2f;
								ACC.Value = 0.6f;
								CATRIDGE.Value = 0.6f;
								chiso1 = 2;
								chiso2 = 0;
								chiso3 = 2;
								chiso4 = 0;
						} else if (RamboState.gun_buy [8] == 3) {
								lblUpdateWa.Text = "";
								labelName.Text = RamboState.wa_lv3;
								iconWA.BackgroundSprite = "ss3";
								wa_lv.BackgroundSprite = "SNIPER_WA2000_3";
								btnWa.IsVisible = false;
								items [26].SetActive (false);
								items [27].SetActive (false);
								items [28].SetActive (true);
								RamboState.state_sung = 28;

								DMG.Value = 1f;
								SPEED.Value = 0.2f;
								ACC.Value = 0.8f;
								CATRIDGE.Value = 0.6f;
								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 0;
								chiso4 = 0;
						}
						#endregion
				} else if (control.name == "Panel 9") {
						#region View Bazooka
						panelM3.BackgroundSprite = "bb_unequip";
						panelPistol.BackgroundSprite = "bb_unequip";
						panelMP5.BackgroundSprite = "bb_unequip";
						panelUZI.BackgroundSprite = "bb_unequip";
						panelKISS.BackgroundSprite = "bb_unequip";
						panelAWP.BackgroundSprite = "bb_unequip";
						panelSCAR.BackgroundSprite = "bb_unequip";
						panelWA.BackgroundSprite = "bb_unequip";
						panelBazooka.BackgroundSprite = "bb_equip";
						panelM4A1.BackgroundSprite = "bb_unequip";
						panelVip1.BackgroundSprite = "bb_unequip";
						panelVip2.BackgroundSprite = "bb_unequip";
						panelVip3.BackgroundSprite = "bb_unequip";
			labelName.Text = "BAZOOKA";
						for (int i = 0; i < items.Length; i++) {
								if (i == 29) {
										if (RamboState.state_sung == 29)
												items [RamboState.state_sung].SetActive (false);
								} else {
										items [i].SetActive (false);
								}
						}
						if (RamboState.gun_buy [9] == 0) {
								lblUpdateM3.Text = "50.000";
								labelName.Text = "BAZOOKA";

								DMG.Value = 1f;
								SPEED.Value = 0.2f;
								ACC.Value = 1f;
								CATRIDGE.Value = 0.2f;
								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 0;
								chiso4 = 0;
								for (int i = 0; i < items.Length; i++) {
										if (i == 29)
												items [i].SetActive (true);
										else
												items [i].SetActive (false);
								}
						} else if (RamboState.gun_buy [9] == 1) {
				labelName.Text = "BAZOOKA";
								spEquip [0].SetActive (false);
								spEquip [1].SetActive (false);
								spEquip [2].SetActive (false);
								spEquip [3].SetActive (false);
								spEquip [4].SetActive (false);
								spEquip [5].SetActive (false);
								spEquip [6].SetActive (false);
								spEquip [7].SetActive (false);
								spEquip [8].SetActive (false);
								spEquip [9].SetActive (true);
								spEquip [23].SetActive (false);
								spEquip [24].SetActive (false);
								spEquip [25].SetActive (false);
								lblUpdateM3.Text = "";
								btnBuyBazooka.IsVisible = false;
								iconBazooka.BackgroundSprite = "ss4";
								items [29].SetActive (true);
								RamboState.state_sung = 29;

								DMG.Value = 1f;
								SPEED.Value = 0.2f;
								ACC.Value = 1f;
								CATRIDGE.Value = 0.2f;
								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 0;
								chiso4 = 0;
						}
						#endregion
				} else if (control.name == "Panel 10") {
						#region View Vip1
						panelM3.BackgroundSprite = "bb_unequip";
						panelPistol.BackgroundSprite = "bb_unequip";
						panelMP5.BackgroundSprite = "bb_unequip";
						panelUZI.BackgroundSprite = "bb_unequip";
						panelKISS.BackgroundSprite = "bb_unequip";
						panelAWP.BackgroundSprite = "bb_unequip";
						panelSCAR.BackgroundSprite = "bb_unequip";
						panelWA.BackgroundSprite = "bb_unequip";
						panelBazooka.BackgroundSprite = "bb_unequip";
						panelM4A1.BackgroundSprite = "bb_unequip";
						panelVip1.BackgroundSprite = "bb_equip";
						panelVip2.BackgroundSprite = "bb_unequip";
						panelVip3.BackgroundSprite = "bb_unequip";
			labelName.Text = "Heads snake";
						for (int i = 0; i < items.Length; i++) {
								if (i == 30) {
										if (RamboState.state_sung == 30)
												items [RamboState.state_sung].SetActive (false);
								} else {
										items [i].SetActive (false);
								}
						}
						if (RamboState.gun_buy [10] == 0) {
								lblUpdateM3.Text = "50.000";
								labelName.Text = "Heads snake";
				
								DMG.Value = 1f;
								SPEED.Value = 0.4f;
								ACC.Value = 1f;
								CATRIDGE.Value = 0.4f;
								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 0;
								chiso4 = 0;
								for (int i = 0; i < items.Length; i++) {
										if (i == 30)
												items [i].SetActive (true);
										else
												items [i].SetActive (false);
								}
						} else if (RamboState.gun_buy [10] == 1) {
				labelName.Text = "Heads snake";
								spEquip [0].SetActive (false);
								spEquip [1].SetActive (false);
								spEquip [2].SetActive (false);
								spEquip [3].SetActive (false);
								spEquip [4].SetActive (false);
								spEquip [5].SetActive (false);
								spEquip [6].SetActive (false);
								spEquip [7].SetActive (false);
								spEquip [8].SetActive (false);
								spEquip [9].SetActive (false);
								spEquip [23].SetActive (true);
								spEquip [24].SetActive (false);
								spEquip [25].SetActive (false);
								lblUpdateM3.Text = "";
								btnBuyVip1.IsVisible = false;
								iconvip1.BackgroundSprite = "ss4";
								items [30].SetActive (true);
								RamboState.state_sung = 30;
				
								DMG.Value = 1f;
								SPEED.Value = 0.4f;
								ACC.Value = 1f;
								CATRIDGE.Value = 0.4f;
								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 0;
								chiso4 = 0;
						}
						#endregion
				} else if (control.name == "Panel 11") {
						#region View Vip2
						panelM3.BackgroundSprite = "bb_unequip";
						panelPistol.BackgroundSprite = "bb_unequip";
						panelMP5.BackgroundSprite = "bb_unequip";
						panelUZI.BackgroundSprite = "bb_unequip";
						panelKISS.BackgroundSprite = "bb_unequip";
						panelAWP.BackgroundSprite = "bb_unequip";
						panelSCAR.BackgroundSprite = "bb_unequip";
						panelWA.BackgroundSprite = "bb_unequip";
						panelBazooka.BackgroundSprite = "bb_unequip";
						panelM4A1.BackgroundSprite = "bb_unequip";
						panelVip1.BackgroundSprite = "bb_unequip";
						panelVip2.BackgroundSprite = "bb_equip";
			panelVip3.BackgroundSprite = "bb_unequip";		labelName.Text = "Linear gun";
						for (int i = 0; i < items.Length; i++) {
								if (i == 31) {
										if (RamboState.state_sung == 31)
												items [RamboState.state_sung].SetActive (false);
								} else {
										items [i].SetActive (false);
								}
						}
						if (RamboState.gun_buy [11] == 0) {
								lblUpdateM3.Text = "50.000";
								labelName.Text = "Linear gun";
				
								DMG.Value = 1f;
								SPEED.Value = 0.6f;
								ACC.Value = 1f;
								CATRIDGE.Value = 0.6f;
								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 0;
								chiso4 = 0;
								for (int i = 0; i < items.Length; i++) {
										if (i == 31)
												items [i].SetActive (true);
										else
												items [i].SetActive (false);
								}
						} else if (RamboState.gun_buy [11] == 1) {
								spEquip [0].SetActive (false);
								spEquip [1].SetActive (false);
								spEquip [2].SetActive (false);
								spEquip [3].SetActive (false);
								spEquip [4].SetActive (false);
								spEquip [5].SetActive (false);
								spEquip [6].SetActive (false);
								spEquip [7].SetActive (false);
								spEquip [8].SetActive (false);
								spEquip [9].SetActive (false);
								spEquip [23].SetActive (false);
								spEquip [24].SetActive (true);
				spEquip [25].SetActive (false);		labelName.Text = "Linear gun";
								lblUpdateM3.Text = "";
								btnBuyVip2.IsVisible = false;
								iconvip2.BackgroundSprite = "ss4";
								items [31].SetActive (true);
								RamboState.state_sung = 31;
				
								DMG.Value = 1f;
								SPEED.Value = 0.6f;
								ACC.Value = 1f;
								CATRIDGE.Value = 0.6f;
								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 0;
								chiso4 = 0;
						}
						#endregion
				} else if (control.name == "Panel 12") {
						#region View Vip2
						panelM3.BackgroundSprite = "bb_unequip";
						panelPistol.BackgroundSprite = "bb_unequip";
						panelMP5.BackgroundSprite = "bb_unequip";
						panelUZI.BackgroundSprite = "bb_unequip";
						panelKISS.BackgroundSprite = "bb_unequip";
						panelAWP.BackgroundSprite = "bb_unequip";
						panelSCAR.BackgroundSprite = "bb_unequip";
						panelWA.BackgroundSprite = "bb_unequip";
						panelBazooka.BackgroundSprite = "bb_unequip";
						panelM4A1.BackgroundSprite = "bb_unequip";
						panelVip1.BackgroundSprite = "bb_unequip";
						panelVip2.BackgroundSprite = "bb_unequip";
			panelVip3.BackgroundSprite = "bb_equip";	labelName.Text = "Trio missiles";
						for (int i = 0; i < items.Length; i++) {
								if (i == 32) {
										if (RamboState.state_sung == 32)
												items [RamboState.state_sung].SetActive (false);
								} else {
										items [i].SetActive (false);
								}
						}
						if (RamboState.gun_buy [12] == 0) {
								lblUpdateM3.Text = "50.000";
				labelName.Text = "Trio missiles";
				
								DMG.Value = 1f;
								SPEED.Value = 0.8f;
								ACC.Value = 1f;
								CATRIDGE.Value = 0.8f;
								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 0;
								chiso4 = 0;
								for (int i = 0; i < items.Length; i++) {
										if (i == 32)
												items [i].SetActive (true);
										else
												items [i].SetActive (false);
								}
						} else if (RamboState.gun_buy [12] == 1) {
								spEquip [0].SetActive (false);
								spEquip [1].SetActive (false);
								spEquip [2].SetActive (false);
								spEquip [3].SetActive (false);
								spEquip [4].SetActive (false);
								spEquip [5].SetActive (false);
								spEquip [6].SetActive (false);
				spEquip [7].SetActive (false);	labelName.Text = "Trio missiles";
								spEquip [8].SetActive (false);
								spEquip [9].SetActive (false);
								spEquip [23].SetActive (false);
								spEquip [24].SetActive (false);
								spEquip [25].SetActive (true);
								lblUpdateM3.Text = "";
								btnBuyVip3.IsVisible = false;
								iconvip3.BackgroundSprite = "ss4";
								items [32].SetActive (true);
								RamboState.state_sung = 32;
				
								DMG.Value = 1f;
								SPEED.Value = 0.8f;
								ACC.Value = 1f;
								CATRIDGE.Value = 0.8f;
								chiso1 = 0;
								chiso2 = 0;
								chiso3 = 0;
								chiso4 = 0;
						}
						#endregion
				}


		}
    #endregion

    #region View Weapon
		public void WeaponButtonClick ()
		{          //nut chon sung
				lblNumberBulletOfPistol.Text = RamboState.total_bullet_sungluc.ToString ();
				lblNumberBulletOfM3.Text = RamboState.total_bullet_sungshotgun.ToString ();
				lblNumberBulletOfM4A1.Text = RamboState.total_bullet_sungtia.ToString ();
				lblNumberBulletOfMP5.Text = RamboState.total_bullet_sungtia.ToString ();
				lblNumberBulletOfSCAR.Text = RamboState.total_bullet_sungtia.ToString ();
				lblNumberBulletOfUZI.Text = RamboState.total_bullet_sungtia.ToString ();
				lblNumberBulletOfWA.Text = RamboState.total_bullet_sungtia.ToString ();
				lblNumberBulletOfKISS.Text = RamboState.total_bullet_sungtia.ToString ();
				lblNumberBulletOfAWP.Text = RamboState.total_bullet_sungngam.ToString ();
				lblNumberBulletOfBAZOOKA.Text = RamboState.total_bullet_sung_tenlua.ToString ();
				lblNumberBulletOfVip1.Text = RamboState.total_bullet_sungtia.ToString ();
				lblNumberBulletOfVip2.Text = RamboState.total_bullet_sungtia.ToString ();
				lblNumberBulletOfVip3.Text = RamboState.total_bullet_sung_tenlua.ToString ();


				GameObject.Find ("Click").GetComponent<SoundClick> ().play ();
				items [RamboState.state_sung].SetActive (true);
				LoadInfo.SaveShop ();
				#region Load Gun Info
				if (RamboState.state_sung == 0) {
						DMG.Value = 0.2f;
						SPEED.Value = 0.2f;
						ACC.Value = 0.2f;
						CATRIDGE.Value = 0.2f;
						labelName.Text = RamboState.pistol_lv1;
				} else if (RamboState.state_sung == 1) {
						DMG.Value = 0.4f;
						SPEED.Value = 0.4f;
						ACC.Value = 0.2f;
						CATRIDGE.Value = 0.2f;
						labelName.Text = RamboState.pistol_lv2;
				} else if (RamboState.state_sung == 2) {
						DMG.Value = 0.4f;
						SPEED.Value = 0.4f;
						ACC.Value = 0.2f;
						CATRIDGE.Value = 0.4f;
						labelName.Text = RamboState.pistol_lv3;
				} else if (RamboState.state_sung == 3) {
						DMG.Value = 0.6f;
						SPEED.Value = 0.2f;
						ACC.Value = 0.2f;
						CATRIDGE.Value = 0.2f;
						labelName.Text = RamboState.m3_lv1;
				} else if (RamboState.state_sung == 4) {
						DMG.Value = 0.6f;
						SPEED.Value = 0.4f;
						ACC.Value = 0.2f;
						CATRIDGE.Value = 0.2f;
						labelName.Text = RamboState.m3_lv2;
				} else if (RamboState.state_sung == 5) {
						DMG.Value = 0.8f;
						SPEED.Value = 0.4f;
						ACC.Value = 0.2f;
						CATRIDGE.Value = 0.6f;
						labelName.Text = RamboState.m3_lv3;
				} else if (RamboState.state_sung == 6) {
						DMG.Value = 0.8f;
						SPEED.Value = 0.6f;
						ACC.Value = 0.2f;
						CATRIDGE.Value = 0.6f;
						labelName.Text = RamboState.m3_lv4;
				} else if (RamboState.state_sung == 7) {
						DMG.Value = 0.2f;
						SPEED.Value = 0.2f;
						ACC.Value = 0.6f;
						CATRIDGE.Value = 0.2f;
						labelName.Text = RamboState.mp5_lv1;
				} else if (RamboState.state_sung == 8) {
						DMG.Value = 0.2f;
						SPEED.Value = 0.2f;
						ACC.Value = 1;
						CATRIDGE.Value = 0.2f;
						labelName.Text = RamboState.mp5_lv2;
				} else if (RamboState.state_sung == 9) {
						DMG.Value = 0.2f;
						SPEED.Value = 0.2f;
						ACC.Value = 0.4f;
						CATRIDGE.Value = 0.4f;
						labelName.Text = RamboState.uzi_lv1;
				} else if (RamboState.state_sung == 10) {
						DMG.Value = 0.2f;
						SPEED.Value = 0.2f;
						ACC.Value = 0.6f;
						CATRIDGE.Value = 0.6f;
						labelName.Text = RamboState.uzi_lv2;
				} else if (RamboState.state_sung == 11) {
						DMG.Value = 0.6f;
						SPEED.Value = 0.2f;
						ACC.Value = 0.6f;
						CATRIDGE.Value = 0.6f;
						labelName.Text = RamboState.uzi_lv3;
				} else if (RamboState.state_sung == 12) {
						DMG.Value = 0.2f;
						SPEED.Value = 0.6f;
						ACC.Value = 0.2f;
						CATRIDGE.Value = 0.2f;
						labelName.Text = RamboState.kiss_lv1;
				} else if (RamboState.state_sung == 13) {
						DMG.Value = 0.2f;
						SPEED.Value = 0.8f;
						ACC.Value = 0.2f;
						CATRIDGE.Value = 0.2f;
						labelName.Text = RamboState.kiss_lv2;
				} else if (RamboState.state_sung == 14) {
						DMG.Value = 0.2f;
						SPEED.Value = 0.8f;
						ACC.Value = 0.2f;
						CATRIDGE.Value = 0.4f;
						labelName.Text = RamboState.kiss_lv3;
				} else if (RamboState.state_sung == 15) {
						DMG.Value = 0.6f;
						SPEED.Value = 0.4f;
						ACC.Value = 0.2f;
						CATRIDGE.Value = 0.2f;
						labelName.Text = RamboState.m4a1_lv1;
				} else if (RamboState.state_sung == 16) {
						DMG.Value = 0.6f;
						SPEED.Value = 0.4f;
						ACC.Value = 0.4f;
						CATRIDGE.Value = 0.2f;
						labelName.Text = RamboState.m4a1_lv2;
				} else if (RamboState.state_sung == 17) {
						DMG.Value = 0.6f;
						SPEED.Value = 0.4f;
						ACC.Value = 0.4f;
						CATRIDGE.Value = 0.4f;
						labelName.Text = RamboState.m4a1_lv3;
				} else if (RamboState.state_sung == 18) {
						DMG.Value = 0.6f;
						SPEED.Value = 0.4f;
						ACC.Value = 0.4f;
						CATRIDGE.Value = 0.6f;
						labelName.Text = RamboState.m4a1_lv4;
				} else if (RamboState.state_sung == 19) {
						DMG.Value = 0.6f;
						SPEED.Value = 0.6f;
						ACC.Value = 0.2f;
						CATRIDGE.Value = 0.2f;
						labelName.Text = RamboState.scar_lv1;
				} else if (RamboState.state_sung == 20) {
						DMG.Value = 0.6f;
						SPEED.Value = 0.8f;
						ACC.Value = 0.2f;
						CATRIDGE.Value = 0.2f;
						labelName.Text = RamboState.scar_lv2;
				} else if (RamboState.state_sung == 21) {
						DMG.Value = 0.6f;
						SPEED.Value = 0.8f;
						ACC.Value = 0.4f;
						CATRIDGE.Value = 0.2f;
						labelName.Text = RamboState.scar_lv3;
				} else if (RamboState.state_sung == 22) {
						DMG.Value = 0.6f;
						SPEED.Value = 0.8f;
						ACC.Value = 0.6f;
						CATRIDGE.Value = 0.2f;
						labelName.Text = RamboState.scar_lv4;
				} else if (RamboState.state_sung == 23) {
						DMG.Value = 1f;
						SPEED.Value = 0.2f;
						ACC.Value = 0.6f;
						CATRIDGE.Value = 0.2f;
						labelName.Text = RamboState.awp_lv1;
				} else if (RamboState.state_sung == 24) {
						DMG.Value = 1f;
						SPEED.Value = 0.4f;
						ACC.Value = 0.6f;
						CATRIDGE.Value = 0.2f;
						labelName.Text = RamboState.awp_lv2;
				} else if (RamboState.state_sung == 25) {
						DMG.Value = 1f;
						SPEED.Value = 0.4f;
						ACC.Value = 0.6f;
						CATRIDGE.Value = 0.4f;
						labelName.Text = RamboState.awp_lv3;
				} else if (RamboState.state_sung == 26) {
						DMG.Value = 0.8f;
						SPEED.Value = 0.2f;
						ACC.Value = 0.6f;
						CATRIDGE.Value = 0.2f;
						labelName.Text = RamboState.wa_lv1;
				} else if (RamboState.state_sung == 27) {
						DMG.Value = 0.8f;
						SPEED.Value = 0.2f;
						ACC.Value = 0.6f;
						CATRIDGE.Value = 0.6f;
						labelName.Text = RamboState.wa_lv2;
				} else if (RamboState.state_sung == 28) {
						DMG.Value = 1f;
						SPEED.Value = 0.2f;
						ACC.Value = 0.8f;
						CATRIDGE.Value = 0.6f;
						labelName.Text = RamboState.wa_lv3;
				} else if (RamboState.state_sung == 29) {
						DMG.Value = 1f;
						SPEED.Value = 0.2f;
						ACC.Value = 1f;
						CATRIDGE.Value = 0.2f;
						labelName.Text = RamboState.bazooka;
				} else if (RamboState.state_sung == 30) {
						DMG.Value = 1f;
						SPEED.Value = 0.4f;
						ACC.Value = 1f;
						CATRIDGE.Value = 0.4f;
						labelName.Text = RamboState.vip1;
				} else if (RamboState.state_sung == 31) {
						DMG.Value = 1f;
						SPEED.Value = 0.6f;
						ACC.Value = 1f;
						CATRIDGE.Value = 0.6f;
						labelName.Text = RamboState.vip2;
				} else if (RamboState.state_sung == 32) {
						DMG.Value = 1f;
						SPEED.Value = 0.8f;
						ACC.Value = 1f;
						CATRIDGE.Value = 0.8f;
						labelName.Text = RamboState.vip3;
				}

				#endregion

				panelInfoItems.SetActive (false);
				Character.SetActive (false);
				panelFashion.SetActive (false);
				panelItems.SetActive (false);
				panelWeapon.SetActive (true);
				panelInfoGun.SetActive (true);
				labelNameOfClothers.Text = "";
				btnItems.IsEnabled = true;
				btnFashion.IsEnabled = true;
				btnWeapon.IsEnabled = false;
		}
    #endregion

    #region View Fashion
		public void FashionButtonClick ()
		{       //Chon nut quan ao
				LoadInfo.SaveShop ();
				if (RamboState.huongdan_fashion == 0 && RamboState.level == 4 && GameObject.Find ("TutorialFashion").GetComponent<TutorialShopFashion> ().state == 0)
						GameObject.Find ("TutorialFashion").GetComponent<TutorialShopFashion> ().state = 1;  
				GameObject.Find ("Click").GetComponent<SoundClick> ().play ();
				for (int i = 0; i < items.Length; i++) {
						items [i].SetActive (false);
				}
				panelInfoItems.SetActive (false);
				Character.SetActive (true);
				labelName.Text = "";
				panelFashion.SetActive (true);
				panelItems.SetActive (false);
				panelWeapon.SetActive (false);
				panelInfoGun.SetActive (false);
		
				btnItems.IsEnabled = true;
				btnFashion.IsEnabled = false;
				btnWeapon.IsEnabled = true;  

				#region Load Clother Info
				if (RamboState.state_clothes == 0) {
						#region Sport
						labelNameOfClothers.Text = RamboState.sport;
						panelSport.BackgroundSprite = "bb_equipped";
						panelCowboy.BackgroundSprite = "bb_unequip_2";
						panelMer.BackgroundSprite = "bb_unequip_2";
						panelLuigi.BackgroundSprite = "bb_unequip_2";
						panelGangster.BackgroundSprite = "bb_unequip_2";
						panelAgent.BackgroundSprite = "bb_unequip_2";
						panelMario.BackgroundSprite = "bb_unequip_2";
						panelPijama.BackgroundSprite = "bb_unequip_2";
						panelMar.BackgroundSprite = "bb_unequip_2";
						panelSolider.BackgroundSprite = "bb_unequip_2";
						panelTuxedo.BackgroundSprite = "bb_unequip_2";
						panelSwat.BackgroundSprite = "bb_unequip_2";
						panelSanta.BackgroundSprite = "bb_unequip_2";

						spEquip [10].SetActive (true);
						spEquip [11].SetActive (false);
						spEquip [12].SetActive (false);
						spEquip [13].SetActive (false);
						spEquip [14].SetActive (false);
						spEquip [15].SetActive (false);
						spEquip [16].SetActive (false);
						spEquip [17].SetActive (false);
						spEquip [18].SetActive (false);
						spEquip [19].SetActive (false);
						spEquip [20].SetActive (false);
						spEquip [21].SetActive (false);
						spEquip [22].SetActive (false);
						mt_rambo.SetTexture (0, clothes [0]);
						#endregion
				} else if (RamboState.state_clothes == 1) {
						#region Cowboy
						labelNameOfClothers.Text = RamboState.cowboy;
						panelSport.BackgroundSprite = "bb_unequip_2";
						panelCowboy.BackgroundSprite = "bb_equipped";
						panelMer.BackgroundSprite = "bb_unequip_2";
						panelLuigi.BackgroundSprite = "bb_unequip_2";
						panelGangster.BackgroundSprite = "bb_unequip_2";
						panelAgent.BackgroundSprite = "bb_unequip_2";
						panelMario.BackgroundSprite = "bb_unequip_2";
						panelPijama.BackgroundSprite = "bb_unequip_2";
						panelMar.BackgroundSprite = "bb_unequip_2";
						panelSolider.BackgroundSprite = "bb_unequip_2";
						panelTuxedo.BackgroundSprite = "bb_unequip_2";
						panelSwat.BackgroundSprite = "bb_unequip_2";
						panelSanta.BackgroundSprite = "bb_unequip_2";
						spEquip [10].SetActive (false);
						spEquip [11].SetActive (true);
						spEquip [12].SetActive (false);
						spEquip [13].SetActive (false);
						spEquip [14].SetActive (false);
						spEquip [15].SetActive (false);
						spEquip [16].SetActive (false);
						spEquip [17].SetActive (false);
						spEquip [18].SetActive (false);
						spEquip [19].SetActive (false);
						spEquip [20].SetActive (false);
						spEquip [21].SetActive (false);
						spEquip [22].SetActive (false);
						mt_rambo.SetTexture (0, clothes [1]);
						#endregion
				} else if (RamboState.state_clothes == 2) {
						#region Mer
						labelNameOfClothers.Text = RamboState.mer;
						panelSport.BackgroundSprite = "bb_unequip_2";
						panelCowboy.BackgroundSprite = "bb_unequip_2";
						panelMer.BackgroundSprite = "bb_equipped";
						panelLuigi.BackgroundSprite = "bb_unequip_2";
						panelGangster.BackgroundSprite = "bb_unequip_2";
						panelAgent.BackgroundSprite = "bb_unequip_2";
						panelMario.BackgroundSprite = "bb_unequip_2";
						panelPijama.BackgroundSprite = "bb_unequip_2";
						panelMar.BackgroundSprite = "bb_unequip_2";
						panelSolider.BackgroundSprite = "bb_unequip_2";
						panelTuxedo.BackgroundSprite = "bb_unequip_2";
						panelSwat.BackgroundSprite = "bb_unequip_2";
						panelSanta.BackgroundSprite = "bb_unequip_2";
						spEquip [10].SetActive (false);
						spEquip [11].SetActive (false);
						spEquip [12].SetActive (true);
						spEquip [13].SetActive (false);
						spEquip [14].SetActive (false);
						spEquip [15].SetActive (false);
						spEquip [16].SetActive (false);
						spEquip [17].SetActive (false);
						spEquip [18].SetActive (false);
						spEquip [19].SetActive (false);
						spEquip [20].SetActive (false);
						spEquip [21].SetActive (false);
						spEquip [22].SetActive (false);
						mt_rambo.SetTexture (0, clothes [2]);
						#endregion
				} else if (RamboState.state_clothes == 3) {
						#region Luigi
						labelNameOfClothers.Text = RamboState.luigi;
						panelSport.BackgroundSprite = "bb_unequip_2";
						panelCowboy.BackgroundSprite = "bb_unequip_2";
						panelMer.BackgroundSprite = "bb_unequip_2";
						panelLuigi.BackgroundSprite = "bb_equipped";
						panelGangster.BackgroundSprite = "bb_unequip_2";
						panelAgent.BackgroundSprite = "bb_unequip_2";
						panelMario.BackgroundSprite = "bb_unequip_2";
						panelPijama.BackgroundSprite = "bb_unequip_2";
						panelMar.BackgroundSprite = "bb_unequip_2";
						panelSolider.BackgroundSprite = "bb_unequip_2";
						panelTuxedo.BackgroundSprite = "bb_unequip_2";
						panelSwat.BackgroundSprite = "bb_unequip_2";
						panelSanta.BackgroundSprite = "bb_unequip_2";
						spEquip [10].SetActive (false);
						spEquip [11].SetActive (false);
						spEquip [12].SetActive (false);
						spEquip [13].SetActive (true);
						spEquip [14].SetActive (false);
						spEquip [15].SetActive (false);
						spEquip [16].SetActive (false);
						spEquip [17].SetActive (false);
						spEquip [18].SetActive (false);
						spEquip [19].SetActive (false);
						spEquip [20].SetActive (false);
						spEquip [21].SetActive (false);
						spEquip [22].SetActive (false);
						mt_rambo.SetTexture (0, clothes [3]);
						#endregion
				} else if (RamboState.state_clothes == 4) {
						#region Gangster
						labelNameOfClothers.Text = RamboState.gangster;
						panelSport.BackgroundSprite = "bb_unequip_2";
						panelCowboy.BackgroundSprite = "bb_unequip_2";
						panelMer.BackgroundSprite = "bb_unequip_2";
						panelLuigi.BackgroundSprite = "bb_unequip_2";
						panelGangster.BackgroundSprite = "bb_equipped";
						panelAgent.BackgroundSprite = "bb_unequip_2";
						panelMario.BackgroundSprite = "bb_unequip_2";
						panelPijama.BackgroundSprite = "bb_unequip_2";
						panelMar.BackgroundSprite = "bb_unequip_2";
						panelSolider.BackgroundSprite = "bb_unequip_2";
						panelTuxedo.BackgroundSprite = "bb_unequip_2";
						panelSwat.BackgroundSprite = "bb_unequip_2";
						panelSanta.BackgroundSprite = "bb_unequip_2";
						spEquip [10].SetActive (false);
						spEquip [11].SetActive (false);
						spEquip [12].SetActive (false);
						spEquip [13].SetActive (false);
						spEquip [14].SetActive (true);
						spEquip [15].SetActive (false);
						spEquip [16].SetActive (false);
						spEquip [17].SetActive (false);
						spEquip [18].SetActive (false);
						spEquip [19].SetActive (false);
						spEquip [20].SetActive (false);
						spEquip [21].SetActive (false);
						spEquip [22].SetActive (false);
						mt_rambo.SetTexture (0, clothes [4]);
						#endregion
				} else if (RamboState.state_clothes == 5) {

						#region Agent
						spEquip [10].SetActive (false);
						spEquip [11].SetActive (false);
						spEquip [12].SetActive (false);
						spEquip [13].SetActive (false);
						spEquip [14].SetActive (false);
						spEquip [15].SetActive (true);
						spEquip [16].SetActive (false);
						spEquip [17].SetActive (false);
						spEquip [18].SetActive (false);
						spEquip [19].SetActive (false);
						spEquip [20].SetActive (false);
						spEquip [21].SetActive (false);
						spEquip [22].SetActive (false);
						labelNameOfClothers.Text = RamboState.agent;
						panelSport.BackgroundSprite = "bb_unequip_2";
						panelCowboy.BackgroundSprite = "bb_unequip_2";
						panelMer.BackgroundSprite = "bb_unequip_2";
						panelLuigi.BackgroundSprite = "bb_unequip_2";
						panelGangster.BackgroundSprite = "bb_unequip_2";
						panelAgent.BackgroundSprite = "bb_equipped";
						panelMario.BackgroundSprite = "bb_unequip_2";
						panelPijama.BackgroundSprite = "bb_unequip_2";
						panelMar.BackgroundSprite = "bb_unequip_2";
						panelSolider.BackgroundSprite = "bb_unequip_2";
						panelTuxedo.BackgroundSprite = "bb_unequip_2";
						panelSwat.BackgroundSprite = "bb_unequip_2";
						panelSanta.BackgroundSprite = "bb_unequip_2";
						mt_rambo.SetTexture (0, clothes [5]);
						#endregion
				} else if (RamboState.state_clothes == 6) {
						#region Mario
						labelNameOfClothers.Text = RamboState.mario;
						panelSport.BackgroundSprite = "bb_unequip_2";
						panelCowboy.BackgroundSprite = "bb_unequip_2";
						panelMer.BackgroundSprite = "bb_unequip_2";
						panelLuigi.BackgroundSprite = "bb_unequip_2";
						panelGangster.BackgroundSprite = "bb_unequip_2";
						panelAgent.BackgroundSprite = "bb_unequip_2";
						panelMario.BackgroundSprite = "bb_equipped";
						panelPijama.BackgroundSprite = "bb_unequip_2";
						panelMar.BackgroundSprite = "bb_unequip_2";
						panelSolider.BackgroundSprite = "bb_unequip_2";
						panelTuxedo.BackgroundSprite = "bb_unequip_2";
						panelSwat.BackgroundSprite = "bb_unequip_2";
						panelSanta.BackgroundSprite = "bb_unequip_2";
						spEquip [10].SetActive (false);
						spEquip [11].SetActive (false);
						spEquip [12].SetActive (false);
						spEquip [13].SetActive (false);
						spEquip [14].SetActive (false);
						spEquip [15].SetActive (false);
						spEquip [16].SetActive (true);
						spEquip [17].SetActive (false);
						spEquip [18].SetActive (false);
						spEquip [19].SetActive (false);
						spEquip [20].SetActive (false);
						spEquip [21].SetActive (false);
						mt_rambo.SetTexture (0, clothes [6]);
						spEquip [22].SetActive (false);
						#endregion
				} else if (RamboState.state_clothes == 7) {
						#region Pijama
						labelNameOfClothers.Text = RamboState.pijama;
						panelSport.BackgroundSprite = "bb_unequip_2";
						panelCowboy.BackgroundSprite = "bb_unequip_2";
						panelMer.BackgroundSprite = "bb_unequip_2";
						panelLuigi.BackgroundSprite = "bb_unequip_2";
						panelGangster.BackgroundSprite = "bb_unequip_2";
						panelAgent.BackgroundSprite = "bb_unequip_2";
						panelMario.BackgroundSprite = "bb_unequip_2";
						panelPijama.BackgroundSprite = "bb_equipped";
						panelMar.BackgroundSprite = "bb_unequip_2";
						panelSolider.BackgroundSprite = "bb_unequip_2";
						panelTuxedo.BackgroundSprite = "bb_unequip_2";
						panelSwat.BackgroundSprite = "bb_unequip_2";
						panelSanta.BackgroundSprite = "bb_unequip_2";
						spEquip [10].SetActive (false);
						spEquip [11].SetActive (false);
						spEquip [12].SetActive (false);
						spEquip [13].SetActive (false);
						spEquip [14].SetActive (false);
						spEquip [15].SetActive (false);
						spEquip [16].SetActive (false);
						spEquip [17].SetActive (true);
						spEquip [18].SetActive (false);
						spEquip [19].SetActive (false);
						spEquip [20].SetActive (false);
						spEquip [21].SetActive (false);
						spEquip [22].SetActive (false);
						mt_rambo.SetTexture (0, clothes [7]);
						#endregion
				} else if (RamboState.state_clothes == 8) {
						#region Mar
						labelNameOfClothers.Text = RamboState.mar;
						panelSport.BackgroundSprite = "bb_unequip_2";
						panelCowboy.BackgroundSprite = "bb_unequip_2";
						panelMer.BackgroundSprite = "bb_unequip_2";
						panelLuigi.BackgroundSprite = "bb_unequip_2";
						panelGangster.BackgroundSprite = "bb_unequip_2";
						panelAgent.BackgroundSprite = "bb_unequip_2";
						panelMario.BackgroundSprite = "bb_unequip_2";
						panelPijama.BackgroundSprite = "bb_unequip_2";
						panelMar.BackgroundSprite = "bb_equipped";
						panelSolider.BackgroundSprite = "bb_unequip_2";
						panelTuxedo.BackgroundSprite = "bb_unequip_2";
						panelSwat.BackgroundSprite = "bb_unequip_2";
						panelSanta.BackgroundSprite = "bb_unequip_2";
						spEquip [10].SetActive (false);
						spEquip [11].SetActive (false);
						spEquip [12].SetActive (false);
						spEquip [13].SetActive (false);
						spEquip [14].SetActive (false);
						spEquip [15].SetActive (false);
						spEquip [16].SetActive (false);
						spEquip [17].SetActive (false);
						spEquip [18].SetActive (true);
						spEquip [19].SetActive (false);
						spEquip [20].SetActive (false);
						spEquip [21].SetActive (false);
						spEquip [22].SetActive (false);
						mt_rambo.SetTexture (0, clothes [8]);
						#endregion
				} else if (RamboState.state_clothes == 9) {
						#region Solider
						labelNameOfClothers.Text = RamboState.solider;
						panelSport.BackgroundSprite = "bb_unequip_2";
						panelCowboy.BackgroundSprite = "bb_unequip_2";
						panelMer.BackgroundSprite = "bb_unequip_2";
						panelLuigi.BackgroundSprite = "bb_unequip_2";
						panelGangster.BackgroundSprite = "bb_unequip_2";
						panelAgent.BackgroundSprite = "bb_unequip_2";
						panelMario.BackgroundSprite = "bb_unequip_2";
						panelPijama.BackgroundSprite = "bb_unequip_2";
						panelMar.BackgroundSprite = "bb_unequip_2";
						panelSolider.BackgroundSprite = "bb_equipped";
						panelTuxedo.BackgroundSprite = "bb_unequip_2";
						panelSwat.BackgroundSprite = "bb_unequip_2";
						panelSanta.BackgroundSprite = "bb_unequip_2";
						spEquip [10].SetActive (false);
						spEquip [11].SetActive (false);
						spEquip [12].SetActive (false);
						spEquip [13].SetActive (false);
						spEquip [14].SetActive (false);
						spEquip [15].SetActive (false);
						spEquip [16].SetActive (false);
						spEquip [17].SetActive (false);
						spEquip [18].SetActive (false);
						spEquip [19].SetActive (true);
						spEquip [20].SetActive (false);
						spEquip [21].SetActive (false);
						mt_rambo.SetTexture (0, clothes [9]);
						spEquip [22].SetActive (false);
						#endregion
				} else if (RamboState.state_clothes == 10) {
						#region Tuxedo
						labelNameOfClothers.Text = RamboState.tuxedo;
						panelSport.BackgroundSprite = "bb_unequip_2";
						panelCowboy.BackgroundSprite = "bb_unequip_2";
						panelMer.BackgroundSprite = "bb_unequip_2";
						panelLuigi.BackgroundSprite = "bb_unequip_2";
						panelGangster.BackgroundSprite = "bb_unequip_2";
						panelAgent.BackgroundSprite = "bb_unequip_2";
						panelMario.BackgroundSprite = "bb_unequip_2";
						panelPijama.BackgroundSprite = "bb_unequip_2";
						panelMar.BackgroundSprite = "bb_unequip_2";
						panelSolider.BackgroundSprite = "bb_unequip_2";
						panelTuxedo.BackgroundSprite = "bb_equipped";
						panelSwat.BackgroundSprite = "bb_unequip_2";
						panelSanta.BackgroundSprite = "bb_unequip_2";
						spEquip [10].SetActive (false);
						spEquip [11].SetActive (false);
						spEquip [12].SetActive (false);
						spEquip [13].SetActive (false);
						spEquip [14].SetActive (false);
						spEquip [15].SetActive (false);
						spEquip [16].SetActive (false);
						spEquip [17].SetActive (false);
						spEquip [18].SetActive (false);
						spEquip [19].SetActive (false);
						spEquip [20].SetActive (true);
						spEquip [21].SetActive (false);
						mt_rambo.SetTexture (0, clothes [10]);
						spEquip [22].SetActive (false);
						#endregion
				} else if (RamboState.state_clothes == 11) {
						#region Swat
						labelNameOfClothers.Text = RamboState.swat;
						panelSport.BackgroundSprite = "bb_unequip_2";
						panelCowboy.BackgroundSprite = "bb_unequip_2";
						panelMer.BackgroundSprite = "bb_unequip_2";
						panelLuigi.BackgroundSprite = "bb_unequip_2";
						panelGangster.BackgroundSprite = "bb_unequip_2";
						panelAgent.BackgroundSprite = "bb_unequip_2";
						panelMario.BackgroundSprite = "bb_unequip_2";
						panelPijama.BackgroundSprite = "bb_unequip_2";
						panelMar.BackgroundSprite = "bb_unequip_2";
						panelSolider.BackgroundSprite = "bb_unequip_2";
						panelTuxedo.BackgroundSprite = "bb_unequip_2";
						panelSwat.BackgroundSprite = "bb_equipped";
						panelSanta.BackgroundSprite = "bb_unequip_2";
						spEquip [10].SetActive (false);
						spEquip [11].SetActive (false);
						spEquip [12].SetActive (false);
						spEquip [13].SetActive (false);
						spEquip [14].SetActive (false);
						spEquip [15].SetActive (false);
						spEquip [16].SetActive (false);
						spEquip [17].SetActive (false);
						spEquip [18].SetActive (false);
						spEquip [19].SetActive (false);
						spEquip [20].SetActive (false);
						spEquip [21].SetActive (true);
						mt_rambo.SetTexture (0, clothes [11]);
						spEquip [22].SetActive (false);
						#endregion
				} else if (RamboState.state_clothes == 12) {
						#region Swat
						labelNameOfClothers.Text = RamboState.swat;
						panelSport.BackgroundSprite = "bb_unequip_2";
						panelCowboy.BackgroundSprite = "bb_unequip_2";
						panelMer.BackgroundSprite = "bb_unequip_2";
						panelLuigi.BackgroundSprite = "bb_unequip_2";
						panelGangster.BackgroundSprite = "bb_unequip_2";
						panelAgent.BackgroundSprite = "bb_unequip_2";
						panelMario.BackgroundSprite = "bb_unequip_2";
						panelPijama.BackgroundSprite = "bb_unequip_2";
						panelMar.BackgroundSprite = "bb_unequip_2";
						panelSolider.BackgroundSprite = "bb_unequip_2";
						panelTuxedo.BackgroundSprite = "bb_unequip_2";
						panelSwat.BackgroundSprite = "bb_unequip_2";
						panelSanta.BackgroundSprite = "bb_equipped";
						spEquip [10].SetActive (false);
						spEquip [11].SetActive (false);
						spEquip [12].SetActive (false);
						spEquip [13].SetActive (false);
						spEquip [14].SetActive (false);
						spEquip [15].SetActive (false);
						spEquip [16].SetActive (false);
						spEquip [17].SetActive (false);
						spEquip [18].SetActive (false);
						spEquip [19].SetActive (false);
						spEquip [20].SetActive (false);
						spEquip [21].SetActive (false);
						spEquip [22].SetActive (true);
						mt_rambo.SetTexture (0, clothes [12]);
						#endregion
				}



				if (RamboState.clothes_buy [1] == 1)
						btnBuyCowboy.Text = "EQUIP";
				else
						btnBuyCowboy.Text = "BUY";
				if (RamboState.clothes_buy [2] == 1)
						btnBuyMer.Text = "EQUIP";
				else
						btnBuyMer.Text = "BUY";
				if (RamboState.clothes_buy [3] == 1)
						btnBuyLuigi.Text = "EQUIP";
				else
						btnBuyLuigi.Text = "BUY";
				if (RamboState.clothes_buy [4] == 1)
						btnBuyGangster.Text = "EQUIP";
				else
						btnBuyGangster.Text = "BUY";
				if (RamboState.clothes_buy [5] == 1)
						btnBuyAgent.Text = "EQUIP";
				else
						btnBuyAgent.Text = "BUY";
				if (RamboState.clothes_buy [6] == 1)
						btnBuyMario.Text = "EQUIP";
				else
						btnBuyMario.Text = "BUY";
				if (RamboState.clothes_buy [7] == 1)
						btnBuyPijama.Text = "EQUIP";
				else
						btnBuyPijama.Text = "BUY";
				if (RamboState.clothes_buy [8] == 1)
						btnBuyMar.Text = "EQUIP";
				else
						btnBuyMar.Text = "BUY";
				if (RamboState.clothes_buy [9] == 1)
						btnBuySolider.Text = "EQUIP";
				else
						btnBuySolider.Text = "BUY";
				if (RamboState.clothes_buy [10] == 1)
						btnBuyTuxedo.Text = "EQUIP";
				else
						btnBuyTuxedo.Text = "BUY";
				if (RamboState.clothes_buy [11] == 1)
						btnBuySwat.Text = "EQUIP";
				else
						btnBuySwat.Text = "BUY";
				if (RamboState.clothes_buy [12] == 1)
						btnBuysanta.Text = "EQUIP";
				else
						btnBuysanta.Text = "BUY";
	
				#endregion

				 
		}
    #endregion

    #region Buy Clothers
		public void BuyClothers (dfControl control, dfMouseEventArgs mouseEvent)
		{   // mua quan ao
				GameObject.Find ("Click").GetComponent<SoundClick> ().play ();
				if (control.name == "Button Buy Sport") {
						#region Sport
						labelNameOfClothers.Text = RamboState.sport;
						RamboState.state_clothes = 0;
						mt_rambo.SetTexture (0, clothes [0]);
						spEquip [10].SetActive (true);
						spEquip [11].SetActive (false);
						spEquip [12].SetActive (false);
						spEquip [13].SetActive (false);
						spEquip [14].SetActive (false);
						spEquip [15].SetActive (false);
						spEquip [16].SetActive (false);
						spEquip [17].SetActive (false);
						spEquip [18].SetActive (false);
						spEquip [19].SetActive (false);
						spEquip [20].SetActive (false);
						spEquip [21].SetActive (false);
						spEquip [22].SetActive (false);
						#endregion
				} else if (control.name == "Button Buy Cowboy") {
						#region Buy Cowboy
						if (RamboState.clothes_buy [1] == 0) {
								if (RamboState.level != 4) {
										if (RamboState.dola >= 3000) {
												RamboState.clothes_buy [1] = 1;
												PlayerPrefs.SetInt ("clotherBuy" + 1, 1);
												RamboState.dola -= 3000;
												btnBuyCowboy.Text = "EQUIP";
												mt_rambo.SetTexture (0, clothes [1]);
												RamboState.huongdan_fashion = 1;
												PlayerPrefs.SetInt ("huongdanfashion", 1);
										} else {
												naptien ();

										}

								} else {
										if (GameObject.Find ("TutorialFashion").GetComponent<TutorialShopFashion> ().state == 2) {
												GameObject.Find ("TutorialFashion").GetComponent<TutorialShopFashion> ().state = 3;
												RamboState.huongdan_fashion = 1;
												PlayerPrefs.SetInt ("huongdanfashion", 1);
												RamboState.dola += 1000;
												RamboState.clothes_buy [1] = 1;
												PlayerPrefs.SetInt ("clotherBuy" + 1, 1);
												RamboState.dola -= 3000;
												btnBuyCowboy.Text = "EQUIP";
												mt_rambo.SetTexture (0, clothes [1]);
												RamboState.huongdan_fashion = 1;
												PlayerPrefs.SetInt ("huongdanfashion", 1);
					
										}


								}
						}
						if (RamboState.clothes_buy [1] == 1) {
								labelNameOfClothers.Text = RamboState.cowboy;
								mt_rambo.SetTexture (0, clothes [1]);
								RamboState.state_clothes = 1;
								spEquip [10].SetActive (false);
								spEquip [11].SetActive (true);
								spEquip [12].SetActive (false);
								spEquip [13].SetActive (false);
								spEquip [14].SetActive (false);
								spEquip [15].SetActive (false);
								spEquip [16].SetActive (false);
								spEquip [17].SetActive (false);
								spEquip [18].SetActive (false);
								spEquip [19].SetActive (false);
								spEquip [20].SetActive (false);
								spEquip [21].SetActive (false);
								spEquip [22].SetActive (false);
						}
						#endregion
				} else if (control.name == "Button Buy Mer") {
						#region Buy Mercenary
						if (RamboState.clothes_buy [2] == 0) {
								if (RamboState.dola >= 3500) {
										RamboState.clothes_buy [2] = 1;
										PlayerPrefs.SetInt ("clotherBuy" + 2, 1);
										mt_rambo.SetTexture (0, clothes [2]);
										RamboState.dola -= 3500;
										RamboState.dola += 2000;
										btnBuyMer.Text = "EQUIP";
								} else {
										naptien ();

								}
						}
						if (RamboState.clothes_buy [2] == 1) {
								labelNameOfClothers.Text = RamboState.mer;
								RamboState.state_clothes = 2;
								spEquip [10].SetActive (false);
								spEquip [11].SetActive (false);
								spEquip [12].SetActive (true);
								spEquip [13].SetActive (false);
								spEquip [14].SetActive (false);
								spEquip [15].SetActive (false);
								spEquip [16].SetActive (false);
								spEquip [17].SetActive (false);
								spEquip [18].SetActive (false);
								spEquip [19].SetActive (false);
								spEquip [20].SetActive (false);
								spEquip [21].SetActive (false);
								spEquip [22].SetActive (false);
								mt_rambo.SetTexture (0, clothes [2]);
						}
						#endregion
				} else if (control.name == "Button Buy Luigi") {
						#region Buy Luigi
						if (RamboState.clothes_buy [3] == 0) {

								if (RamboState.check_unlock_clothes [0] == 1 || RamboState.state_level1 [9] > 0 || RamboState.state_level2 [9] > 0 || RamboState.state_level3 [9] > 0) {  
										if (RamboState.dola >= 7000) {
												RamboState.clothes_buy [3] = 1;
												PlayerPrefs.SetInt ("clotherBuy" + 3, 1);
												mt_rambo.SetTexture (0, clothes [3]);
												RamboState.dola -= 7000;
												btnBuyLuigi.Text = "EQUIP";
										} else {
												naptien ();
										}

								} else {
										GameObject.Find ("Unlockgun").GetComponent<dfTweenVector3> ().Play ();
										GameObject.Find ("textunlock").GetComponent<dfLabel> ().Text = "Unlock at chapter 2";
										GameObject.Find ("Camera 3D").GetComponent<Camera> ().enabled = false;
										RamboState.state_unlock = 8;
					
								}
						}
						if (RamboState.clothes_buy [3] == 1) {
								labelNameOfClothers.Text = RamboState.luigi;
								RamboState.state_clothes = 3;
								spEquip [10].SetActive (false);
								spEquip [11].SetActive (false);
								spEquip [12].SetActive (false);
								spEquip [13].SetActive (true);
								spEquip [14].SetActive (false);
								spEquip [15].SetActive (false);
								spEquip [16].SetActive (false);
								spEquip [17].SetActive (false);
								spEquip [18].SetActive (false);
								spEquip [19].SetActive (false);
								spEquip [20].SetActive (false);
								spEquip [21].SetActive (false);
								spEquip [22].SetActive (false);
								mt_rambo.SetTexture (0, clothes [3]);
						}
						#endregion
				} else if (control.name == "Button Buy Gangster") {
						#region Buy Gangster
						if (RamboState.clothes_buy [4] == 0) {
								if (RamboState.check_unlock_clothes [1] == 1 || RamboState.state_level1 [9] > 0 || RamboState.state_level2 [9] > 0 || RamboState.state_level3 [9] > 0) {  
										if (RamboState.dola >= 12000) {
												RamboState.clothes_buy [4] = 1;
												PlayerPrefs.SetInt ("clotherBuy" + 4, 1);
												mt_rambo.SetTexture (0, clothes [4]);
												RamboState.dola -= 12000;
												btnBuyGangster.Text = "EQUIP";
										} else {
												naptien ();

										}
								} else {
										GameObject.Find ("Unlockgun").GetComponent<dfTweenVector3> ().Play ();
										GameObject.Find ("textunlock").GetComponent<dfLabel> ().Text = "Unlock at chapter 2";
										GameObject.Find ("Camera 3D").GetComponent<Camera> ().enabled = false;
										RamboState.state_unlock = 9;
					
								}
						}
						if (RamboState.clothes_buy [4] == 1) {
								labelNameOfClothers.Text = RamboState.gangster;
								RamboState.state_clothes = 4;
								spEquip [10].SetActive (false);
								spEquip [11].SetActive (false);
								spEquip [12].SetActive (false);
								spEquip [13].SetActive (false);
								spEquip [14].SetActive (true);
								spEquip [15].SetActive (false);
								spEquip [16].SetActive (false);
								spEquip [17].SetActive (false);
								spEquip [18].SetActive (false);
								spEquip [19].SetActive (false);
								spEquip [20].SetActive (false);
								spEquip [21].SetActive (false);
								spEquip [22].SetActive (false);
								mt_rambo.SetTexture (0, clothes [4]);
						}
						#endregion
				} else if (control.name == "Button Buy Agent") {
						#region Buy Agent
						if (RamboState.clothes_buy [5] == 0) {
								if (RamboState.check_unlock_clothes [2] == 1 || RamboState.state_level1 [9] > 0 || RamboState.state_level2 [9] > 0 || RamboState.state_level3 [9] > 0) {  
										if (RamboState.dola >= 25000) {
												RamboState.clothes_buy [5] = 1;
												PlayerPrefs.SetInt ("clotherBuy" + 5, 1);
												mt_rambo.SetTexture (0, clothes [5]);
												RamboState.dola -= 25000;
												btnBuyAgent.Text = "EQUIP";
										} else {
												naptien ();

										}
								} else {
										GameObject.Find ("Unlockgun").GetComponent<dfTweenVector3> ().Play ();
										GameObject.Find ("textunlock").GetComponent<dfLabel> ().Text = "Unlock at chapter 2";
										GameObject.Find ("Camera 3D").GetComponent<Camera> ().enabled = false;
										RamboState.state_unlock = 10;
					
								}
						}
						if (RamboState.clothes_buy [5] == 1) {
								labelNameOfClothers.Text = RamboState.agent;
								RamboState.state_clothes = 5;
								spEquip [10].SetActive (false);
								spEquip [11].SetActive (false);
								spEquip [12].SetActive (false);
								spEquip [13].SetActive (false);
								spEquip [14].SetActive (false);
								spEquip [15].SetActive (true);
								spEquip [16].SetActive (false);
								spEquip [17].SetActive (false);
								spEquip [18].SetActive (false);
								spEquip [19].SetActive (false);
								spEquip [20].SetActive (false);
								spEquip [21].SetActive (false);
								spEquip [22].SetActive (false);
								mt_rambo.SetTexture (0, clothes [5]);
						}
						#endregion
				} else if (control.name == "Button Buy Mario") {
						#region Buy Mario
						if (RamboState.clothes_buy [6] == 0) {
								if (RamboState.check_unlock_clothes [3] == 1 || RamboState.state_level1 [19] > 0 || RamboState.state_level2 [19] > 0 || RamboState.state_level3 [19] > 0) {  
										if (RamboState.dola >= 35000) {
												RamboState.clothes_buy [6] = 1;
												PlayerPrefs.SetInt ("clotherBuy" + 6, 1);
												mt_rambo.SetTexture (0, clothes [6]);
												RamboState.dola -= 35000;
												btnBuyMario.Text = "EQUIP";
										} else {
												naptien ();

										}
								} else {
										GameObject.Find ("Unlockgun").GetComponent<dfTweenVector3> ().Play ();
										GameObject.Find ("textunlock").GetComponent<dfLabel> ().Text = "Unlock at chapter 3";
										GameObject.Find ("Camera 3D").GetComponent<Camera> ().enabled = false;
										RamboState.state_unlock = 11;
					
								}
						}
						if (RamboState.clothes_buy [6] == 1) {
								labelNameOfClothers.Text = RamboState.mario;
								RamboState.state_clothes = 6;
								spEquip [10].SetActive (false);
								spEquip [11].SetActive (false);
								spEquip [12].SetActive (false);
								spEquip [13].SetActive (false);
								spEquip [14].SetActive (false);
								spEquip [15].SetActive (false);
								spEquip [16].SetActive (true);
								spEquip [17].SetActive (false);
								spEquip [18].SetActive (false);
								spEquip [19].SetActive (false);
								spEquip [20].SetActive (false);
								spEquip [21].SetActive (false);
								spEquip [22].SetActive (false);
								mt_rambo.SetTexture (0, clothes [6]);
						}
						#endregion
				} else if (control.name == "Button Buy Pijama") {
						#region Buy Pijama
						if (RamboState.clothes_buy [7] == 0) {
								if (RamboState.check_unlock_clothes [4] == 1 || RamboState.state_level1 [19] > 0 || RamboState.state_level2 [19] > 0 || RamboState.state_level3 [19] > 0) {
										if (RamboState.dola >= 55000) {
												RamboState.clothes_buy [7] = 1;
												PlayerPrefs.SetInt ("clotherBuy" + 7, 1);
												mt_rambo.SetTexture (0, clothes [7]);
												RamboState.dola -= 55000;
												btnBuyPijama.Text = "EQUIP";
										} else {
												naptien ();

										}
								} else {
										GameObject.Find ("Unlockgun").GetComponent<dfTweenVector3> ().Play ();
										GameObject.Find ("textunlock").GetComponent<dfLabel> ().Text = "Unlock at chapter 3";
										GameObject.Find ("Camera 3D").GetComponent<Camera> ().enabled = false;
										RamboState.state_unlock = 12;
					
								}
						}
						if (RamboState.clothes_buy [7] == 1) {
								labelNameOfClothers.Text = RamboState.pijama;
								RamboState.state_clothes = 7;
								spEquip [10].SetActive (false);
								spEquip [11].SetActive (false);
								spEquip [12].SetActive (false);
								spEquip [13].SetActive (false);
								spEquip [14].SetActive (false);
								spEquip [15].SetActive (false);
								spEquip [16].SetActive (false);
								spEquip [17].SetActive (true);
								spEquip [18].SetActive (false);
								spEquip [19].SetActive (false);
								spEquip [20].SetActive (false);
								spEquip [21].SetActive (false);
								spEquip [22].SetActive (false);
								mt_rambo.SetTexture (0, clothes [7]);
						}
						#endregion
				} else if (control.name == "Button Buy Mar") {
						#region Buy Marine
						if (RamboState.clothes_buy [8] == 0) {
								if (RamboState.check_unlock_clothes [5] == 1 || RamboState.state_level1 [19] > 0 || RamboState.state_level2 [19] > 0 || RamboState.state_level3 [19] > 0) {
										//OpenIAB.purchaseProduct (OpenIABTest.BUYCLOTHERS1);
										if (RamboState.dola >= 55000) {
												RamboState.clothes_buy [8] = 1;
												PlayerPrefs.SetInt ("clotherBuy" + 8, 1);
												mt_rambo.SetTexture (0, clothes [8]);
												RamboState.dola -= 55000;
												btnBuyMar.Text = "EQUIP";
										} else {
												naptien ();
					
										}
								} else {
										GameObject.Find ("Unlockgun").GetComponent<dfTweenVector3> ().Play ();
										GameObject.Find ("textunlock").GetComponent<dfLabel> ().Text = "Unlock at chapter 3";
										GameObject.Find ("Camera 3D").GetComponent<Camera> ().enabled = false;
										RamboState.state_unlock = 13;
					
								}
						}
						if (RamboState.clothes_buy [8] == 1) {
								labelNameOfClothers.Text = RamboState.mar;
								RamboState.state_clothes = 8;
								spEquip [10].SetActive (false);
								spEquip [11].SetActive (false);
								spEquip [12].SetActive (false);
								spEquip [13].SetActive (false);
								spEquip [14].SetActive (false);
								spEquip [15].SetActive (false);
								spEquip [16].SetActive (false);
								spEquip [17].SetActive (false);
								spEquip [18].SetActive (true);
								spEquip [19].SetActive (false);
								spEquip [20].SetActive (false);
								spEquip [21].SetActive (false);
								spEquip [22].SetActive (false);
								mt_rambo.SetTexture (0, clothes [8]);
						}

						// BuyMarine();
						#endregion
				} else if (control.name == "Button Buy Solider") {
						#region Buy Solider
						// BuySolider();	
						if (RamboState.clothes_buy [9] == 0) {
								if (RamboState.check_unlock_clothes [6] == 1 || RamboState.state_level1 [29] > 0 || RamboState.state_level2 [29] > 0 || RamboState.state_level3 [29] > 0) {
										//OpenIAB.purchaseProduct (OpenIABTest.BUYCLOTHERS2);
										if (RamboState.dola >= 55000) {
												RamboState.clothes_buy [9] = 1;
												PlayerPrefs.SetInt ("clotherBuy" + 9, 1);
												mt_rambo.SetTexture (0, clothes [9]);
												RamboState.dola -= 55000;
												btnBuySolider.Text = "EQUIP";
										} else {
												naptien ();
					
										}

								} else {
										GameObject.Find ("Unlockgun").GetComponent<dfTweenVector3> ().Play ();
										GameObject.Find ("textunlock").GetComponent<dfLabel> ().Text = "Unlock at chapter 4";
										GameObject.Find ("Camera 3D").GetComponent<Camera> ().enabled = false;
										RamboState.state_unlock = 14;
					
								}
						} else if (RamboState.clothes_buy [9] == 1) {
								labelNameOfClothers.Text = RamboState.solider;
								RamboState.state_clothes = 9;
								spEquip [10].SetActive (false);
								spEquip [11].SetActive (false);
								spEquip [12].SetActive (false);
								spEquip [13].SetActive (false);
								spEquip [14].SetActive (false);
								spEquip [15].SetActive (false);
								spEquip [16].SetActive (false);
								spEquip [17].SetActive (false);
								spEquip [18].SetActive (false);
								spEquip [19].SetActive (true);
								spEquip [20].SetActive (false);
								spEquip [21].SetActive (false);
								spEquip [22].SetActive (false);
								mt_rambo.SetTexture (0, clothes [9]);
						}

						#endregion
				} else if (control.name == "Button Buy Tuxedo") {
						#region Buy Tuxedo
						if (RamboState.clothes_buy [10] == 0) {
								if (RamboState.check_unlock_clothes [7] == 1 || RamboState.state_level1 [29] > 0 || RamboState.state_level2 [29] > 0 || RamboState.state_level3 [29] > 0) {
										//OpenIAB.purchaseProduct (OpenIABTest.BUYCLOTHERS3);
										if (RamboState.dola >= 55000) {
												RamboState.clothes_buy [10] = 1;
												PlayerPrefs.SetInt ("clotherBuy" + 10, 1);
												mt_rambo.SetTexture (0, clothes [10]);
												RamboState.dola -= 55000;
												btnBuyTuxedo.Text = "EQUIP";
										} else {
												naptien ();
					
										}
								} else {
										GameObject.Find ("Unlockgun").GetComponent<dfTweenVector3> ().Play ();
										GameObject.Find ("textunlock").GetComponent<dfLabel> ().Text = "Unlock at chapter 4";
										GameObject.Find ("Camera 3D").GetComponent<Camera> ().enabled = false;
										RamboState.state_unlock = 15;
					
								}
						} else if (RamboState.clothes_buy [10] == 1) {
								labelNameOfClothers.Text = RamboState.tuxedo;
								RamboState.state_clothes = 10;
								mt_rambo.SetTexture (0, clothes [10]);
								spEquip [10].SetActive (false);
								spEquip [11].SetActive (false);
								spEquip [12].SetActive (false);
								spEquip [13].SetActive (false);
								spEquip [14].SetActive (false);
								spEquip [15].SetActive (false);
								spEquip [16].SetActive (false);
								spEquip [17].SetActive (false);
								spEquip [18].SetActive (false);
								spEquip [19].SetActive (false);
								spEquip [20].SetActive (true);
								spEquip [21].SetActive (false);
								spEquip [22].SetActive (false);
						}

						// BuyTuxedo();
						#endregion
				} else if (control.name == "Button Buy Swat") {
						#region Buy Swat
						if (RamboState.clothes_buy [11] == 0) {
								if (RamboState.check_unlock_clothes [8] == 1 || RamboState.state_level1 [29] > 0 || RamboState.state_level2 [29] > 0 || RamboState.state_level3 [29] > 0) {
										//OpenIAB.purchaseProduct (OpenIABTest.BUYCLOTHERS4);
										if (RamboState.dola >= 55000) {
												RamboState.clothes_buy [11] = 1;
												PlayerPrefs.SetInt ("clotherBuy" + 11, 1);
												mt_rambo.SetTexture (0, clothes [11]);
												RamboState.dola -= 55000;
												btnBuySwat.Text = "EQUIP";
										} else {
												naptien ();
					
										}
								} else {
										GameObject.Find ("Unlockgun").GetComponent<dfTweenVector3> ().Play ();
										GameObject.Find ("textunlock").GetComponent<dfLabel> ().Text = "Unlock at chapter 4";
										GameObject.Find ("Camera 3D").GetComponent<Camera> ().enabled = false;
										RamboState.state_unlock = 16;
					
								}
						} else if (RamboState.clothes_buy [11] == 1) {
								RamboState.state_clothes = 11;
								labelNameOfClothers.Text = RamboState.swat;
								mt_rambo.SetTexture (0, clothes [11]);
								spEquip [10].SetActive (false);
								spEquip [11].SetActive (false);
								spEquip [12].SetActive (false);
								spEquip [13].SetActive (false);
								spEquip [14].SetActive (false);
								spEquip [15].SetActive (false);
								spEquip [16].SetActive (false);
								spEquip [17].SetActive (false);
								spEquip [18].SetActive (false);
								spEquip [19].SetActive (false);
								spEquip [20].SetActive (false);
								spEquip [21].SetActive (true);
								spEquip [22].SetActive (false);
						}


		
						//  BuySwat();
						#endregion
				} else if (control.name == "Button Buy Santa") {
						#region Buy Swat
						if (RamboState.clothes_buy [12] == 0) {
                if (RamboState.dola >= 5000)
                {
                    RamboState.dola -= 5000;
                    RamboState.clothes_buy[12] = 1;
                    PlayerPrefs.SetInt("clotherBuy" + 12, 1);
                    control.GetComponent<dfButton>().Text = "EQUIP";
                }
                else
                {
                    naptien();
                }
               
                //if (GameObject.Find("Button Buy Santa") != null)
                //{
                //    GameObject.Find("Button Buy Santa").GetComponent<dfButton>().Text = "EQUIP";
                //}

            } else if (RamboState.clothes_buy [12] == 1) {
								RamboState.state_clothes = 12;
								labelNameOfClothers.Text = "Santa";
								mt_rambo.SetTexture (0, clothes [12]);
								spEquip [10].SetActive (false);
								spEquip [11].SetActive (false);
								spEquip [12].SetActive (false);
								spEquip [13].SetActive (false);
								spEquip [14].SetActive (false);
								spEquip [15].SetActive (false);
								spEquip [16].SetActive (false);
								spEquip [17].SetActive (false);
								spEquip [18].SetActive (false);
								spEquip [19].SetActive (false);
								spEquip [20].SetActive (false);
								spEquip [21].SetActive (false);
								spEquip [22].SetActive (true);
						}
			
			
			
						//  BuySwat();
						#endregion
				}
		}
    #endregion

    #region View Clothers
		public void ViewClothers (dfControl control, dfMouseEventArgs mouseEvent)
		{       // xem quan ao
				GameObject.Find ("Click").GetComponent<SoundClick> ().play ();
				if (control.name == "Panel 0") {
						#region View Sport
						panelSport.BackgroundSprite = "bb_equipped";
						panelCowboy.BackgroundSprite = "bb_unequip_2";
						panelMer.BackgroundSprite = "bb_unequip_2";
						panelLuigi.BackgroundSprite = "bb_unequip_2";
						panelGangster.BackgroundSprite = "bb_unequip_2";
						panelAgent.BackgroundSprite = "bb_unequip_2";
						panelMario.BackgroundSprite = "bb_unequip_2";
						panelPijama.BackgroundSprite = "bb_unequip_2";
						panelMar.BackgroundSprite = "bb_unequip_2";
						panelSolider.BackgroundSprite = "bb_unequip_2";
						panelTuxedo.BackgroundSprite = "bb_unequip_2";
						panelSwat.BackgroundSprite = "bb_unequip_2";
						panelSanta.BackgroundSprite = "bb_unequip_2";

						labelNameOfClothers.Text = RamboState.sport;
						spEquip [10].SetActive (true);
						spEquip [11].SetActive (false);
						spEquip [12].SetActive (false);
						spEquip [13].SetActive (false);
						spEquip [14].SetActive (false);
						spEquip [15].SetActive (false);
						spEquip [16].SetActive (false);
						spEquip [17].SetActive (false);
						spEquip [18].SetActive (false);
						spEquip [19].SetActive (false);
						spEquip [20].SetActive (false);
						spEquip [21].SetActive (false);
						spEquip [22].SetActive (false);

						RamboState.state_sung = 0;
						mt_rambo.SetTexture (0, clothes [0]);
						#endregion
				} else if (control.name == "Panel 1") {


			 
						#region View Cowboy
						if (RamboState.huongdan_fashion == 0 && RamboState.level == 4 && GameObject.Find ("TutorialFashion").GetComponent<TutorialShopFashion> ().state == 1)
								GameObject.Find ("TutorialFashion").GetComponent<TutorialShopFashion> ().state = 2;
			   
						panelSport.BackgroundSprite = "bb_unequip_2";
						panelCowboy.BackgroundSprite = "bb_equipped";
						panelMer.BackgroundSprite = "bb_unequip_2";
						panelLuigi.BackgroundSprite = "bb_unequip_2";
						panelGangster.BackgroundSprite = "bb_unequip_2";
						panelAgent.BackgroundSprite = "bb_unequip_2";
						panelMario.BackgroundSprite = "bb_unequip_2";
						panelPijama.BackgroundSprite = "bb_unequip_2";
						panelMar.BackgroundSprite = "bb_unequip_2";
						panelSolider.BackgroundSprite = "bb_unequip_2";
						panelTuxedo.BackgroundSprite = "bb_unequip_2";
						panelSwat.BackgroundSprite = "bb_unequip_2";
						panelSanta.BackgroundSprite = "bb_unequip_2";

						if (RamboState.clothes_buy [1] == 0) {
								labelNameOfClothers.Text = RamboState.cowboy;
								mt_rambo.SetTexture (0, clothes [1]);

						} else if (RamboState.clothes_buy [1] == 1) {
								labelNameOfClothers.Text = RamboState.cowboy;
								spEquip [10].SetActive (false);
								spEquip [11].SetActive (true);
								spEquip [12].SetActive (false);
								spEquip [13].SetActive (false);
								spEquip [14].SetActive (false);
								spEquip [15].SetActive (false);
								spEquip [16].SetActive (false);
								spEquip [17].SetActive (false);
								spEquip [18].SetActive (false);
								spEquip [19].SetActive (false);
								spEquip [20].SetActive (false);
								spEquip [21].SetActive (false);
								spEquip [22].SetActive (false);
								RamboState.state_clothes = 1;
								mt_rambo.SetTexture (0, clothes [1]);
						}
						#endregion
				} else if (control.name == "Panel 2") {
						#region View Mer
						panelSport.BackgroundSprite = "bb_unequip_2";
						panelCowboy.BackgroundSprite = "bb_unequip_2";
						panelMer.BackgroundSprite = "bb_equipped";
						panelLuigi.BackgroundSprite = "bb_unequip_2";
						panelGangster.BackgroundSprite = "bb_unequip_2";
						panelAgent.BackgroundSprite = "bb_unequip_2";
						panelMario.BackgroundSprite = "bb_unequip_2";
						panelPijama.BackgroundSprite = "bb_unequip_2";
						panelMar.BackgroundSprite = "bb_unequip_2";
						panelSolider.BackgroundSprite = "bb_unequip_2";
						panelTuxedo.BackgroundSprite = "bb_unequip_2";
						panelSwat.BackgroundSprite = "bb_unequip_2";
						panelSanta.BackgroundSprite = "bb_unequip_2";

						if (RamboState.clothes_buy [2] == 0) {
								labelNameOfClothers.Text = RamboState.mer;
								mt_rambo.SetTexture (0, clothes [2]);
						} else if (RamboState.clothes_buy [2] == 1) {
								labelNameOfClothers.Text = RamboState.mer;
								spEquip [10].SetActive (false);
								spEquip [11].SetActive (false);
								spEquip [12].SetActive (true);
								spEquip [13].SetActive (false);
								spEquip [14].SetActive (false);
								spEquip [15].SetActive (false);
								spEquip [16].SetActive (false);
								spEquip [17].SetActive (false);
								spEquip [18].SetActive (false);
								spEquip [19].SetActive (false);
								spEquip [20].SetActive (false);
								spEquip [21].SetActive (false);
								spEquip [22].SetActive (false);
								RamboState.state_clothes = 2;
								mt_rambo.SetTexture (0, clothes [2]);
						}
						#endregion
				} else if (control.name == "Panel 3") {
						#region View Luigi
						panelSport.BackgroundSprite = "bb_unequip_2";
						panelCowboy.BackgroundSprite = "bb_unequip_2";
						panelMer.BackgroundSprite = "bb_unequip_2";
						panelLuigi.BackgroundSprite = "bb_equipped";
						panelGangster.BackgroundSprite = "bb_unequip_2";
						panelAgent.BackgroundSprite = "bb_unequip_2";
						panelMario.BackgroundSprite = "bb_unequip_2";
						panelPijama.BackgroundSprite = "bb_unequip_2";
						panelMar.BackgroundSprite = "bb_unequip_2";
						panelSolider.BackgroundSprite = "bb_unequip_2";
						panelTuxedo.BackgroundSprite = "bb_unequip_2";
						panelSwat.BackgroundSprite = "bb_unequip_2";
						panelSanta.BackgroundSprite = "bb_unequip_2";

						if (RamboState.clothes_buy [3] == 0) {
								labelNameOfClothers.Text = RamboState.luigi;
								mt_rambo.SetTexture (0, clothes [3]);
						} else if (RamboState.clothes_buy [3] == 1) {
								labelNameOfClothers.Text = RamboState.luigi;
								spEquip [10].SetActive (false);
								spEquip [11].SetActive (false);
								spEquip [12].SetActive (false);
								spEquip [13].SetActive (true);
								spEquip [14].SetActive (false);
								spEquip [15].SetActive (false);
								spEquip [16].SetActive (false);
								spEquip [17].SetActive (false);
								spEquip [18].SetActive (false);
								spEquip [19].SetActive (false);
								spEquip [20].SetActive (false);
								spEquip [21].SetActive (false);
								spEquip [22].SetActive (false);
								RamboState.state_clothes = 3;
								mt_rambo.SetTexture (0, clothes [3]);
						}
						#endregion
				} else if (control.name == "Panel 4") {
						#region View Gangster
						panelSport.BackgroundSprite = "bb_unequip_2";
						panelCowboy.BackgroundSprite = "bb_unequip_2";
						panelMer.BackgroundSprite = "bb_unequip_2";
						panelLuigi.BackgroundSprite = "bb_unequip_2";
						panelGangster.BackgroundSprite = "bb_equipped";
						panelAgent.BackgroundSprite = "bb_unequip_2";
						panelMario.BackgroundSprite = "bb_unequip_2";
						panelPijama.BackgroundSprite = "bb_unequip_2";
						panelMar.BackgroundSprite = "bb_unequip_2";
						panelSolider.BackgroundSprite = "bb_unequip_2";
						panelTuxedo.BackgroundSprite = "bb_unequip_2";
						panelSwat.BackgroundSprite = "bb_unequip_2";
						panelSanta.BackgroundSprite = "bb_unequip_2";

						if (RamboState.clothes_buy [4] == 0) {
								labelNameOfClothers.Text = RamboState.gangster;
								mt_rambo.SetTexture (0, clothes [4]);
						} else if (RamboState.clothes_buy [4] == 1) {
								labelNameOfClothers.Text = RamboState.gangster;
								spEquip [10].SetActive (false);
								spEquip [11].SetActive (false);
								spEquip [12].SetActive (false);
								spEquip [13].SetActive (false);
								spEquip [14].SetActive (true);
								spEquip [15].SetActive (false);
								spEquip [16].SetActive (false);
								spEquip [17].SetActive (false);
								spEquip [18].SetActive (false);
								spEquip [19].SetActive (false);
								spEquip [20].SetActive (false);
								spEquip [21].SetActive (false);
								spEquip [22].SetActive (false);

								RamboState.state_clothes = 4;
								mt_rambo.SetTexture (0, clothes [4]);
						}
						#endregion
				} else if (control.name == "Panel 5") {
						#region View Agent
						panelSport.BackgroundSprite = "bb_unequip_2";
						panelCowboy.BackgroundSprite = "bb_unequip_2";
						panelMer.BackgroundSprite = "bb_unequip_2";
						panelLuigi.BackgroundSprite = "bb_unequip_2";
						panelGangster.BackgroundSprite = "bb_unequip_2";
						panelAgent.BackgroundSprite = "bb_equipped";
						panelMario.BackgroundSprite = "bb_unequip_2";
						panelPijama.BackgroundSprite = "bb_unequip_2";
						panelMar.BackgroundSprite = "bb_unequip_2";
						panelSolider.BackgroundSprite = "bb_unequip_2";
						panelTuxedo.BackgroundSprite = "bb_unequip_2";
						panelSwat.BackgroundSprite = "bb_unequip_2";
						panelSanta.BackgroundSprite = "bb_unequip_2";

						if (RamboState.clothes_buy [5] == 0) {
								labelNameOfClothers.Text = RamboState.agent;
								mt_rambo.SetTexture (0, clothes [5]);
						} else if (RamboState.clothes_buy [5] == 1) {
								labelNameOfClothers.Text = RamboState.agent;
								spEquip [10].SetActive (false);
								spEquip [11].SetActive (false);
								spEquip [12].SetActive (false);
								spEquip [13].SetActive (false);
								spEquip [14].SetActive (false);
								spEquip [15].SetActive (true);
								spEquip [16].SetActive (false);
								spEquip [17].SetActive (false);
								spEquip [18].SetActive (false);
								spEquip [19].SetActive (false);
								spEquip [20].SetActive (false);
								spEquip [21].SetActive (false);
								spEquip [22].SetActive (false);

								RamboState.state_clothes = 5;
								mt_rambo.SetTexture (0, clothes [5]);
						}
						#endregion
				} else if (control.name == "Panel 6") {
						#region View Mario
						panelSport.BackgroundSprite = "bb_unequip_2";
						panelCowboy.BackgroundSprite = "bb_unequip_2";
						panelMer.BackgroundSprite = "bb_unequip_2";
						panelLuigi.BackgroundSprite = "bb_unequip_2";
						panelGangster.BackgroundSprite = "bb_unequip_2";
						panelAgent.BackgroundSprite = "bb_unequip_2";
						panelMario.BackgroundSprite = "bb_equipped";
						panelPijama.BackgroundSprite = "bb_unequip_2";
						panelMar.BackgroundSprite = "bb_unequip_2";
						panelSolider.BackgroundSprite = "bb_unequip_2";
						panelTuxedo.BackgroundSprite = "bb_unequip_2";
						panelSwat.BackgroundSprite = "bb_unequip_2";
						panelSanta.BackgroundSprite = "bb_unequip_2";

						if (RamboState.clothes_buy [6] == 0) {
								labelNameOfClothers.Text = RamboState.mario;
								mt_rambo.SetTexture (0, clothes [6]);
						} else if (RamboState.clothes_buy [6] == 1) {
								labelNameOfClothers.Text = RamboState.mario;
								spEquip [10].SetActive (false);
								spEquip [11].SetActive (false);
								spEquip [12].SetActive (false);
								spEquip [13].SetActive (false);
								spEquip [14].SetActive (false);
								spEquip [15].SetActive (false);
								spEquip [16].SetActive (true);
								spEquip [17].SetActive (false);
								spEquip [18].SetActive (false);
								spEquip [19].SetActive (false);
								spEquip [20].SetActive (false);
								spEquip [21].SetActive (false);
								spEquip [22].SetActive (false);

								RamboState.state_clothes = 6;
								mt_rambo.SetTexture (0, clothes [6]);
						}
						#endregion
				} else if (control.name == "Panel 7") {
						#region View Pijama
						panelSport.BackgroundSprite = "bb_unequip_2";
						panelCowboy.BackgroundSprite = "bb_unequip_2";
						panelMer.BackgroundSprite = "bb_unequip_2";
						panelLuigi.BackgroundSprite = "bb_unequip_2";
						panelGangster.BackgroundSprite = "bb_unequip_2";
						panelAgent.BackgroundSprite = "bb_unequip_2";
						panelMario.BackgroundSprite = "bb_unequip_2";
						panelPijama.BackgroundSprite = "bb_equipped";
						panelMar.BackgroundSprite = "bb_unequip_2";
						panelSolider.BackgroundSprite = "bb_unequip_2";
						panelTuxedo.BackgroundSprite = "bb_unequip_2";
						panelSwat.BackgroundSprite = "bb_unequip_2";
						panelSanta.BackgroundSprite = "bb_unequip_2";

						if (RamboState.clothes_buy [7] == 0) {
								labelNameOfClothers.Text = RamboState.pijama;
								mt_rambo.SetTexture (0, clothes [7]);
						} else if (RamboState.clothes_buy [7] == 1) {
								labelNameOfClothers.Text = RamboState.pijama;
								spEquip [10].SetActive (false);
								spEquip [11].SetActive (false);
								spEquip [12].SetActive (false);
								spEquip [13].SetActive (false);
								spEquip [14].SetActive (false);
								spEquip [15].SetActive (false);
								spEquip [16].SetActive (false);
								spEquip [17].SetActive (true);
								spEquip [18].SetActive (false);
								spEquip [19].SetActive (false);
								spEquip [20].SetActive (false);
								spEquip [21].SetActive (false);
								spEquip [22].SetActive (false);

								RamboState.state_clothes = 7;
								mt_rambo.SetTexture (0, clothes [7]);
						}
						#endregion
				} else if (control.name == "Panel 8") {
						#region View Mar
						panelSport.BackgroundSprite = "bb_unequip_2";
						panelCowboy.BackgroundSprite = "bb_unequip_2";
						panelMer.BackgroundSprite = "bb_unequip_2";
						panelLuigi.BackgroundSprite = "bb_unequip_2";
						panelGangster.BackgroundSprite = "bb_unequip_2";
						panelAgent.BackgroundSprite = "bb_unequip_2";
						panelMario.BackgroundSprite = "bb_unequip_2";
						panelPijama.BackgroundSprite = "bb_unequip_2";
						panelMar.BackgroundSprite = "bb_equipped";
						panelSolider.BackgroundSprite = "bb_unequip_2";
						panelTuxedo.BackgroundSprite = "bb_unequip_2";
						panelSwat.BackgroundSprite = "bb_unequip_2";
						panelSanta.BackgroundSprite = "bb_unequip_2";

						if (RamboState.clothes_buy [8] == 0) {
								labelNameOfClothers.Text = RamboState.mar;
								mt_rambo.SetTexture (0, clothes [8]);
						} else if (RamboState.clothes_buy [8] == 1) {
								spEquip [10].SetActive (false);
								spEquip [11].SetActive (false);
								spEquip [12].SetActive (false);
								spEquip [13].SetActive (false);
								spEquip [14].SetActive (false);
								spEquip [15].SetActive (false);
								spEquip [16].SetActive (false);
								spEquip [17].SetActive (false);
								spEquip [18].SetActive (true);
								spEquip [19].SetActive (false);
								spEquip [20].SetActive (false);
								spEquip [21].SetActive (false);
								spEquip [22].SetActive (false);
								labelNameOfClothers.Text = RamboState.mar;
								RamboState.state_clothes = 8;
								mt_rambo.SetTexture (0, clothes [8]);
						}
						#endregion
				} else if (control.name == "Panel 9") {
						#region View Solider
						panelSport.BackgroundSprite = "bb_unequip_2";
						panelCowboy.BackgroundSprite = "bb_unequip_2";
						panelMer.BackgroundSprite = "bb_unequip_2";
						panelLuigi.BackgroundSprite = "bb_unequip_2";
						panelGangster.BackgroundSprite = "bb_unequip_2";
						panelAgent.BackgroundSprite = "bb_unequip_2";
						panelMario.BackgroundSprite = "bb_unequip_2";
						panelPijama.BackgroundSprite = "bb_unequip_2";
						panelMar.BackgroundSprite = "bb_unequip_2";
						panelSolider.BackgroundSprite = "bb_equipped";
						panelTuxedo.BackgroundSprite = "bb_unequip_2";
						panelSwat.BackgroundSprite = "bb_unequip_2";
						panelSanta.BackgroundSprite = "bb_unequip_2";

						if (RamboState.clothes_buy [9] == 0) {
								labelNameOfClothers.Text = RamboState.solider;
								mt_rambo.SetTexture (0, clothes [9]);
						} else if (RamboState.clothes_buy [9] == 1) {
								spEquip [10].SetActive (false);
								spEquip [11].SetActive (false);
								spEquip [12].SetActive (false);
								spEquip [13].SetActive (false);
								spEquip [14].SetActive (false);
								spEquip [15].SetActive (false);
								spEquip [16].SetActive (false);
								spEquip [17].SetActive (false);
								spEquip [18].SetActive (false);
								spEquip [19].SetActive (true);
								spEquip [20].SetActive (false);
								spEquip [21].SetActive (false);
								spEquip [22].SetActive (false);
								labelNameOfClothers.Text = RamboState.solider;
								RamboState.state_clothes = 9;
								mt_rambo.SetTexture (0, clothes [9]);
						}
						#endregion
				} else if (control.name == "Panel 10") {
						#region View Tuxedo
						panelSport.BackgroundSprite = "bb_unequip_2";
						panelCowboy.BackgroundSprite = "bb_unequip_2";
						panelMer.BackgroundSprite = "bb_unequip_2";
						panelLuigi.BackgroundSprite = "bb_unequip_2";
						panelGangster.BackgroundSprite = "bb_unequip_2";
						panelAgent.BackgroundSprite = "bb_unequip_2";
						panelMario.BackgroundSprite = "bb_unequip_2";
						panelPijama.BackgroundSprite = "bb_unequip_2";
						panelMar.BackgroundSprite = "bb_unequip_2";
						panelSolider.BackgroundSprite = "bb_unequip_2";
						panelTuxedo.BackgroundSprite = "bb_equipped";
						panelSwat.BackgroundSprite = "bb_unequip_2";
						panelSanta.BackgroundSprite = "bb_unequip_2";

						if (RamboState.clothes_buy [10] == 0) {
								labelNameOfClothers.Text = RamboState.tuxedo;
								mt_rambo.SetTexture (0, clothes [10]);
						} else if (RamboState.clothes_buy [10] == 1) {
								spEquip [10].SetActive (false);
								spEquip [11].SetActive (false);
								spEquip [12].SetActive (false);
								spEquip [13].SetActive (false);
								spEquip [14].SetActive (false);
								spEquip [15].SetActive (false);
								spEquip [16].SetActive (false);
								spEquip [17].SetActive (false);
								spEquip [18].SetActive (false);
								spEquip [19].SetActive (false);
								spEquip [20].SetActive (true);
								spEquip [21].SetActive (false);
								spEquip [22].SetActive (false);
								labelNameOfClothers.Text = RamboState.tuxedo;
								RamboState.state_clothes = 10;
								mt_rambo.SetTexture (0, clothes [10]);
						}
						#endregion
				} else if (control.name == "Panel 11") {
						#region View Swat
						panelSport.BackgroundSprite = "bb_unequip_2";
						panelCowboy.BackgroundSprite = "bb_unequip_2";
						panelMer.BackgroundSprite = "bb_unequip_2";
						panelLuigi.BackgroundSprite = "bb_unequip_2";
						panelGangster.BackgroundSprite = "bb_unequip_2";
						panelAgent.BackgroundSprite = "bb_unequip_2";
						panelMario.BackgroundSprite = "bb_unequip_2";
						panelPijama.BackgroundSprite = "bb_unequip_2";
						panelMar.BackgroundSprite = "bb_unequip_2";
						panelSolider.BackgroundSprite = "bb_unequip_2";
						panelTuxedo.BackgroundSprite = "bb_unequip_2";
						panelSwat.BackgroundSprite = "bb_equipped";
						panelSanta.BackgroundSprite = "bb_unequip_2";

						if (RamboState.clothes_buy [11] == 0) {
								labelNameOfClothers.Text = RamboState.swat;
								mt_rambo.SetTexture (0, clothes [11]);
						} else if (RamboState.clothes_buy [11] == 1) {
								spEquip [10].SetActive (false);
								spEquip [11].SetActive (false);
								spEquip [12].SetActive (false);
								spEquip [13].SetActive (false);
								spEquip [14].SetActive (false);
								spEquip [15].SetActive (false);
								spEquip [16].SetActive (false);
								spEquip [17].SetActive (false);
								spEquip [18].SetActive (false);
								spEquip [19].SetActive (false);
								spEquip [20].SetActive (false);
								spEquip [21].SetActive (true);
								spEquip [22].SetActive (false);
								labelNameOfClothers.Text = RamboState.swat;
								RamboState.state_clothes = 11;
								mt_rambo.SetTexture (0, clothes [11]);
						}
						#endregion
				} else if (control.name == "Panel 12") {
						#region View Swat
						panelSport.BackgroundSprite = "bb_unequip_2";
						panelCowboy.BackgroundSprite = "bb_unequip_2";
						panelMer.BackgroundSprite = "bb_unequip_2";
						panelLuigi.BackgroundSprite = "bb_unequip_2";
						panelGangster.BackgroundSprite = "bb_unequip_2";
						panelAgent.BackgroundSprite = "bb_unequip_2";
						panelMario.BackgroundSprite = "bb_unequip_2";
						panelPijama.BackgroundSprite = "bb_unequip_2";
						panelMar.BackgroundSprite = "bb_unequip_2";
						panelSolider.BackgroundSprite = "bb_unequip_2";
						panelTuxedo.BackgroundSprite = "bb_unequip_2";
						panelSwat.BackgroundSprite = "bb_unequip_2";
						panelSanta.BackgroundSprite = "bb_equipped";
			
						if (RamboState.clothes_buy [12] == 0) {
								labelNameOfClothers.Text = "Santa";
								mt_rambo.SetTexture (0, clothes [12]);
						} else if (RamboState.clothes_buy [12] == 1) {
								spEquip [10].SetActive (false);
								spEquip [11].SetActive (false);
								spEquip [12].SetActive (false);
								spEquip [13].SetActive (false);
								spEquip [14].SetActive (false);
								spEquip [15].SetActive (false);
								spEquip [16].SetActive (false);
								spEquip [17].SetActive (false);
								spEquip [18].SetActive (false);
								spEquip [19].SetActive (false);
								spEquip [20].SetActive (false);
								spEquip [21].SetActive (false);
								spEquip [22].SetActive (true);
								labelNameOfClothers.Text = "Santa";
								RamboState.state_clothes = 12;
								mt_rambo.SetTexture (0, clothes [12]);
						}
						#endregion
				}
		}
    #endregion

    #region View Item
		public void ItemButtonClick ()
		{
				GameObject.Find ("Click").GetComponent<SoundClick> ().play ();
				for (int i = 0; i < items.Length; i++) {
						items [i].SetActive (false);
				}

				labelNameOfClothers.Text = "";
				labelName.Text = "";
				panelInfoItems.SetActive (true);
				Character.SetActive (false);
				panelFashion.SetActive (false);
				panelItems.SetActive (true);
				panelWeapon.SetActive (false);
				panelInfoGun.SetActive (false);
				btnItems.IsEnabled = false;
				btnFashion.IsEnabled = true;
				btnWeapon.IsEnabled = true;
				numberofbomb.Text = "x" + RamboState.number_grenede.ToString ();
				numberofshield.Text = "x" + RamboState.number_shield.ToString ();
				numberofthunder.Text = "x" + RamboState.number_vip.ToString ();
				//numberofheart.Text = "x" + RamboState.HP_RAMBO.ToString ();
				LoadInfo.SaveShop ();
		}
    #endregion

    #region Buy Items
		public void BuyItemsOnClick (dfControl control, dfMouseEventArgs mouseEvent)
		{
				GameObject.Find ("Click").GetComponent<SoundClick> ().play ();
				if (control.name == "Button Buy Bomb") {
						#region Buy Bomb
						if (RamboState.dola >= 300) {
								RamboState.dola -= 300;
								RamboState.number_grenede += 1;
								numberofbomb.Text = "x" + RamboState.number_grenede.ToString ();
						} else {
								naptien ();
						}
						#endregion
				} else if (control.name == "Button Buy Pistol Pack 1 ") {
						#region Buy Pistol Ammo Pack 1
						if (RamboState.dola >= 500) {
								RamboState.dola -= 500;
								RamboState.total_bullet_sungluc += 50;
						} else {
								naptien ();
						}
						#endregion
				} else if (control.name == "Button Buy Pistol Pack 2 ") {
						#region Buy Pistol Ammo Pack 2
						if (RamboState.dola >= 1000) {
								RamboState.dola -= 1000;
								RamboState.total_bullet_sungluc += 110;
						} else {
								naptien ();
						}
						#endregion
				} else if (control.name == "Button Buy Pistol Pack 3 ") {
						#region Buy Pistol Ammo Pack 3
						if (RamboState.dola >= 2000) {
								RamboState.dola -= 2000;
								RamboState.total_bullet_sungluc += 250;
						} else {
								naptien ();
						}
						#endregion
				} else if (control.name == "Button Buy Pistol Pack 4 ") {
						#region Buy Pistol Ammo Pack 4
						if (RamboState.dola >= 4000) {
								RamboState.dola -= 4000;
								RamboState.total_bullet_sungluc += 600;
						} else {
								naptien ();
						}
						#endregion
				} else if (control.name == "Button Buy Rifle Pack 1") {
						#region Buy Rifle Ammo Pack 1
						if (RamboState.dola >= 500) {
								RamboState.dola -= 500;
								RamboState.total_bullet_sungtia += 50;
						} else {
								naptien ();
						}
						#endregion
				} else if (control.name == "Button Buy Rifle Pack 2") {
						#region Buy Rifle Ammo Pack 2
						if (RamboState.dola >= 1000) {
								RamboState.dola -= 1000;
								RamboState.total_bullet_sungtia += 110;
						} else {
								naptien ();
						}
						#endregion
				} else if (control.name == "Button Buy Rifle Pack 3") {
						#region Buy Rifle Ammo Pack 3
						if (RamboState.dola >= 2000) {
								RamboState.dola -= 2000;
								RamboState.total_bullet_sungtia += 250;
						} else {
								naptien ();
						}
						#endregion
				} else if (control.name == "Button Buy Rifle Pack 4") {
						#region Buy Rifle Ammo Pack 4
						if (RamboState.dola >= 4000) {
								RamboState.dola -= 4000;
								RamboState.total_bullet_sungtia += 550;
						} else {
								naptien ();

						}
						#endregion
				} else if (control.name == "Button Buy Sniper Pack 1") {
						#region Buy Shotgun Ammo Pack 1
						if (RamboState.dola >= 1000) {
								RamboState.dola -= 1000;
								RamboState.total_bullet_sungngam += 15;
						} else {
								naptien ();
						}
						#endregion
				} else if (control.name == "Button Buy Sniper Pack 2") {
						#region Buy Shotgun Ammo Pack 1
						if (RamboState.dola >= 2000) {
								RamboState.dola -= 2000;
								RamboState.total_bullet_sungngam += 35;
						} else {
								naptien ();
						}
						#endregion
				} else if (control.name == "Button Buy Sniper Pack 3") {
						#region Buy Shotgun Ammo Pack 1
						if (RamboState.dola >= 4000) {
								RamboState.dola -= 4000;
								RamboState.total_bullet_sungngam += 80;
						} else {
								naptien ();
						}
						#endregion
				} else if (control.name == "Button Buy Sniper Pack 4") {
						#region Buy Shotgun Ammo Pack 1
						if (RamboState.dola >= 8000) {
								RamboState.dola -= 8000;
								RamboState.total_bullet_sungngam += 180;
						} else {
								naptien ();
						}
						#endregion
				} else if (control.name == "Button Buy Shotgun Pack 1") {
						#region Buy Shotgun Ammo Pack 1
						if (RamboState.dola >= 1000) {
								RamboState.dola -= 1000;
								RamboState.total_bullet_sungshotgun += 50;
						} else {
								naptien ();
						}
						#endregion
				} else if (control.name == "Button Buy Shotgun Pack 2") {
						#region Buy Shotgun Ammo Pack 2
						if (RamboState.dola >= 2000) {
								RamboState.dola -= 2000;
								RamboState.total_bullet_sungshotgun += 120;
						} else {
								naptien ();

						}
						#endregion
				} else if (control.name == "Button Buy Shotgun Pack 3") {
						#region Buy Shotgun Ammo Pack 3
						if (RamboState.dola >= 4000) {
								RamboState.dola -= 4000;
								RamboState.total_bullet_sungshotgun += 300;
						} else {
								naptien ();

						}
						#endregion
				} else if (control.name == "Button Buy Shotgun Pack 4") {
						#region Buy Shotgun Ammo Pack 4
						if (RamboState.dola >= 800) {
								RamboState.dola -= 8000;
								RamboState.total_bullet_sungshotgun += 700;
						} else {
								naptien ();

						}
						#endregion
				} else if (control.name == "Button Buy Rocket Pack 1") {
						#region Buy Bazooka Ammo Pack 1
						if (RamboState.dola >= 500) {
								RamboState.dola -= 500;
								RamboState.total_bullet_sung_tenlua += 5;
						} else {
								naptien ();

						}
						#endregion
				} else if (control.name == "Button Buy Rocket Pack 2") {
						#region Buy Bazooka Ammo Pack 2
						if (RamboState.dola >= 1000) {
								RamboState.dola -= 1000;
								RamboState.total_bullet_sung_tenlua += 11;
						} else {
								naptien ();

						}
						#endregion
				} else if (control.name == "Button Buy Rocket Pack 3") {
						#region Buy Bazooka Ammo Pack 3
						if (RamboState.dola >= 2000) {
								RamboState.dola -= 2000;
								RamboState.total_bullet_sung_tenlua += 24;
						} else {
								naptien ();

						}
						#endregion
				} else if (control.name == "Button Buy Rocket Pack 4") {
						#region Buy Bazooka Ammo Pack 4
						if (RamboState.dola >= 4000) {
								RamboState.dola -= 4000;
								RamboState.total_bullet_sung_tenlua += 55;
						} else {
								naptien ();
						}
						#endregion
				} else if (control.name == "Button Buy Shield Pack 1") {
						#region Buy Shield Pack 1
						if (RamboState.dola >= 5000) {
								RamboState.dola -= 5000;
								RamboState.number_shield += 1;
								numberofshield.Text = "x" + RamboState.number_shield.ToString ();
						} else {
								naptien ();

						}
						#endregion
				} else if (control.name == "Button Buy Shield Pack 2") {
						#region Buy Shield Pack 2
						if (RamboState.dola >= 20000) {
								RamboState.dola -= 20000;
								RamboState.number_shield += 5;
								numberofshield.Text = "x" + RamboState.number_shield.ToString ();
						} else {
								naptien ();

						}
						#endregion
				} else if (control.name == "Button Buy Shield Pack 3") {
						#region Buy Shield Pack 3
						if (RamboState.dola >= 40000) {
								RamboState.dola -= 40000;
								RamboState.number_shield += 9;
								numberofshield.Text = "x" + RamboState.number_shield.ToString ();
						} else {
								naptien ();
						}
						#endregion
				} else if (control.name == "Button Buy Shield Pack 4") {
						#region Buy Shield Pack 4
						if (RamboState.dola >= 100000) {
								RamboState.dola -= 100000;
								RamboState.number_shield += 25;
								numberofshield.Text = "x" + RamboState.number_shield.ToString ();
						} else {
								naptien ();
						}
						#endregion
				} else if (control.name == "Button Buy Thunder Pack 1") {
						#region Buy Thunder Pack 1
						if (RamboState.dola >= 5000) {
								RamboState.dola -= 5000;
								RamboState.number_vip += 1;
								numberofthunder.Text = "x" + RamboState.number_vip.ToString ();
						} else {
								naptien ();

						}
						#endregion
				} else if (control.name == "Button Buy Thunder Pack 2") {
						#region Buy Thunder Pack 2
						if (RamboState.dola >= 20000) {
								RamboState.dola -= 20000;
								RamboState.number_vip += 5;
								numberofthunder.Text = "x" + RamboState.number_vip.ToString ();
						} else {
								naptien ();

						}
						#endregion
				} else if (control.name == "Button Buy Thunder Pack 3") {
						#region Buy Thunder Pack 3
						if (RamboState.dola >= 40000) {
								RamboState.dola -= 40000;
								RamboState.number_vip += 10;
								numberofthunder.Text = "x" + RamboState.number_vip.ToString ();
						} else {
								naptien ();

						}
						#endregion
				} else if (control.name == "Button Buy Thunder Pack 4") {
						#region Buy Thunder Pack 4
						if (RamboState.dola >= 100000) {
								RamboState.dola -= 100000;
								RamboState.number_vip += 25;
								numberofthunder.Text = "x" + RamboState.number_vip.ToString ();
						} else {
								naptien ();

						}
						#endregion
				} else if (control.name == "Button Buy HP Pack 1") {
            #region Buy HP Pack 1
            if (RamboState.dola >= 1000)
            {
                RamboState.dola -= 1000;
                if (Application.loadedLevelName == "Gameplay")
                    RamboState.hp_rambo += 1;
                else {
                    RamboState.HP_RAMBO += 1;
                    PlayerPrefs.SetFloat("HP", RamboState.HP_RAMBO);
                }
            }
            else
            {
                naptien();
            }
            // Buy_HP_Pack1();
            #endregion
        } else if (control.name == "Button Buy HP Pack 2") {
            #region Buy HP Pack 2
            if (RamboState.dola >= 9500)
            {
                RamboState.dola -= 9500;
                if (Application.loadedLevelName == "Gameplay")
                    RamboState.hp_rambo += 10;
                else {
                    RamboState.HP_RAMBO += 10;
                    PlayerPrefs.SetFloat("HP", RamboState.HP_RAMBO);
                }
            }
            else
            {
                naptien();
            }
						#endregion
				} else if (control.name == "Button Buy HP Pack 3") {
            #region Buy HP Pack 3
            /// Buy_HP_Pack3();
            if (RamboState.dola >= 14000)
            {
                RamboState.dola -= 14000;
                if (Application.loadedLevelName == "Gameplay")
                    RamboState.hp_rambo += 15;
                else {
                    RamboState.HP_RAMBO += 15;
                    PlayerPrefs.SetFloat("HP", RamboState.HP_RAMBO);
                }
            }
            else
            {
                naptien();
            }
            #endregion
        } else if (control.name == "Button Buy HP Pack 4") {
            #region Buy HP Pack 4
            // Buy_HP_Pack4();
            if (RamboState.dola >= 22000)
            {
                RamboState.dola -= 22000;
                if (Application.loadedLevelName == "Gameplay")
                    RamboState.hp_rambo += 25;
                else {
                    RamboState.HP_RAMBO += 25;
                    PlayerPrefs.SetFloat("HP", RamboState.HP_RAMBO);
                }
            }
            else
            {
                naptien();
            }
            #endregion
        }
		}
    #endregion

    #region BuyAmmo
		public void BuyAmmo (dfControl control, dfMouseEventArgs mouseEvent)
		{       //mua dan
				GameObject.Find ("Click").GetComponent<SoundClick> ().play ();
				if (control.name == "Button Buy Ammo Pistol") {   
						#region Pistol
						if (RamboState.dola >= 500) {
								RamboState.total_bullet_sungluc += 50;
								RamboState.dola -= 500;
								lblNumberBulletOfPistol.Text = RamboState.total_bullet_sungluc.ToString ();
						} else {
								naptien ();


						}
						#endregion
				} else if (control.name == "Button Buy Ammo M3") {
						#region M3
						if (RamboState.dola >= 1000 || (RamboState.huongdanshop == 0 && GameObject.Find ("Tutorial").GetComponent<TutorialShop> ().state == 2)) {
								if (RamboState.huongdanshop == 0 && GameObject.Find ("Tutorial").GetComponent<TutorialShop> ().state == 2) {
										GameObject.Find ("Tutorial").GetComponent<TutorialShop> ().state = 3;
										
								} else {	
										if (RamboState.gun_buy [1] != 0) {
												RamboState.dola -= 1000;
												RamboState.total_bullet_sungshotgun += 50;                 
												lblNumberBulletOfM3.Text = RamboState.total_bullet_sungshotgun.ToString ();
										}
								}
						} else {


								if (RamboState.huongdanshop == 1)
										naptien ();


						}
						#endregion
				} else if (control.name == "Button Buy Ammo MP5") {
						#region MP5
						if (RamboState.check_unlock_gun [0] == 1 || RamboState.state_level1 [3] > 0 || RamboState.state_level2 [3] > 0 || RamboState.state_level3 [3] > 0) {  
								if (RamboState.dola >= 500) {
										if (RamboState.gun_buy [2] != 0) {
												RamboState.total_bullet_sungtia += 50;
												RamboState.dola -= 500;
												lblNumberBulletOfMP5.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfUZI.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfKISS.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfM4A1.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfSCAR.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfWA.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfVip1.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfVip2.Text = RamboState.total_bullet_sungtia.ToString ();
										} else {


										}
								} else {
										naptien ();
								}
						} else {
								GameObject.Find ("Unlockgun").GetComponent<dfTweenVector3> ().Play ();
								GameObject.Find ("textunlock").GetComponent<dfLabel> ().Text = "Unlock at level 5 chapter one";
								GameObject.Find ("Camera 3D").GetComponent<Camera> ().enabled = false;
								RamboState.state_unlock = 1;
				
						}
						#endregion
				} else if (control.name == "Button Buy Ammo UZI") {
						#region UZI
						if (RamboState.check_unlock_gun [0] == 1 || RamboState.state_level1 [5] > 0 || RamboState.state_level2 [5] > 0 || RamboState.state_level3 [5] > 0) {  
								if (RamboState.dola >= 500) {
										if (RamboState.gun_buy [3] != 0) {
												RamboState.total_bullet_sungtia += 50;
												RamboState.dola -= 500;
												lblNumberBulletOfMP5.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfUZI.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfKISS.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfM4A1.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfSCAR.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfWA.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfVip1.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfVip2.Text = RamboState.total_bullet_sungtia.ToString ();
										} else {

										}
								} else {
										naptien ();
								}
						} else {
								GameObject.Find ("Unlockgun").GetComponent<dfTweenVector3> ().Play ();
								GameObject.Find ("textunlock").GetComponent<dfLabel> ().Text = "Unlock at level 7 chapter one";
								GameObject.Find ("Camera 3D").GetComponent<Camera> ().enabled = false;
								RamboState.state_unlock = 1;
				
						}
						#endregion
				} else if (control.name == "Button Buy Ammo Kiss") {
						#region KISS
						if (RamboState.check_unlock_gun [1] == 1 || RamboState.state_level1 [9] > 0 || RamboState.state_level2 [9] > 0 || RamboState.state_level3 [9] > 0) {  
								if (RamboState.dola >= 500) {
										if (RamboState.gun_buy [4] != 0) {
												RamboState.total_bullet_sungtia += 50;
												RamboState.dola -= 500;
												lblNumberBulletOfMP5.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfUZI.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfKISS.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfM4A1.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfSCAR.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfWA.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfVip1.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfVip2.Text = RamboState.total_bullet_sungtia.ToString ();
										} else {

										}
								} else {
										naptien ();
								}
						} else {
								GameObject.Find ("Unlockgun").GetComponent<dfTweenVector3> ().Play ();
								GameObject.Find ("textunlock").GetComponent<dfLabel> ().Text = "Unlock at chapter 2";
								GameObject.Find ("Camera 3D").GetComponent<Camera> ().enabled = false;
								RamboState.state_unlock = 2;
				
						}
						#endregion
				} else if (control.name == "Button Buy Ammo M4A1") {
						#region M4A1
						if (RamboState.check_unlock_gun [1] == 1 || RamboState.state_level1 [9] > 0 || RamboState.state_level2 [9] > 0 || RamboState.state_level3 [9] > 0) {  
								if (RamboState.dola >= 500) {
										if (RamboState.gun_buy [5] != 0) {
												RamboState.total_bullet_sungtia += 50;
												RamboState.dola -= 500;
												lblNumberBulletOfMP5.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfUZI.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfKISS.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfM4A1.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfSCAR.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfWA.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfVip1.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfVip2.Text = RamboState.total_bullet_sungtia.ToString ();
										} else {

										}
								} else {
										naptien ();
								}
						} else {
								GameObject.Find ("Unlockgun").GetComponent<dfTweenVector3> ().Play ();
								GameObject.Find ("textunlock").GetComponent<dfLabel> ().Text = "Unlock at chapter 2";
								GameObject.Find ("Camera 3D").GetComponent<Camera> ().enabled = false;
								RamboState.state_unlock = 2;
				
						}
						#endregion
				} else if (control.name == "Button Buy Ammo Scar") {
						#region SCAR
						if (RamboState.check_unlock_gun [2] == 1 || RamboState.state_level1 [19] > 0 || RamboState.state_level2 [19] > 0 || RamboState.state_level3 [19] > 0) {  
								if (RamboState.dola >= 500) {
										if (RamboState.gun_buy [6] != 0) {
												RamboState.total_bullet_sungtia += 50;
												RamboState.dola -= 500;
												lblNumberBulletOfMP5.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfUZI.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfKISS.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfM4A1.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfSCAR.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfWA.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfVip1.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfVip2.Text = RamboState.total_bullet_sungtia.ToString ();
										} else { 


										}
								} else {
										naptien ();
								}
						} else {
								GameObject.Find ("Unlockgun").GetComponent<dfTweenVector3> ().Play ();
								GameObject.Find ("textunlock").GetComponent<dfLabel> ().Text = "Unlock at chapter 3";
								GameObject.Find ("Camera 3D").GetComponent<Camera> ().enabled = false;
								RamboState.state_unlock = 3;
						}
						#endregion
				} else if (control.name == "Button Buy Ammo AWP") {
						#region AWP
						if (RamboState.check_unlock_gun [2] == 1 || RamboState.state_level1 [19] > 0 || RamboState.state_level2 [19] > 0 || RamboState.state_level3 [19] > 0) {  
								if (RamboState.dola >= 1000) {
										if (RamboState.gun_buy [7] != 0) {
												RamboState.total_bullet_sungngam += 15;
												RamboState.dola -= 1000;
												lblNumberBulletOfAWP.Text = RamboState.total_bullet_sungngam.ToString ();
									
										} else {


										}
								} else {
										naptien ();
								}
						} else {
								GameObject.Find ("Unlockgun").GetComponent<dfTweenVector3> ().Play ();
								GameObject.Find ("textunlock").GetComponent<dfLabel> ().Text = "Unlock at chapter 3";
								GameObject.Find ("Camera 3D").GetComponent<Camera> ().enabled = false;
								RamboState.state_unlock = 3;
						}
						#endregion
				} else if (control.name == "Button Buy Ammo WA") {
						#region WA
						if (RamboState.check_unlock_gun [3] == 1 || RamboState.state_level1 [29] > 0 || RamboState.state_level2 [29] > 0 || RamboState.state_level3 [29] > 0) {  
								if (RamboState.dola >= 500) {
										if (RamboState.gun_buy [8] != 0) {
												RamboState.total_bullet_sungtia += 50;
												RamboState.dola -= 500;
												lblNumberBulletOfMP5.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfUZI.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfKISS.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfM4A1.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfSCAR.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfWA.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfVip1.Text = RamboState.total_bullet_sungtia.ToString ();
												lblNumberBulletOfVip2.Text = RamboState.total_bullet_sungtia.ToString ();
										} else { 


										}
								} else {
										naptien ();
								}
						} else {
								GameObject.Find ("Unlockgun").GetComponent<dfTweenVector3> ().Play ();
								GameObject.Find ("textunlock").GetComponent<dfLabel> ().Text = "Unlock at chapter 4";
								GameObject.Find ("Camera 3D").GetComponent<Camera> ().enabled = false;
								RamboState.state_unlock = 4;
						}
						#endregion
				} else if (control.name == "Button Buy Ammo Bazooka") {
						#region BAZOOKA

						if (RamboState.dola >= 500) {
								if (RamboState.gun_buy [9] == 1) {
										RamboState.total_bullet_sung_tenlua += 5;
										RamboState.dola -= 500;
										lblNumberBulletOfVip3.Text = RamboState.total_bullet_sung_tenlua.ToString ();
										lblNumberBulletOfBAZOOKA.Text = RamboState.total_bullet_sung_tenlua.ToString ();
								} else {



								}
						} else {
								naptien ();
						}
						
						#endregion
				} else if (control.name == "Button Buy Ammo Headsnake") {
						#region vip1
			
						if (RamboState.dola >= 500) {
								if (RamboState.gun_buy [10] == 1) {
										RamboState.total_bullet_sungtia += 50;
										RamboState.dola -= 500;
										lblNumberBulletOfMP5.Text = RamboState.total_bullet_sungtia.ToString ();
										lblNumberBulletOfUZI.Text = RamboState.total_bullet_sungtia.ToString ();
										lblNumberBulletOfKISS.Text = RamboState.total_bullet_sungtia.ToString ();
										lblNumberBulletOfM4A1.Text = RamboState.total_bullet_sungtia.ToString ();
										lblNumberBulletOfSCAR.Text = RamboState.total_bullet_sungtia.ToString ();
										lblNumberBulletOfWA.Text = RamboState.total_bullet_sungtia.ToString ();
										lblNumberBulletOfVip1.Text = RamboState.total_bullet_sungtia.ToString ();
										lblNumberBulletOfVip2.Text = RamboState.total_bullet_sungtia.ToString ();
								} else {
					
					
					
								}
						} else {
								naptien ();
						}
			
						#endregion
				} else if (control.name == "Button Buy Ammo Lineargun") {
						#region vip2
			
						if (RamboState.dola >= 500) {
								if (RamboState.gun_buy [11] == 1) {
										RamboState.total_bullet_sungtia += 50;
										RamboState.dola -= 500;
										lblNumberBulletOfMP5.Text = RamboState.total_bullet_sungtia.ToString ();
										lblNumberBulletOfUZI.Text = RamboState.total_bullet_sungtia.ToString ();
										lblNumberBulletOfKISS.Text = RamboState.total_bullet_sungtia.ToString ();
										lblNumberBulletOfM4A1.Text = RamboState.total_bullet_sungtia.ToString ();
										lblNumberBulletOfSCAR.Text = RamboState.total_bullet_sungtia.ToString ();
										lblNumberBulletOfWA.Text = RamboState.total_bullet_sungtia.ToString ();
										lblNumberBulletOfVip1.Text = RamboState.total_bullet_sungtia.ToString ();
										lblNumberBulletOfVip2.Text = RamboState.total_bullet_sungtia.ToString ();
								} else {
					
					
					
								}
						} else {
								naptien ();
						}
			
						#endregion
				} else if (control.name == "Button Buy Ammo Triomissiles") {
						#region BAZOOKA
			
						if (RamboState.dola >= 500) {
								if (RamboState.gun_buy [12] == 1) {
										RamboState.total_bullet_sung_tenlua += 15;
										RamboState.dola -= 500;
										lblNumberBulletOfVip3.Text = RamboState.total_bullet_sung_tenlua.ToString ();
										lblNumberBulletOfBAZOOKA.Text = RamboState.total_bullet_sung_tenlua.ToString ();
								} else {
					
					
					
								}
						} else {
								naptien ();
						}
			
						#endregion
				}

		}
    #endregion

		public void BackButtonClick ()
		{
				GameObject.Find ("Click").GetComponent<SoundClick> ().play ();
				AutoFade.LoadLevel ("ChooseMap", 0.8f, 0.8f, Color.black);
				LoadInfo.SaveShop ();

		}

		public void NextButtonClick ()
		{
				GameObject.Find ("Click").GetComponent<SoundClick> ().play ();
        //				if (RamboState.state_sung == 3 || RamboState.state_sung == 4 || RamboState.state_sung == 5 || RamboState.state_sung == 6) {
        //						if (RamboState.total_bullet_sungshotgun < 20) {
        //								GameObject.Find ("Thongbao").GetComponent<dfTweenVector3> ().Play ();
        //								check_thongbao = true;
        //								time_thongbao = 0;
        //						} else
        //								time_thongbao = 4;
        //			 
        //				} else
        //				if (RamboState.state_sung == 0 || RamboState.state_sung == 1 || RamboState.state_sung == 2) {
        //						
        //						time_thongbao = 4;
        //			
        //				} else
        //				if (RamboState.state_sung == 23 || RamboState.state_sung == 24 || RamboState.state_sung == 25) {
        //						if (RamboState.total_bullet_sungngam < 10) {
        //								GameObject.Find ("Thongbao").GetComponent<dfTweenVector3> ().Play ();
        //								check_thongbao = true;
        //								time_thongbao = 0;
        //						} else
        //								time_thongbao = 4;
        //			
        //			
        //				} else 
        //
        //		if (RamboState.state_sung == 29) {
        //						if (RamboState.total_bullet_sung_tenlua < 10) {
        //								GameObject.Find ("Thongbao").GetComponent<dfTweenVector3> ().Play ();
        //								check_thongbao = true;
        //								time_thongbao = 0;
        //						} else
        //								time_thongbao = 4;
        //			
        //			
        //				} else {
        //
        //						if (RamboState.total_bullet_sungtia < 20) {
        //								GameObject.Find ("Thongbao").GetComponent<dfTweenVector3> ().Play ();
        //								check_thongbao = true;
        //								time_thongbao = 0;
        //						} else
        //								time_thongbao = 4;
        //			
        //			
        //			
        //				}

        //if (RamboState.huongdanshop == 1) {
        //		if (RamboState.level == 4) {
        //				if (RamboState.huongdan_fashion == 1) {
        //						if (RamboState.level == 1) {
        //								AutoFade.LoadLevel ("Story", 0.8f, 0.8f, Color.black);
        //								RamboState.check_story = 1;
        //						} else if (RamboState.level == 11) {
        //								AutoFade.LoadLevel ("Story", 0.8f, 0.8f, Color.black);
        //								RamboState.check_story = 2;
        //						} else if (RamboState.level == 21) {
        //								AutoFade.LoadLevel ("Story", 0.8f, 0.8f, Color.black);
        //								RamboState.check_story = 3;
        //						} else if (RamboState.level == 31) {
        //								AutoFade.LoadLevel ("Story", 0.8f, 0.8f, Color.black);
        //								RamboState.check_story = 4;
        //						} else
        //								AutoFade.LoadLevel ("Loading", 0.8f, 0.8f, Color.black);
        //				}
        //		} else {
        LoadInfo.SaveShop();
        print("state sung: " + RamboState.state_sung + "___________________________");
        if (RamboState.level == 1) {
										AutoFade.LoadLevel ("Story", 0.8f, 0.8f, Color.black);
										RamboState.check_story = 1;
								} else if (RamboState.level == 11) {
										AutoFade.LoadLevel ("Story", 0.8f, 0.8f, Color.black);
										RamboState.check_story = 2;
								} else if (RamboState.level == 21) {
										AutoFade.LoadLevel ("Story", 0.8f, 0.8f, Color.black);
										RamboState.check_story = 3;
								} else if (RamboState.level == 31) {
										AutoFade.LoadLevel ("Story", 0.8f, 0.8f, Color.black);
										RamboState.check_story = 4;
								} else
										AutoFade.LoadLevel ("Loading", 0.8f, 0.8f, Color.black);



				//		}
				//}

		}

		void next ()
		{
				LoadInfo.SaveShop ();
				if (RamboState.huongdanshop == 1 && time_thongbao > 3) {	
						if (RamboState.level == 1) {
								AutoFade.LoadLevel ("Story", 0.8f, 0.8f, Color.black);
								RamboState.check_story = 1;
						} else if (RamboState.level == 11) {
								AutoFade.LoadLevel ("Story", 0.8f, 0.8f, Color.black);
								RamboState.check_story = 2;
						} else if (RamboState.level == 21) {
								AutoFade.LoadLevel ("Story", 0.8f, 0.8f, Color.black);
								RamboState.check_story = 3;
						} else if (RamboState.level == 31) {
								AutoFade.LoadLevel ("Story", 0.8f, 0.8f, Color.black);
								RamboState.check_story = 3;
						} else
								AutoFade.LoadLevel ("Loading", 0.8f, 0.8f, Color.black);
				}
		
		
		
		}
	
		public void buybazoka ()
		{
				
				items [gunIndex].SetActive (false);
				gunIndex = 29;
				items [gunIndex].SetActive (true);
				btnBuyBazooka.IsVisible = false;
				labelName.Text = RamboState.bazooka;
				RamboState.total_bullet_sung_tenlua += 5;
				lblNumberBulletOfBAZOOKA.Text = RamboState.total_bullet_sung_tenlua.ToString ();
				RamboState.gun_buy [9] = 1;
				PlayerPrefs.SetInt ("gunBuy" + 9, 1);
				PlayerPrefs.SetInt ("statesung", 29);
				iconBazooka.BackgroundSprite = "ss4";
				RamboState.state_sung = 29;
				spEquip [0].SetActive (false);
				spEquip [1].SetActive (false);
				spEquip [2].SetActive (false);
				spEquip [3].SetActive (false);
				spEquip [4].SetActive (false);
				spEquip [5].SetActive (false);
				spEquip [6].SetActive (false);
				spEquip [7].SetActive (false);
				spEquip [8].SetActive (false);
				spEquip [9].SetActive (true);

				DMG.Value = 1f;
				SPEED.Value = 0.2f;
				ACC.Value = 1f;
				CATRIDGE.Value = 0.2f;
				
		}

		public void BuyMarine ()
		{
				
        
				RamboState.clothes_buy [8] = 1;
				PlayerPrefs.SetInt ("clotherBuy" + 8, 1);
				mt_rambo.SetTexture (0, clothes [8]);
				RamboState.total_bullet_sung_tenlua += 100;
				btnBuyMar.Text = "EQUIP";
       
				
		}

		public void BuySolider ()
		{
				
      
				RamboState.clothes_buy [9] = 1;
				PlayerPrefs.SetInt ("clotherBuy" + 9, 1);
				mt_rambo.SetTexture (0, clothes [9]);
				RamboState.dola += 15000;
				btnBuySolider.Text = "EQUIP";
      
			
		}

		public void BuyTuxedo ()
		{
				
       
				RamboState.clothes_buy [10] = 1;
				PlayerPrefs.SetInt ("clotherBuy" + 10, 1);
				btnBuyTuxedo.Text = "EQUIP";
       
				
		}

		public void click_iab ()
		{
				GameObject.Find ("Click").GetComponent<SoundClick> ().play ();
				GameObject.Find ("IAB_dola").GetComponent<dfTweenVector3> ().Play ();
				GameObject.Find ("Camera 3D").GetComponent<Camera> ().enabled = false;
		}

		public void BuySwat ()
		{
				
      
				RamboState.clothes_buy [11] = 1;
				PlayerPrefs.SetInt ("clotherBuy" + 11, 1);
				mt_rambo.SetTexture (0, clothes [11]);
				RamboState.number_shield += 50;
				RamboState.number_vip += 50;
				btnBuySwat.Text = "EQUIP";
       
      
			
		}

		public void Buy_HP_Pack1 ()
		{
				RamboState.HP_RAMBO += 1;
		}

		public void Buy_HP_Pack2 ()
		{
				RamboState.HP_RAMBO += 10;
		}

		public void Buy_HP_Pack3 ()
		{
				RamboState.HP_RAMBO += 15;
		}

		public void Buy_HP_Pack4 ()
		{
				RamboState.HP_RAMBO += 25;
		}

		void chonsung6 ()
		{     
				check_chonsung = true;
				panelM3.BackgroundSprite = "bb_unequip";
				panelPistol.BackgroundSprite = "bb_unequip";
				panelMP5.BackgroundSprite = "bb_unequip";
				panelUZI.BackgroundSprite = "bb_unequip";
				panelKISS.BackgroundSprite = "bb_unequip";
				panelAWP.BackgroundSprite = "bb_unequip";
				panelSCAR.BackgroundSprite = "bb_equip";
				panelWA.BackgroundSprite = "bb_unequip";
				panelBazooka.BackgroundSprite = "bb_unequip";
				panelM4A1.BackgroundSprite = "bb_unequip";
				for (int i = 0; i < items.Length; i++) {
						if (i == 19 || i == 20 || i == 21 || i == 22) {
								if (RamboState.state_sung == 19 || RamboState.state_sung == 20 || RamboState.state_sung == 21 || RamboState.state_sung == 22)
										items [RamboState.state_sung].SetActive (true);
						} else {
								items [i].SetActive (false);
						}
				}
				if (RamboState.gun_buy [6] == 0) {
						lblUpdateScar.Text = "7.500";
						labelName.Text = RamboState.scar_lv1;
			
						DMG.Value = 0.6f;
						SPEED.Value = 0.6f;
						ACC.Value = 0.2f;
						CATRIDGE.Value = 0.2f;
			
						chiso1 = 0;
						chiso2 = 0;
						chiso3 = 0;
						chiso4 = 0;
						for (int i = 0; i < items.Length; i++) {
								if (i == 19)
										items [i].SetActive (true);
								else
										items [i].SetActive (false);
						}
				} else if (RamboState.gun_buy [6] == 1) {
						spEquip [0].SetActive (false);
						spEquip [1].SetActive (false);
						spEquip [2].SetActive (false);
						spEquip [3].SetActive (false);
						spEquip [4].SetActive (false);
						spEquip [5].SetActive (false);
						spEquip [6].SetActive (true);
						spEquip [7].SetActive (false);
						spEquip [8].SetActive (false);
						spEquip [9].SetActive (false);
			
						DMG.Value = 0.6f;
						SPEED.Value = 0.6f;
						ACC.Value = 0.2f;
						CATRIDGE.Value = 0.2f;
						chiso1 = 0;
						chiso2 = 2;
						chiso3 = 0;
						chiso4 = 0;
			
						lblUpdateScar.Text = "1.000";
						labelName.Text = RamboState.scar_lv1;
						btnBuyScar.Text = "UPGRADE";
						items [19].SetActive (true);
						items [20].SetActive (false);
						items [21].SetActive (false);
						items [22].SetActive (false);
						RamboState.state_sung = 19;
				} else if (RamboState.gun_buy [6] == 2) {
						spEquip [0].SetActive (false);
						spEquip [1].SetActive (false);
						spEquip [2].SetActive (false);
						spEquip [3].SetActive (false);
						spEquip [4].SetActive (false);
						spEquip [5].SetActive (false);
						spEquip [6].SetActive (true);
						spEquip [7].SetActive (false);
						spEquip [8].SetActive (false);
						spEquip [9].SetActive (false);
			
						DMG.Value = 0.6f;
						SPEED.Value = 0.8f;
						ACC.Value = 0.2f;
						CATRIDGE.Value = 0.2f;
			
						lblUpdateScar.Text = "2.000";
						labelName.Text = RamboState.scar_lv2;
						iconScar.BackgroundSprite = "ss2";
						scar_lv.BackgroundSprite = "Rifle_Scar_2";
						btnBuyScar.Text = "UPGRADE";
						items [19].SetActive (false);
						items [20].SetActive (true);
						items [21].SetActive (false);
						items [22].SetActive (false);
						RamboState.state_sung = 20;
				} else if (RamboState.gun_buy [6] == 3) {
						spEquip [0].SetActive (false);
						spEquip [1].SetActive (false);
						spEquip [2].SetActive (false);
						spEquip [3].SetActive (false);
						spEquip [4].SetActive (false);
						spEquip [5].SetActive (false);
						spEquip [6].SetActive (true);
						spEquip [7].SetActive (false);
						spEquip [8].SetActive (false);
						spEquip [9].SetActive (false);
			
						DMG.Value = 0.6f;
						SPEED.Value = 0.8f;
						ACC.Value = 0.4f;
						CATRIDGE.Value = 0.2f;
						chiso1 = 0;
						chiso2 = 0;
						chiso3 = 2;
						chiso4 = 0;
			
						lblUpdateScar.Text = "3.000";
						labelName.Text = RamboState.scar_lv3;
						iconScar.BackgroundSprite = "ss3";
						scar_lv.BackgroundSprite = "Rifle_Scar_3";
						btnBuyScar.Text = "UPGRADE";
						items [19].SetActive (false);
						items [20].SetActive (false);
						items [21].SetActive (true);
						items [22].SetActive (false);
						RamboState.state_sung = 21;
				} else if (RamboState.gun_buy [6] == 4) {
						spEquip [0].SetActive (false);
						spEquip [1].SetActive (false);
						spEquip [2].SetActive (false);
						spEquip [3].SetActive (false);
						spEquip [4].SetActive (false);
						spEquip [5].SetActive (false);
						spEquip [6].SetActive (true);
						spEquip [7].SetActive (false);
						spEquip [8].SetActive (false);
						spEquip [9].SetActive (false);
			
						DMG.Value = 0.6f;
						SPEED.Value = 0.8f;
						ACC.Value = 0.6f;
						CATRIDGE.Value = 0.2f;
						chiso1 = 0;
						chiso2 = 0;
						chiso3 = 0;
						chiso4 = 0;
			
						lblUpdateScar.Text = "";
						labelName.Text = RamboState.scar_lv4;
						iconScar.BackgroundSprite = "ss4";
						scar_lv.BackgroundSprite = "Rifle_Scar_4";
						btnBuyScar.IsVisible = false;
						items [19].SetActive (false);
						items [20].SetActive (false);
						items [21].SetActive (false);
						items [22].SetActive (true);
						RamboState.state_sung = 22;
				}



		}

		public void naptien ()
		{
	 
				GameObject.Find ("IAB_dola").GetComponent<dfTweenVector3> ().Play ();
				GameObject.Find ("Camera 3D").GetComponent<Camera> ().enabled = false;
		}



}