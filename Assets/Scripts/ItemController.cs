using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class ItemController : MonoBehaviour {

    [SerializeField] List<SpriteRenderer> items;
    float delay = 1f;
    private SpriteRenderer _renderer;

    // Use this for initialization
    void Start () {
        _renderer = this.GetComponent<SpriteRenderer>();
        Sequence sequence = DOTween.Sequence();
        sequence.AppendCallback(CreateItem);
        sequence.AppendInterval(delay);
        sequence.SetLoops(-1);
        sequence.SetTarget(this);
    }

    private void CreateItem()
    {
        SpriteRenderer CaTim = Instantiate(items[UnityEngine.Random.Range(0, 6)], this.transform);
        CaTim.gameObject.SetActive(true);
        float posX = UnityEngine.Random.Range(-6.0f, 6.0f);
        float posY = UnityEngine.Random.Range(6.0f, 7.0f);
        CaTim.transform.localPosition = new Vector3(posX, posY, 0);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
