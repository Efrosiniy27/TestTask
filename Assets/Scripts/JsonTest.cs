using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JsonTest : MonoBehaviour
{
    public static JsonTest S;
    public TextAsset _text;
    public GameObject _prefabLinePolygon;
    public GameObject _LinePolygons;
    public List<List<GeoJSON.PositionObject>> _Pologons = new List<List<GeoJSON.PositionObject>>();
    // Start is called before the first frame update
    private void Awake()
    {
        S = this;
    }
    public void PaintPoligons()
    {
        foreach (var i in _Pologons)
        {
            var tempLinePolygon = Instantiate<GameObject>(_prefabLinePolygon);
            var tempLinePolygonLineRenderer = tempLinePolygon.GetComponent<LineRenderer>();
            tempLinePolygonLineRenderer.positionCount = i.Count;
            for (int j = 0; j < i.Count; j++)
            {
                tempLinePolygonLineRenderer.SetPosition(j, new Vector3(i[j].latitude, i[j].longitude, 0));
            }
            tempLinePolygon.transform.SetParent(_LinePolygons.transform);
        }
    }
}
