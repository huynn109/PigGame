using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.UI;

public class Character : MonoBehaviour {

    [SerializeField] List<Sprite> _sprites;
    [SerializeField] Text _score;

    private SpriteRenderer _renderer;
    private float delay = 0.1f;
    private bool IsWalking = false;
    private int currentScore = 0;
    private State _State = State.NONE;
    enum State
    {
        NONE,
        STOP,
        WALK,
        DIE
    }

    // Use this for initialization
    void Start () {
        _renderer = this.GetComponent<SpriteRenderer>();
        _score.text = currentScore.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool isDied()
    {
        return _State == State.DIE;
    }

    public void Walk(){
        if (_State == State.WALK || _State == State.DIE)
        {
            return;
        }
        _State = State.WALK;
        Sequence sequence = DOTween.Sequence();
        sequence.AppendCallback(ChangeFrame1);
        sequence.AppendInterval(delay);
        sequence.AppendCallback(ChangeFrame2);
        sequence.AppendInterval(delay);
        sequence.AppendCallback(ChangeFrame3);
        sequence.AppendInterval(delay);
        sequence.AppendCallback(ChangeFrame4);
        sequence.AppendInterval(delay);
        sequence.AppendCallback(ChangeFrame5);
        sequence.AppendInterval(delay);
        sequence.AppendCallback(ChangeFrame6);
        sequence.AppendInterval(delay);
        sequence.SetLoops(-1);
        sequence.SetTarget(this);
    }

    public void Stop()
    {
        if(_State == State.STOP || _State == State.DIE)
        {
            return;
        }
        _State = State.STOP;
        DOTween.Kill(this);
    }

    public void Die()
    {
        if (_State == State.DIE)
        {
            return;
        }
        _State = State.DIE;
        DOTween.Kill(this);
        Sequence sequence = DOTween.Sequence();
        sequence.AppendCallback(ChangeFrame6);
        sequence.AppendInterval(delay);
        sequence.AppendCallback(ChangeFrame7);
        sequence.AppendInterval(delay);
       
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

    public void ChangeFrame5()
    {
        _renderer.sprite = _sprites[4];
    }

    public void ChangeFrame6()
    {
        _renderer.sprite = _sprites[5];
    }

    public void ChangeFrame7()
    {
        _renderer.sprite = _sprites[6];
    }

    public void ChangeFrame8()
    {
        _renderer.sprite = _sprites[7];
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        switch(collision.gameObject.tag){
            case "CaTim":
                currentScore += 5;        
                break;
            case "Bap":
                currentScore += 5;
                break;
            case "ProvimiBlue":
                currentScore += 5;
                break;
            case "Sub1":
                currentScore += 5;
                break;
            case "KhangSinh":
                Die();
                break;
        }
        Destroy(collision.gameObject);
        _score.text = currentScore.ToString();
    }

    internal void SetLive()
    {
        _State = State.NONE;
    }
}

