using UnityEngine;

public class Commands : MonoBehaviour {

    public UnitBluePrint standardUnit;
    
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }


    public void OpenBarrack()
    {
        Debug.Log("Barrack Opened");
        buildManager.SelectUnitToCreate(standardUnit);
    }

    public void OpenUpgrade()
    {
        Debug.Log("Upgrade Opened");
    }

    public void OpenStrategy()
    {
        Debug.Log("Strategy Opened");
    }

    public void OpenStorage()
    {
        Debug.Log("Storage Opened");
    }

    public void OpenGuide()
    {
        Debug.Log("Guide Opened");
    }
}
