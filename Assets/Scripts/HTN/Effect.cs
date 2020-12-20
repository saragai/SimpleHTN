using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HTN
{
    [System.Serializable]
    public class Effect
    {
        [SerializeField] WorldState.TYPE m_Type;
        [SerializeField] bool m_Value;

        /// <summary>
        /// ��Ԃ��w�肵�āA�V���ȏ�Ԃ�ݒ肷��
        /// </summary>
        /// <param name="state">���</param>
        public void ApplyTo(WorldState state)
        {
            state.Set(m_Type, m_Value);
        }
    }
}
