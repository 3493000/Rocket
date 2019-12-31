using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hunter;
using System;

namespace Hunter{

	public class DataAnalyzeModule : TSingleton<DataAnalyzeModule>
	{
		                                       
		public const string DATA_RECORD_KEY_SIGN = "data_sign_record_key_0906_{0}";
		

		public override void OnSingletonInit()
		{
			Log.i("[DataAnalyzeModlue] : init");
		}

		public  void Init()
		{
			
		}

        private bool GetRecordSignByID(string signKey)
        {
			int sign = PlayerPrefs.GetInt(signKey,-1);
			
			if(sign == -1)
			{
				if(RandomHelper.Range(0,1000) >= 500)
				{
					PlayerPrefs.SetInt(signKey,1);
					
				}
				else
				{
					PlayerPrefs.SetInt(signKey,0);					
				}
			}
			else
			{
				return sign == 1;	
			} 
			sign = PlayerPrefs.GetInt(signKey,-1);
			return sign == 1;
        }

		public bool GetDataSignByID(int id)
		{
			string signKey = string.Format(DATA_RECORD_KEY_SIGN,id);

			return GetRecordSignByID(signKey);
		}


    }
}