using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace HTN
{
    [System.Serializable]
    public class Condition
    {
        [SerializeField] WorldState.TYPE m_Type;
        [SerializeField] bool m_Value;

        /// <summary>
        /// ��Ԃ��w�肵�ď����𖞂��������f����
        /// </summary>
        /// <param name="state">���</param>
        /// <returns>�����𖞂�����</returns>
        public bool Match(WorldState state)
        {
            return state.Get(m_Type) == m_Value;
        }
    }
}
