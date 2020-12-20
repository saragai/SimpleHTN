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
        /// ó‘Ô‚ğw’è‚µ‚ÄğŒ‚ğ–‚½‚·‚©”»’f‚·‚é
        /// </summary>
        /// <param name="state">ó‘Ô</param>
        /// <returns>ğŒ‚ğ–‚½‚·‚©</returns>
        public bool Match(WorldState state)
        {
            return state.Get(m_Type) == m_Value;
        }
    }
}
