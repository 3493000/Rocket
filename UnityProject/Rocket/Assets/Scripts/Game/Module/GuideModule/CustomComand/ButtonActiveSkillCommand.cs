using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hunter;

namespace Hunter
{
	public class ButtonActiveSkillCommand : ButtonCommand 
	{
		private string m_Key;
		
		public override void SetParam(object[] param)
		{
			base.SetParam(param);
			if(param.Length < 1)
			{
				return;
			}
			m_Key = param[1].ToString();
		}

		protected override void OnStart()
		{
			base.OnStart();

		}

		protected override void OnFinish(bool forceClean)
		{
			base.OnFinish(forceClean);
		}
	}
}