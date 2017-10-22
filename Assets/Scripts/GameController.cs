using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public bool startLevelEncounter;
    public bool inEncounter;
    // Float values in time variables represent seconds
    private float timeToNextEncounter;
    public float timeBetweenEncounters;
    public float encounterTimeVariation;
    private float currentEncountersEncountered;
    public float totalEncounters;
    private float currentCombatEncounters;
    public float totalCombatEncounters;
    private float currentResourceEncounters;
    public float totalResourceEncounters;
    public PlayerController playerController;

	// Use this for initialization
	void Start () {
        startLevelEncounter = true;
        inEncounter = false;
        currentEncountersEncountered = 0;
        currentCombatEncounters = 0;
        currentResourceEncounters = 0;

        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        if(startLevelEncounter == false)
        {
            if (timeToNextEncounter <= 0 && inEncounter == false)
            {
                inEncounter = true;
                EncounterStart();
            }
            else if (timeToNextEncounter > 0 && inEncounter == false)
            {
                timeToNextEncounter -= Time.deltaTime;
            }
        }
        else
        {

        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            EncounterEnd();
        }
    }

    public void EncounterStart()
    {
        float rollResult;

        playerController.StopParty();

        rollResult = RollForEncounterType();

        if (rollResult == 0)
        {
            currentCombatEncounters++;
            CombatEncounter();
        }
        else if(rollResult == 1)
        {
            currentResourceEncounters++;
            ResourceEncounter();
        }
        else if(rollResult == 2)
        {
            Debug.Log("Something went wrong");
        }
        currentEncountersEncountered++;
    }

    // Runs at the end of every encounter
    public void EncounterEnd()
    {
        // Check if all encounters have been completed
        if(currentEncountersEncountered >= totalEncounters)
        {
            EndLevel();
        }
        else
        {
            StartMovingAndResetTime();
            inEncounter = false;
        }
    }

    public void StartLevel()
    {
        startLevelEncounter = false;
        StartMovingAndResetTime();
    }

    public void EndLevel()
    {
        Debug.Log("End of level");
    }

    // Rolls are weighted based on the ratio of the current encounters remaining for each type
    // of encounter when divided with the total number of encounters
    public float RollForEncounterType()
    {
        float combatEncountersRemaining = totalCombatEncounters - currentCombatEncounters;
        float resourceEncountersRemaining = totalResourceEncounters - currentResourceEncounters;
        float combatEncounterChance;
        float resourceEncounterChance;
        float encountersRemaining = totalEncounters - currentEncountersEncountered;
        float rollValue;

        if(combatEncountersRemaining != 0)
        {
            combatEncounterChance = combatEncountersRemaining / encountersRemaining;
        }
        else
        {
            combatEncounterChance = 0;
        }

        if(resourceEncountersRemaining != 0)
        {
            resourceEncounterChance = resourceEncountersRemaining / encountersRemaining;
        }
        else
        {
            resourceEncounterChance = 0;
        }

        // Horrible code, please don't look
        rollValue = Random.Range(0, 100);
        if(rollValue != 0)
        {
            rollValue /= 100;
        }
        Debug.Log(combatEncounterChance);
        Debug.Log(resourceEncounterChance);
        Debug.Log(rollValue);
        if(combatEncounterChance <= rollValue)
        {
            return 0;
        }
        else if(combatEncounterChance + resourceEncounterChance <= rollValue)
        {
            return 1;
        }
        else
        {
            return 2;
        }
    }

    private void StartMovingAndResetTime()
    {
        timeToNextEncounter = timeBetweenEncounters + Random.Range(-encounterTimeVariation / 2, encounterTimeVariation / 2);
        playerController.MovePartyRight();
    }

    public void CombatEncounter()
    {
        Debug.Log("Combat encounter");
        
    }

    public void ResourceEncounter()
    {
        Debug.Log("Resource encounter");

    }
}
