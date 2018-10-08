using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Controller : MonoBehaviour {
    [SerializeField] Text _title;
    [SerializeField] Text _titleGame;
    [SerializeField] Image _banner;
    [SerializeField] Button _btnGame1;
    [SerializeField] Button _btnGame2;

    // Use this for initialization
    void Start () {
        _title.text = "Hello world!";
        Sequence sep = DOTween.Sequence();
        sep.Append(_btnGame1.transform.DOMove(_btnGame1.transform.position + new Vector3(0, 100, 0), 1.0f));
        sep.Append(_btnGame1.transform.DOMove(_btnGame1.transform.position, 1.0f));
        sep.SetLoops(-1);
        Sequence sep2 = DOTween.Sequence();
        sep2.Append(_btnGame2.transform.DOMove(_btnGame2.transform.position + new Vector3(0, 100, 0), 1.0f));
        sep2.Append(_btnGame2.transform.DOMove(_btnGame2.transform.position, 1.0f));
        sep2.SetLoops(-1);
    }
	
	// Update is called once per frame
	void Update () {

    }
    public void OnClicked()
    {
        _title.text = "Thank you.";
        Sequence sep = DOTween.Sequence();
        //_title.transform.DOJump(new Vector3(0, 0, 0), 1, 1, 1.0f);
        //_title.transform.DOJump(_title.transform.position, 100, 1, 1.0f);
        //_title.transform.DOScale(2.0f, 2.0f);

        //sep.Append(_title.transform.DOScale(0.5f, 2.0f)).SetEase(Ease.Linear);
        //sep.Append(_title.transform.DOScale(2f, 2.0f)).SetEase(Ease.Linear);
        //sep.Append(_title.transform.DOScale(1f, 2.0f)).SetEase(Ease.Linear);
        sep.Append(_title.DOColor(Color.red, 1.0f));
        sep.AppendCallback(ChangeTextHello);
        sep.Append(_title.DOColor(Color.yellow, 1.0f));
        sep.AppendCallback(ChangeTextThankYou);
        //sep.Append(_title.transform.DOMove(_title.transform.position + new Vector3(50, 100,0), 1.0f));
        //sep.Append(_title.transform.DOMove(_title.transform.position, 1.0f));
        sep.SetEase(Ease.Linear);
        sep.SetLoops(-1);
        _banner.color = Color.yellow;
    }
    void ChangeTextHello()
    {
        _title.text = "Hello!";
    }
    void ChangeTextThankYou()
    {
        _title.text = "Thank You!";
    }
    public void OnClickGame1()
    {
        Sequence sep = DOTween.Sequence();
        _titleGame.text = "Đã chọn lẩu gà đá.";
        sep.Append(_btnGame1.transform.DOMove(_btnGame1.transform.position + new Vector3(0, 100, 0), 1.0f));
        sep.Append(_btnGame1.transform.DOMove(_btnGame1.transform.position, 1.0f));
        sep.SetLoops(-1);

        // Load Scene
        SceneManager.LoadScene("GamePlay");
    }

    public void OnClickGame2()
    {
        _titleGame.text = "Đã chọn việc đi học";
    }
}
