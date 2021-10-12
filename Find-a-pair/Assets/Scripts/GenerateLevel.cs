using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    [SerializeField] private Sprite[] _frontSprites;
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private int _width, _height, _countPair;
    [SerializeField] private Tile[,] _map;
    [SerializeField] private int mapH, mapW;
    [SerializeField] private GameObject _voiceCanvas;
    [SerializeField] private Camera _mainCamera;


    public void GenerateTilesInLevel()
    {
        if(_width == 3) _mainCamera.orthographicSize = 3;
        if (_width == 4)
        {
            _mainCamera.transform.position = new Vector3(-0.45f, 0, -10);
            _mainCamera.orthographicSize = 4;
        }
        if (_width == 5) _mainCamera.orthographicSize = 5;
        int sizeHMax = 0, sizeVMax = 0, sizeHMin = 0, sizeVMin = 0;
        _voiceCanvas.SetActive(false);
        int sizeMap = _width * _height;
        _map = new Tile[_height, _width];

        if (sizeMap % 2 == 1) _countPair = (sizeMap / 2) + 1;
        else _countPair = sizeMap / 2;


        if(_width % 2 == 1)
        {
            sizeHMax = _width / 2;
            sizeHMin = -(_width / 2);
        }
        else
        {
            sizeHMax = (_width / 2) - 1;
            sizeHMin = -(_width / 2);
        }
        if (_height % 2 == 1)
        {
            sizeVMax = _height / 2;
            sizeVMin = -(_height / 2);
        }
        else
        {
            sizeVMax = (_height / 2) - 1;
            sizeVMin = -(_height / 2);
        }
        

        for(int i = sizeHMin; i <= sizeHMax; i++)
        {
            for (int j = sizeVMin; j <= sizeVMax; j++)
            {
                Tile tile = Instantiate(_tilePrefab, new Vector3(j, i, 0), Quaternion.Euler(0, 180, 0)).GetComponent<Tile>();
                _map[mapH, mapW] = tile;
                mapW++;
            }
            mapW = 0;
            mapH++;
        }

        SetSpriteInTiles();
    }

    public void SetSpriteInTiles()
    {
        int countNum = 0;
        int countSprite = 0;

        while (countSprite < _countPair)
        {
            if (CheckMap()) break;
            if (countNum == 2)
            {
                countNum = 0;
                countSprite++;
            }
            int i = Random.Range(0, _height);
            int j = Random.Range(0, _width);

            Debug.Log(i + " - " + j);

            if (_map[i, j].GetId() == 0)
            {
                _map[i, j].SetRandomSprite(_frontSprites[countSprite]);
                _map[i, j].SetId(countSprite + 1);
                countNum++;
            }
        }
    }

    public bool CheckMap()
    {
        int count = 0;
        for (int i = 0; i < _height; i++)
        {
            for (int j = 0; j < _width; j++)
            {
                if (_map[i, j].GetId() == 0) count++;
            }
        }
        if (count == 0) return true;
        else return false;
    }

    public void CheckGameTiles()
    {
        
    }

    public void SetHeight(int height) => _height = height;
    public void SetWidth(int width) => _width = width;
    public int GetPair() => _countPair;

    
}
