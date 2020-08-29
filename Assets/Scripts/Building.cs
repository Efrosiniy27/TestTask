using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Building : MonoBehaviour
{
    
    public TextMesh _textSubMoney;
    public TextMesh _textSumFlat;
    public TextMesh _textName;

    private BuildingDefinition _def;
    private MeshRenderer _meshRenderer;
    private MeshFilter _meshFilter;
    private Transform _transform;
    private BoxCollider _boxCollider;
    private int[] _maxVerticals = new int[]{ 2, 3, 4, 5, 8, 9, 10, 11, 17, 18, 21, 22 };
    
    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshFilter = GetComponent<MeshFilter>();
        _transform = GetComponent<Transform>();
        _boxCollider = GetComponent<BoxCollider>();
    }
    public void SetDefinition(BuildingDefinition def)
    {
        _def = def;
        SetColor(_def.typeBulding);
        SetHeight(_def.sumMoney);
        _textSubMoney.text = _def.sumMoney.ToString();
        _textSumFlat.text = _def.sumFlat.ToString();
        _textName.text = _def.name;
        _transform.position = new Vector3(_def.pos.x, 0, _def.pos.y);
    }
    public void SetColor(TypeBuilding type)
    {
        int t = (int)type;
        _meshRenderer.material.color = new Vector4(0.33f * t,1-0.33f * t,1,1);
    }
    public void SetHeight(float value)
    {
        float heightBuilding = value / 4.0f;
        var tmesh = _meshFilter.mesh.vertices;
        foreach (var i in _maxVerticals)
        {
            tmesh[i].y = heightBuilding;
        }
        _meshFilter.mesh.SetVertices(tmesh);
        _textName.gameObject.transform.localPosition = new Vector3(0, 2.5f + heightBuilding, 0);
        _textSumFlat.gameObject.transform.localPosition = new Vector3(0, 1.2f + heightBuilding, 0);
        _textSubMoney.gameObject.transform.localPosition = new Vector3(0, 1.2f + heightBuilding, 0);
        _boxCollider.size = new Vector3(1, value / 2.0f, 1);
    }
    public void ShowSumMoney()
    {
        _textSubMoney.gameObject.SetActive(true);
        _textSumFlat.gameObject.SetActive(false);
        SetHeight(_def.sumMoney);
    }
    public void ShowSumFlat()
    {
        _textSubMoney.gameObject.SetActive(false);
        _textSumFlat.gameObject.SetActive(true);
        SetHeight(_def.sumFlat);
    }
    public void ShowOrHide(TypeBuilding type)
    {
        if (_def.typeBulding == type)
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }
    private void OnMouseEnter()
    {
        _textName.gameObject.SetActive(true);
    }
    private void OnMouseExit()
    {
        _textName.gameObject.SetActive(false);
    }
}
