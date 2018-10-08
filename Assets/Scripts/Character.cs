using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Character : MonoBehaviour {

    [SerializeField] List<Sprite> _sprites;

    private SpriteRenderer _renderer;
    private float delay = 0.1f;
    private bool IsWalking = false;

    // Use this for initialization
    void Start () {
        _renderer = this.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Walk(){
        if (IsWalking)
        {
            return;
        }
        IsWalking = true;
        Sequence sequence = DOTween.Sequence();
        sequence.AppendCallback(ChangeFrame1);
        sequence.AppendInterval(delay);
        sequence.AppendCallback(ChangeFrame2);
        sequence.AppendInterval(delay);
        sequence.AppendCallback(ChangeFrame3);
        sequence.AppendInterval(delay);
        sequence.AppendCallback(ChangeFrame4);
        sequence.AppendInterval(delay);
        sequence.SetLoops(-1);
        sequence.SetTarget(this);
    }

    public void Stop()
    {
        IsWalking = false;
        DOTween.Kill(this);
    }

    public void ChangeFrame1()
    {
        _renderer.sprite = _sprites[0];
    }

    public void ChangeFrame2()
    {
        _renderer.sprite = _sprites[1];
    }

    public void ChangeFrame3()
    {
        _renderer.sprite = _sprites[2];
    }

    public void ChangeFrame4()
    {
        _renderer.sprite = _sprites[3];
    }

}

