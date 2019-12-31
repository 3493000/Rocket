using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hunter;

namespace Hunter
{
    public class MyShaderFinder : MonoBehaviour
    {
#if UNITY_EDITOR
        private Renderer m_Render;
        private void Start()
        {
            //return;
            m_Render = GetComponent<Renderer>();
            string name = m_Render.material.shader.name;
            if (m_Render.materials.Length > 1)
            {
                string name2 = m_Render.sharedMaterials[1].shader.name;
                m_Render.materials[1].shader = Shader.Find(name2);
            }
            m_Render.material.shader = Shader.Find(name);
        }

        /*
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                m_Render = GetComponent<Renderer>();
                string name = m_Render.material.shader.name;
                if (m_Render.materials.Length > 1)
                {
                    string name2 = m_Render.sharedMaterials[1].shader.name;
                    m_Render.materials[1].shader = Shader.Find(name2);
                }
                m_Render.material.shader = Shader.Find(name);
            }
        }
        */
#endif
    }
}
