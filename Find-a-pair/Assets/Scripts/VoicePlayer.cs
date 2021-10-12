using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoicePlayer : MonoBehaviour
{
    [SerializeField] private Tile _tile1;
    [SerializeField] private Tile _tile2;
    [SerializeField] private GenerateLevel _gn;
    [SerializeField] private int _countPair;
    [SerializeField] private bool _win;
    [SerializeField] private GameObject _winCanvas;

    void Update()
    {
        if (_win) _winCanvas.SetActive(true);
        else CheckVoice();
    }

    public void CheckVoice()
    {
        if (_gn.GetPair() - 1 == _countPair) _win = true;
        if(_tile1 != null && _tile2 != null && !_win)
        {
            if (_tile1.GetId() == _tile2.GetId())
            {
                _tile1 = null;
                _tile2 = null;
                _countPair++;
            }
            else
            {
                _tile1.IsUnlocked();
                _tile2.IsUnlocked();
                _tile1.DeselectTiles();
                _tile2.DeselectTiles();
                _tile1 = null;
                _tile2 = null;
            }
        }
    }

    public void SetTile1(Tile tile) => _tile1 = tile;
    public void SetTile2(Tile tile) => _tile2 = tile;
    public bool GetTile1()
    {
        return _tile1 == null;
    }
    public bool GetTile2()
    {
        return _tile2 == null;
    }
}
