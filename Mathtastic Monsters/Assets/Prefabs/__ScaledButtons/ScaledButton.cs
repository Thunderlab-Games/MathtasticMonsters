using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AgeBracket
{
    Seven,
    Eight,
    Nine,
    Ten,
    Eleven,
    Twelve,
    Thirteen,
    Fourteen,
}


public class ScaledButton : MonoBehaviour
{
    public int variableCount = 2; //Number of variables being summed.

    public float levelTime = 20; //Amount of additional time added at level start.

    public float minNumber = 1; //Smallest possible number a variable can reach.
    public float maxNumber = 8; //Largest possible number a variable can reach.

    public int minAnswer = 1; //Lowest acceptable answer.
    public int maxAnswer = 9; //Highest possible answer.

    public int difficulty = 9; //The amount of base experience given for completing the level.

    public int MonsterHealth = 10; //The monster's health.
    public float MonsterAttack = 1; //Damage the monster will inflict on hit.

    public bool preventRounding;

    public int[] secondFixedNumber = { 1, 2 };

    public int[] thirdFixedNumber = { 1, 2 };

    public int enemPhaseTime = 60;
    public int enemyChoices = 3;
    public int enemyAnswerRange = 5;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}