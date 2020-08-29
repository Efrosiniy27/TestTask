using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Builder : MonoBehaviour
{
    static public Builder S;
    public GameObject _prefabBuilding;
    private List<Building> _buildings=new List<Building>();
    private void Awake()
    {
        S = this;
    }
    public void Build(BuildingDefinition def)
    {
        var tempBuildingGO = Instantiate<GameObject>(_prefabBuilding);
        var tempBuilding = tempBuildingGO.GetComponent<Building>();
        tempBuilding.SetDefinition(def);
        _buildings.Add(tempBuilding);
    }
    public void ShowAllSumMoney()
    {
        foreach (Building i in _buildings)
        {
            i.ShowSumMoney();
        }
    }
    public void ShowAllSumFlat()
    {
        foreach (Building i in _buildings)
        {
            i.ShowSumFlat();
        }
    }
    public void ShowOrHideBuildings(int type)
    {
        foreach (Building i in _buildings)
        {
            i.ShowOrHide((TypeBuilding)type);
        }
    }
    public void ToggleTumb(Toggle t)
    {
        
        if (t.isOn == true)
        {
            ShowAllSumFlat();
        }
        else
        {
            ShowAllSumMoney();
        }
    }
    public void Exit()
    {
        Application.Quit();
    }
}
