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
        /// ó‘Ô‚ğw’è‚µ‚ÄAV‚½‚Èó‘Ô‚ğİ’è‚·‚é
        /// </summary>
        /// <param name="state">ó‘Ô</param>
        public void ApplyTo(WorldState state)
        {
            state.Set(m_Type, m_Value);
        }
    }
}
