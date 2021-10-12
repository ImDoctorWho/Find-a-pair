using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Sprite _randomSpriteFront;
    [SerializeField] private SpriteRenderer _front;
    [SerializeField] private Animator _tileAnim;
    [SerializeField] private bool _isLock;
    [SerializeField] private int _id = 0;
    [SerializeField] private VoicePlayer _player;
    private Coroutine _wait;

    public void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        _player = player.GetComponent<VoicePlayer>();
    }

    public void SelectTile()
    {
        if (!_isLock) _tileAnim.SetTrigger("Front");
    }
    
    public void DeselectTiles()
    {
        if (!_isLock && _wait == null)
        {
            _wait = StartCoroutine(WaitSeconds());
        }
    }

    public void OnMouseDown()
    {
        if (!_isLock)
        {
            if (_player.GetTile1()) _player.SetTile1(this);
            else if (_player.GetTile2()) _player.SetTile2(this);
            SelectTile();
            _isLock = true;
        }
    }

    public void IsUnlocked() => _isLock = false;
    public int GetId() => _id;
    public int SetId(int id) => _id = id;
    public Sprite GetRandomSprite() => _randomSpriteFront;
    public void SetRandomSprite(Sprite front)
    { 
        _randomSpriteFront = front;
        _front.sprite = _randomSpriteFront;
    }

    IEnumerator WaitSeconds()
    {
        Debug.Log("Start");
        yield return new WaitForSeconds(0.5f);
        _tileAnim.SetTrigger("Back");
        _wait = null;
    }
}
