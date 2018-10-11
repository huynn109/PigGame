using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController
{
    private Dictionary<string, bool> activeKeys;

    public delegate void KeyboardEventHandler(string key, string action);

    public event KeyboardEventHandler KeyboardEvent;

    public KeyboardController()
    {
        activeKeys = new Dictionary<string, bool>() {
            {"UP", false},
            {"RIGHT", false},
            {"DOWN", false},
            {"LEFT", false},
            {"SPACE", false}
        };
    }

    public void handleKeypress()
    {
        KeyboardEventHandler handler = KeyboardEvent;

        // UP BUTTON
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            activeKeys["UP"] = true;
            handler("up", "keyDown");
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                activeKeys["UP"] = false;
                handler("up", "keyUp");
            }
        }
        // RIGHT BUTTON
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            activeKeys["RIGHT"] = true;
            handler("right", "keyDown");
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                activeKeys["RIGHT"] = false;
                handler("right", "keyUp");
            }
        }
        // DOWN BUTTON
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            activeKeys["DOWN"] = true;
            handler("down", "keyDown");
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                activeKeys["DOWN"] = false;
                handler("down", "keyUp");
            }
        }
        // LEFT BUTTON
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // do something with the left direction
            activeKeys["LEFT"] = true;
            handler("left", "keyDown");
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                activeKeys["LEFT"] = false;
                handler("left", "keyUp");
            }
        }
        // SPACE BUTTON
        if (Input.GetKeyDown(KeyCode.Space))
        {
            activeKeys["SPACE"] = true;
            handler("space", "keyDown");
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                activeKeys["SPACE"] = false;
                handler("space", "keyUp");
            }
        }
    }
    /**
	 * Check to see if any keys are down (up, right, down, left, space)
	 */
    public bool areKeysDown()
    {
        bool keysDown = false;
        foreach (KeyValuePair<string, bool> activeKey in activeKeys)
        {
            if (activeKey.Value.Equals(true))
            {
                keysDown = true;
            }
        }
        return keysDown;
    }
    /**
	 * Check to see if an individual key is down or up
	 */
    public bool isKeyDown(string keyName)
    {
        return activeKeys[keyName].Equals(true);
    }
}

