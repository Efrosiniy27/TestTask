using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class ConfigReader : MonoBehaviour
{
    public TextAsset _textAsset;
    private PT_XMLReader xmlr;
    // Start is called before the first frame update
    void Start()
    {
        xmlr = new PT_XMLReader();
        xmlr.Parse(_textAsset.text);
        PT_XMLHashList xBuilding = xmlr.xml["xml"][0]["building"];
        for (int i = 0; i < xBuilding.Count; i++)
        {
            BuildingDefinition buildingDefinition = new BuildingDefinition();
            buildingDefinition.id = int.Parse(xBuilding[i].att("id"), CultureInfo.InvariantCulture);
            buildingDefinition.name = xBuilding[i].att("name");
            buildingDefinition.pos.x = float.Parse(xBuilding[i].att("posx"), CultureInfo.InvariantCulture);
            buildingDefinition.pos.y = float.Parse(xBuilding[i].att("posy"), CultureInfo.InvariantCulture);
            buildingDefinition.sumMoney = float.Parse(xBuilding[i].att("sumMoney"), CultureInfo.InvariantCulture);
            buildingDefinition.sumFlat = float.Parse(xBuilding[i].att("sumFlat"), CultureInfo.InvariantCulture);
            buildingDefinition.typeBulding = ConvertStringToTypeBuilding(xBuilding[i].att("type"));
            Builder.S.Build(buildingDefinition);
        }

    }
    private TypeBuilding ConvertStringToTypeBuilding(string stype)
    {
        switch (stype)
        {
            case "Economy":return TypeBuilding.ECONOMY;
            case "Comfort":return TypeBuilding.COMFORT;
            default:return TypeBuilding.PREMIUM;
        }

    }
}
