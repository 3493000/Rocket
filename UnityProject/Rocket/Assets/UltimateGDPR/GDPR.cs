using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;
using Hunter;


namespace Hunter
{
    [Serializable]
    public class GeoData
    {
        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }
    }

    public class GDPR : MonoBehaviour
    {
        // IP verification service
        private const string CheckIpUrl = "http://ip-api.com/json";

        // Use for all users
        [Header("Show for all users")]
        [SerializeField] private bool useForAll;

        // Use the list of EU countries
        [Header("Use the list of European Union countries")]
        [SerializeField] private bool useECCountry;

        // List of EU countries
        private string[] _euCountryList = new string[]
        {
        //"US",
        "ES", "BE", "BG", "CZ", "DK", "DE", "EE", "IE", "EL", "ES", "FR", "HR", "IT", "CY", "LV", "LT", "LU", "HU", "MT", "NL", "AT", "PL", "PT", "RO", "SI", "SK", "FI", "SE", "UK"
        };
        [Header("Alternative list of countries")]
        [SerializeField] private string[] altCountryList;

        [Header("Link")] [SerializeField] private string privacyUrl, termsUrl;

        [SerializeField] private GameObject panelGDPR;

        private bool _accept;

        private const string KEY_SET_EUCONSENT = "set_euconsent";
        private const string KEY_SHOWPERSONALIZED_AD = "gdpr";

        private bool m_IsSetEUConsent;//欧洲地区权限是否设置


        private IEnumerator Start()
        {
            m_IsSetEUConsent = PlayerPrefs.GetInt(KEY_SET_EUCONSENT, 0) > 0;
            //AdsMgr.S.isShowPersonalizedAd = PlayerPrefs.GetInt(KEY_SHOWPERSONALIZED_AD, 0) == 0;
            if (!m_IsSetEUConsent)
            {
                UnityWebRequest www = UnityWebRequest.Get(CheckIpUrl);
                yield return www.SendWebRequest();

                GeoData geo = null;

                if (www.isNetworkError || www.isHttpError)
                {
                    Debug.Log(www.error);
                }
                else
                {
                    geo = JsonConvert.DeserializeObject<GeoData>(www.downloadHandler.text);
                    if (useForAll)
                    {
                        ShowGDPR();
                    }
                    else if (useECCountry & !useForAll)
                    {
                        for (int i = 0; i < _euCountryList.Length; i++)
                        {
                            if (geo.CountryCode == _euCountryList[i])
                            {
                                ShowGDPR();
                            }
                        }
                    }
                    else if (!useECCountry & !useForAll)
                    {
                        for (int i = 0; i < altCountryList.Length; i++)
                        {
                            if (geo.CountryCode == altCountryList[i])
                            {
                                ShowGDPR();
                            }
                        }
                    }
                }
                m_IsSetEUConsent = true;
                PlayerPrefs.SetInt(KEY_SET_EUCONSENT, 1);
                // AdsMgr.S.isShowPersonalizedAd = true;
            }


        }

        private void ShowGDPR()
        {
            _accept = Convert.ToBoolean(PlayerPrefs.GetFloat("gdpr"));

            if (!_accept)
                panelGDPR.SetActive(true);
        }

        public void Accept()
        {
            PlayerPrefs.SetInt("gdpr", 1);
            _accept = true;
            panelGDPR.SetActive(false);
            AdsMgr.S.isShowPersonalizedAd = true;
            PlayerPrefs.SetInt(KEY_SHOWPERSONALIZED_AD, 1);
        }

        public void Decline()
        {
            PlayerPrefs.SetInt("gdpr", 0);
            _accept = false;
            panelGDPR.SetActive(false);
            AdsMgr.S.isShowPersonalizedAd = false;
            PlayerPrefs.SetInt(KEY_SHOWPERSONALIZED_AD, 0);
        }

        public void OpenPrivacy()
        {
            Application.OpenURL(privacyUrl);
        }

        public void OpenTerms()
        {
            Application.OpenURL(termsUrl);
        }
    }
}

