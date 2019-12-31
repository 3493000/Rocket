using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using GameObject = UnityEngine.GameObject;
using Hunter;

namespace Hunter
{
   
    public class EffectControl : TMonoSingleton<EffectControl>
    {

        //public const string Red_EXPLOSION1 = "RedExplosion";
        //public const string Purple_EXPLOSION1 = "PurpleExplosion";
        //public const string CORN_EXPLOSION1 = "CornExplosion";
        //public const string Green_EXPLOSION = "GreenExplosion";
        //public const string FISH = "FishSpawnGameobject";


        [SerializeField]
        private Transform m_EffectRoot;
        private ResLoader m_ResLoader;
        private List<string> m_EFJuiceNames;
        private List<string> m_EFSpargingNames;
        private List<string> m_EFClasticNames;
        
        private const string GOLDS_EFFECT = "GoldCoins";
        private const string DIAMONDS_EFFECT = "MagicGem";
        public void InitMgr()
        {
            m_ResLoader = ResLoader.Allocate("EffectControl");
           
            // GameObject ballp = m_ResLoader.LoadSync(BALL_PARTICLE) as GameObject;
            //GameObjectPoolMgr.S.AddPool("BallParticle", ballp, 15, 3);
            //GameObject purpleExplosion1 = m_ResLoader.LoadSync(Purple_EXPLOSION1) as GameObject;
            //GameObjectPoolMgr.S.AddPool("PurpleExplosion", purpleExplosion1, 40, 10);
            //GameObject greenExplosion = m_ResLoader.LoadSync(Green_EXPLOSION) as GameObject;
            //GameObjectPoolMgr.S.AddPool("GreenExplosion", greenExplosion, 200, 30);
            //GameObject redExplosion1 = m_ResLoader.LoadSync(Red_EXPLOSION1) as GameObject;
            //GameObjectPoolMgr.S.AddPool("RedExplosion", redExplosion1, 40, 10);
            //GameObject cornExplosion1 = m_ResLoader.LoadSync(CORN_EXPLOSION1) as GameObject;
            //GameObjectPoolMgr.S.AddPool("CornExplosion", cornExplosion1, 40, 10);
            //GameObject fishSpawnGameobject = m_ResLoader.LoadSync(FISH) as GameObject;
            //GameObjectPoolMgr.S.AddPool("FishSpawnGameobject", fishSpawnGameobject, 20,10);


            //GameObjectPoolMgr.S.AddPool("Eff_Click", m_ResLoader.LoadSync("Eff_Click") as GameObject, 20, 10);
        }




        protected void PlayParticleSystem(GameObject p, Vector3 position, Transform root)
        {         
            p.transform.SetParent(root);
            p.transform.position = position;
            p.SetActive(true);
            //p.transform.GetComponent<ParticleSystem>().Clear();
            //p.transform.GetComponent<ParticleSystem>().Play();
            ParticleSystem[] ps = p.GetComponentsInChildren<ParticleSystem>(true);
            for (int i = 0; i < ps.Length; i++)
            {
                ps[i].Clear();
                ps[i].Play();
            }
        }
        protected void PlayParticleSystem(GameObject p, Vector3 position, Vector3 rotation,Transform root)
        {
            p.transform.SetParent(root);
            p.transform.position = position;
            p.transform.eulerAngles = rotation;
            p.SetActive(true);
            //p.transform.GetComponent<ParticleSystem>().Clear();
            //p.transform.GetComponent<ParticleSystem>().Play();
            ParticleSystem[] ps = p.GetComponentsInChildren<ParticleSystem>(true);
            for (int i = 0; i < ps.Length; i++)
            {
                ps[i].Clear();
                ps[i].Play();
            }
        }
      
        protected void PlayParticleSystem(GameObject p, Transform root)
        {
            p.transform.SetParent(root);
            p.transform.position = root.position;
            ParticleSystem[] ps = p.GetComponentsInChildren<ParticleSystem>();
            for (int i = 0; i < ps.Length; i++)
            {
                ps[i].Clear();
                ps[i].Play();
            }
        }


        public void PlayEffect(Transform parentTrs, Vector3 localPosition, string effectname)
        {
            if (effectname == "0")
            {
                Debug.LogError(effectname + "is not Exist");
                return;
            }
            GameObject effObj = GameObjectPoolMgr.S.Allocate(effectname);
            if (!effObj.GetComponent<ParticleCtrller>())
            {
                effObj.AddComponent<ParticleCtrller>();
            }
            effObj.transform.SetParent(parentTrs);
            effObj.transform.localPosition = localPosition;
            effObj.transform.localScale = Vector3.one;
        }
       
        
    }
}
