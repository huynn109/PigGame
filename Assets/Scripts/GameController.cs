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
    KeyboardController controller;
    // Use this for initialization
    void Start () {
        controller = new KeyboardController();
        controller.KeyboardEvent += HandleKeyboardEvent;
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



        //if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    if (Input.GetKeyDown(KeyCode.RightArrow))
        //    {
        //        isLeft = false;
        //    }
        //    else if (Input.GetKeyDown(KeyCode.LeftArrow))
        //    {
        //        isLeft = true;
        //    }
        //    isTouching = true;
        //}

        //if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) && isTouching)
        //{
        //    isTouching = false;
        //    _MCPig.GetComponent<Character>().Stop();
        //}

        if (null != controller.GetType())
        {
            controller.handleKeypress();
            if (controller.isKeyDown("UP"))
                mousePig(0, 0.1F);
            if (controller.isKeyDown("RIGHT"))
                mousePig(1, 0.1F);
            if (controller.isKeyDown("DOWN"))
                mousePig(2, 0.1F);
            if (controller.isKeyDown("LEFT"))
                mousePig(3, 0.1F);
            
        }
        if(controller.areKeysDown())
        {
            _MCPig.GetComponent<Character>().Walk();
        }
        else
        {
            _MCPig.GetComponent<Character>().Stop();
        }

        //if (isTouching)
        //{
        //    _MCPig.GetComponent<Character>().Walk();
        //    //mousePig(false);
        //}

    }

    
    public void HandleKeyboardEvent(string key, string action)
    {
        Debug.Log("Handling a Keyboard Event (key: " + key + ", action: " + action);
        switch (key)
        {
            case "left":
                Debug.Log("Go Left");
                break;
            case "right":
                Debug.Log("Go Right");
                break;
        }
    }

    private void mousePig(int direction, float speed=1.0F)
    {
        var momentum = Vector3.right;
        bool isFlipx = false;
        switch (direction)
        {
            case 0:
                momentum = Vector3.up;
                break;
            case 1:
                momentum = Vector3.right;
                isFlipx = false;
                break;
            case 2:
                momentum = Vector3.down;
                break;
            case 3:
                momentum = Vector3.left;
                isFlipx = true;
                break;
        }
        _MCPig.flipX = isFlipx;
        _MCPig.transform.Translate(momentum * speed, Space.Self);
        Vector3 touchPosWorld = _cameraMC.ScreenToWorldPoint(Input.mousePosition);
        Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);
        //if (!isInSideScreen(_MCPig.transform.localPosition)) return;
        //if (toLeft){
        //    //if(isInSideScreen(_MCPig.transform.position)){
        //        _MCPig.flipX = true; // Lat nguoc
        //                             //_MCPig.sprite = Resources.Load("char_walk_1_heo.png") as Sprite;
        //        _MCPig.transform.position += new Vector3(-0.1f, 0, 0);
        //    //}else{
        //    //    //_MCPig.flipX = true; // Lat nguoc
        //    //                         //_MCPig.sprite = Resources.Load("char_walk_1_heo.png") as Sprite;
        //    //    _MCPig.transform.position += new Vector3(0.1f, 0, 0);
        //    //}
        //}else{
        //    //if(isInSideScreen(_MCPig.transform.position)){
        //        _MCPig.flipX = false;
        //        _MCPig.transform.position += new Vector3(0.1f, 0, 0);
        //    //}else{
        //    //    _MCPig.transform.position += new Vector3(-0.1f, 0, 0);
        //    //}
           
        //}
    }

    private bool isInSideScreen(Vector3 pos){
        return pos.x >= -7 && pos.x <= 7;
    }

}
