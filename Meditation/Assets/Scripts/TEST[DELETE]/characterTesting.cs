﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterTesting : MonoBehaviour
{
    public Character Boy;
    // Start is called before the first frame update
    void Start()
    {
        Boy = CharacterManager.instance.GetCharacter("Boy", enableCharacOnStart:false);
        Boy.GetSprite(0);
    }

    public string[] speech;
    int i = 0;


    public Vector2 moveTarget;
    public float moveSpeed;
    public bool smooth;


    public int bodyIndex, expressionIndex = 0;
    public float speed = 5f;
    public bool smoothTransitions = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (i < speech.Length){
                Boy.Say(speech[i]);
            }
            else
                DialogueSystem.instance.Close();

            i++;
        }

        if(Input.GetKeyDown(KeyCode.M)){
            Boy.MoveTo(moveTarget, moveSpeed, smooth);
        }

         if(Input.GetKeyDown(KeyCode.S)){
            Boy.StopMoving(true);
        }

        if(Input.GetKeyDown(KeyCode.B)){
            if(Input.GetKey(KeyCode.T))
            {
                Boy.TranisitionBody(Boy.GetSprite(bodyIndex), speed, smoothTransitions);
            }
            else
                Boy.SetBody(bodyIndex);
        }

        if(Input.GetKeyDown(KeyCode.E)){
            if(Input.GetKey(KeyCode.T))
            {
                Boy.TranisitionExpression(Boy.GetSprite(bodyIndex), speed, smoothTransitions);
            }
            else
            {
            Boy.SetExpression(expressionIndex);        }
            
            }
    }
}
