﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum operators
{
    Addition,
    Subtraction,
    Multiplication,
    Division,
    Fortress,
    AddSub,
    AddSubMult,
    AddSubMultDiv
}

public class QuizButton : MonoBehaviour
{
    internal StoryManager storyManager;

    public bool boss;

    public int quizIndex;
    internal questionContainer parent;


    public ScaledButton[] scaledButtons = new ScaledButton[6];


    public int variableCount = 2; //Number of variables being summed.

    public float levelTime = 0; //Amount of additional time added at level start.

    public float minNumber; //Smallest possible number a variable can reach.
    public float maxNumber; //Largest possible number a variable can reach.

    public operators Operator; //+, - or x. Division will be included later.

    public int minAnswer = 1; //Lowest acceptable answer.
    public int maxAnswer = 100000; //Highest possible answer.

    public int difficulty; //The amount of base experience given for completing the level.

    public int MonsterHealth = 6; //The monster's health.
    public float MonsterAttack = 1; //Damage the monster will inflict on hit.


    internal MonsterManager p_manager; //A link to the quizManager so it can tell it to start.


    public bool preventRounding;


    public int[] secondFixedNumber = { 1, 2 };

    public int[] thirdFixedNumber = { 1, 2 };

    public GameObject monsterArt;


    public int enemPhaseTime = 8;
    public int enemyChoices = 3;
    public int enemyAnswerRange = 2;

    internal bool Hard;

    public QuizButton hardMode;

    public string previousLevelString = "You won!";
    public float previousTime = 6;

    public string nextLevelString = " Entering level X!";
    public float nextime = 10;

    public string enemyString = "Now Fight!!";
    public float enemyTime = 2;

    internal int validNumbers;

    equipmentManager equipmentManager;

    // Use this for initialization
    public virtual void Start()
    {
    }

    //Call the quizManager to start a quiz using this button as the basis.
    public virtual void buttonUsed(phases a_phase)
    {
        setStats();

        p_manager = GameObject.Find("MonsterManager").GetComponent<MonsterManager>();

        if (!storyManager)
            storyManager = FindObjectOfType<StoryManager>();

        storyManager.StartTransition(this, a_phase);

        boss = false;


        p_manager.StartLevel(this);
    }


    public void setStats()
    {
        equipmentManager = FindObjectOfType<equipmentList>().equip;

        ScaledButton currentScaled = null;

        int age = (int)equipmentManager.currentAge;


        if (scaledButtons[age] != null && age < scaledButtons.Length)
        {
            currentScaled = scaledButtons[age];
        }
        else
        {
            for (int i = (int)equipmentManager.currentAge; i >= 0; i--)
            {
                if (scaledButtons[age] != null && age < scaledButtons.Length)
                {
                    currentScaled = scaledButtons[age];
                    break;
                }
            }
        }

        if (currentScaled == null)
            return;

        variableCount = currentScaled.variableCount;
        minNumber = currentScaled.minNumber;
        maxNumber = currentScaled.maxNumber;

        levelTime = currentScaled.levelTime;

        minAnswer = currentScaled.minAnswer;
        maxAnswer = currentScaled.maxAnswer;

        difficulty = currentScaled.difficulty;

        MonsterHealth = currentScaled.MonsterHealth;
        MonsterAttack = currentScaled.MonsterAttack;


        preventRounding = currentScaled.preventRounding;


        secondFixedNumber = new int[currentScaled.secondFixedNumber.Length];
        for (int i = 0; i < secondFixedNumber.Length; i++)
        {
            secondFixedNumber[i] = currentScaled.secondFixedNumber[i];
        }

        thirdFixedNumber = new int[currentScaled.thirdFixedNumber.Length];
        for (int i = 0; i < thirdFixedNumber.Length; i++)
        {
            thirdFixedNumber[i] = currentScaled.thirdFixedNumber[i];
        }

        enemPhaseTime = currentScaled.enemPhaseTime;
        enemyAnswerRange = currentScaled.enemyAnswerRange;
        enemyChoices = currentScaled.enemyChoices;
    }
}