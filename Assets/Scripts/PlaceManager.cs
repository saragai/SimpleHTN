using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceManager : MonoBehaviour
{
    public enum PLACE
    {
        Work,
        Shop,
        Eat,
    }

    [SerializeField] GameObject m_WorkPlace;
    [SerializeField] GameObject m_ShopPlace;
    [SerializeField] GameObject m_EatPlace;

    static PlaceManager ms_Instance;

    private void Awake()
    {
        if (ms_Instance != null && ms_Instance != this)
            Destroy(this);

        ms_Instance = this;
    }

    public static Vector2 GetPosition(PLACE place)
    {
        var instance = ms_Instance;
        if (instance == null)
            return Vector2.zero;

        switch (place)
        {
            case PLACE.Work:
                return instance.m_WorkPlace.transform.position;
            case PLACE.Shop:
                return instance.m_ShopPlace.transform.position;
            case PLACE.Eat:
                return instance.m_EatPlace.transform.position;
        }

        return Vector2.zero;
    }
}
