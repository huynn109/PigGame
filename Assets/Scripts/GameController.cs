using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameController : MonoBehaviour {
    [SerializeField] Camera _cameraMC;
    [SerializeField] SpriteRenderer _MCPig;

    private bool isTouching = false;
    private bool isLeft = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0)) // Catch event touch down screen
        {
            isTouching = true;
            isLeft = Input.mousePosition.x < Mathf.Abs(Screen.width / 2);
        }

        if(Input.GetMouseButtonUp(0) && isTouching){
            isTouching = false;
            _MCPig.GetComponent<Character>().Stop();
        }

        if(isTouching){
            _MCPig.GetComponent<Character>().Walk();
            mousePig(isLeft);
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            isLeft = true;
            mousePig(isLeft);
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow)){
            isLeft = false;
            mousePig(isLeft);
        }
    }

    private void mousePig(bool toLeft){
        Vector3 touchPosWorld = _cameraMC.ScreenToWorldPoint(Input.mousePosition);
        Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);
        //if (!isInSideScreen(_MCPig.transform.localPosition)) return;
        if (toLeft){
            //if(isInSideScreen(_MCPig.transform.position)){
                _MCPig.flipX = true; // Lat nguoc
                                     //_MCPig.sprite = Resources.Load("char_walk_1_heo.png") as Sprite;
                _MCPig.transform.position += new Vector3(-0.1f, 0, 0);
            //}else{
            //    //_MCPig.flipX = true; // Lat nguoc
            //                         //_MCPig.sprite = Resources.Load("char_walk_1_heo.png") as Sprite;
            //    _MCPig.transform.position += new Vector3(0.1f, 0, 0);
            //}
        }else{
            //if(isInSideScreen(_MCPig.transform.position)){
                _MCPig.flipX = false;
                _MCPig.transform.position += new Vector3(0.1f, 0, 0);
            //}else{
            //    _MCPig.transform.position += new Vector3(-0.1f, 0, 0);
            //}
           
        }
    }

    private bool isInSideScreen(Vector3 pos){
        return pos.x >= -7 && pos.x <= 7;
    }

}
