using System;
using GoogleMobileAds.Api;
using UnityEngine;

namespace AL.Monetization.CustomAdmobAds.Scripts
{
    public class RewardedAdController : AdController
    {
        
        public bool AdLoadedStatus;
        // Start is called before the first frame update
        public string adIdAndroid = "ca-app-pub-3940256099942544/5224354917";
        public string _adIdIOS = "ca-app-pub-3940256099942544/1712485313";
        private string _adUnitId;
        private RewardedAd _rewardedAd;
        private Action rewardAction;
        private void Awake()
        {
           
#if UNITY_ANDROID
            _adUnitId = adIdAndroid;
#elif UNITY_IPHONE
            _adUnitId = _adIdIOS;
#endif
        }
        // Start is called before the first frame update
        private void OnEnable()
        {
            LoadAd();
            base.OnEnable();
        }

        protected override void CheckAdLoad()
        {
            if (AdLoadedStatus)
            {
                return;
            }
            Debug.Log("moaaz");
            LoadAd();
            
        }
        public void LoadAd()
        {
            // Clean up the old ad before loading a new one.
            if (_rewardedAd != null)
            {
                DestroyAd();
            }
            Debug.Log("Loading rewarded ad.");

            // Create our request used to load the ad.
            var adRequest = new AdRequest();

            // Send the request to load the ad.
            RewardedAd.Load(_adUnitId, adRequest, (RewardedAd ad, LoadAdError error) =>
            {
                // If the operation failed with a reason.
                if (error != null)
                {
                    Debug.LogError("Rewarded ad failed to load an ad with error : " + error);
                    return;
                }
                // If the operation failed for unknown reasons.
                // This is an unexpected error, please report this bug if it happens.
                if (ad == null)
                {
                    Debug.LogError("Unexpected error: Rewarded load event fired with null ad and null error.");
                    return;
                }

                // The operation completed successfully.
                Debug.Log("Rewarded ad loaded with response : " + ad.GetResponseInfo());
                _rewardedAd = ad;

                // Register to ad events to extend functionality.
                RegisterEventHandlers(ad);

                // Inform the UI that the ad is ready.
                AdLoadedStatus=(true);
            });
        }
        public void ShowAd(Action rewardAction)
        {
            
            this.rewardAction = rewardAction;
            if (_rewardedAd != null && _rewardedAd.CanShowAd())
            {
                Debug.Log("AL Rewarded Video Showed");
                _rewardedAd.Show((Reward reward) =>
                {
                    Debug.Log(String.Format("Rewarded ad granted a reward: {0} {1}",
                        reward.Amount,
                        reward.Type));
                    rewardAction();
                });
            }
            else
            {
                Debug.LogError("Rewarded ad is not ready yet.");
                LoadAd();
            }

           
           
            
            // Inform the UI that the ad is not ready.
         
        }
        public void DestroyAd()
        {
            if (_rewardedAd != null)
            {
                Debug.Log("Destroying rewarded ad.");
                _rewardedAd.Destroy();
                _rewardedAd = null;
            }

            // Inform the UI that the ad is not ready.
            AdLoadedStatus=(false);
        }
        public void LogResponseInfo()
        {
            if (_rewardedAd != null)
            {
                var responseInfo = _rewardedAd.GetResponseInfo();
                UnityEngine.Debug.Log(responseInfo);
            }
        }
        private void RegisterEventHandlers(RewardedAd ad)
        {
            // Raised when the ad is estimated to have earned money.
            ad.OnAdPaid += (AdValue adValue) =>
            {
                Debug.Log(String.Format("Rewarded ad paid {0} {1}.",
                    adValue.Value,
                    adValue.CurrencyCode));
            };
            // Raised when an impression is recorded for an ad.
            ad.OnAdImpressionRecorded += () =>
            {
                Debug.Log("Rewarded ad recorded an impression.");
            };
            // Raised when a click is recorded for an ad.
            ad.OnAdClicked += () =>
            {
                Debug.Log("Rewarded ad was clicked.");
            };
            // Raised when the ad opened full screen content.
            ad.OnAdFullScreenContentOpened += () =>
            {
                Debug.Log("Rewarded ad full screen content opened.");
            };
            // Raised when the ad closed full screen content.
            ad.OnAdFullScreenContentClosed += () =>
            {
               
                LoadAd();
                Debug.Log("Rewarded ad full screen content closed.");
            };
            // Raised when the ad failed to open full screen content.
            ad.OnAdFullScreenContentFailed += (AdError error) =>
            {
                Debug.LogError("Rewarded ad failed to open full screen content with error : "
                               + error);
              
                LoadAd();
            };
        }
  
    }
}