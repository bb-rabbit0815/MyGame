using System.Linq;
using Unity.Entities.UniversalDelegates;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class GameSystemMain : MonoBehaviour
{
    [SerializeField]
    ulong _time;
    [SerializeField]
    float _fund;
    [SerializeField]
    int _facilityCount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 初期化
        var slave = new Slave();
        var facility = new Facility();
        facility.AssgineSlave(slave);

        Brothel.OnAddNewGuest += _OnAddNewGuest;
        Brothel.Funds = 1000;
        Brothel.AddFacility(facility);
        Brothel.AddSlave(slave);

        var facilityView = GetComponent<FacilityView>();
        if (facilityView)
        {
            facilityView.Facility = facility;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Brothel.Update(1);
        _time = Brothel.GameCount;
        _fund = Brothel.Funds;
        _facilityCount = Brothel.Facilities.Count();
    }

    void OnDestroy()
    {
        Brothel.OnAddNewGuest -= _OnAddNewGuest;
    }

    void _OnAddNewGuest(Guest guest)
    {
        Debug.Log(guest.GuestId.ToString());
    }
}
