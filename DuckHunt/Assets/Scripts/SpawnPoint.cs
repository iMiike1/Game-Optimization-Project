using UnityEngine;

enum EnumTeam
{
    TEAM_ONE,
    TEAM_TWO
}

public class SpawnPoint
{
    // TODO: GET THE VALUES FROM DLL !!!!
    // TODO: GET THE VALUES FROM DLL !!!!
    // TODO: GET THE VALUES FROM DLL !!!!
    // TODO: GET THE VALUES FROM DLL !!!!
    const int teamOneNumberOfSlots = 1;
    const int teamTwoNumberOfSlots = 3;



    private Vector3 [] teamOneSpawnPoints = new Vector3[teamOneNumberOfSlots];
    private Vector3 [] teamTwoSpawnPoints = new Vector3[teamTwoNumberOfSlots];

    bool[] isSlotInTeamOneEmpty = new bool[teamOneNumberOfSlots];
    bool[] isSlotInTeamTwoEmpty = new bool[teamTwoNumberOfSlots];

    // Constructors
    public SpawnPoint()
    {
        // Initialioze team one spawn points
        teamOneSpawnPoints[0] = new Vector3(10.0f, 3.5f, -10.0f);

        // Initialize team two spawn points
        teamTwoSpawnPoints[0] = new Vector3(-10.0f, 3.5f, 10.0f);
        teamTwoSpawnPoints[1] = new Vector3(0.0f, 3.5f, 10.0f);
        teamTwoSpawnPoints[2] = new Vector3(10.0f, 3.5f, 10.0f);

        // Initialize boolean array, set all to true, so all slots are empty
        for (int i = 0; i < isSlotInTeamOneEmpty.Length; i++) isSlotInTeamOneEmpty[i] = true;
        
        // Initialize boolean array, set all to true, so all slots are empty
        for (int i = 0; i < isSlotInTeamTwoEmpty.Length; i++) isSlotInTeamTwoEmpty[i] = true;
    }


    // Take the team value, if is zero, return the teamOne positions, if is one, return team two position
    public Vector3 AssignMeSpawnPoints(int team)
    {
        int tempSpawnId;

        // If team is team one, give me new  team one spawn positions
        switch (team)
        {
            case (int)EnumTeam.TEAM_ONE:
                // Random generate number
                tempSpawnId = Random.Range(0, teamOneNumberOfSlots);
                Debug.Log("ID: " + tempSpawnId);


                // Check if the slot is empty
                do
                {   // If the slot is not empty, generate new random number
                    if (isSlotInTeamOneEmpty[tempSpawnId] == false) tempSpawnId = Random.Range(0, teamOneNumberOfSlots);
                    else
                    {
                        // Return new spawn points
                        isSlotInTeamOneEmpty[tempSpawnId] = false;
                        return teamOneSpawnPoints[tempSpawnId];
                    }
                    Debug.Log("ID INSIDE WHILE LOOOP: " + tempSpawnId);

                } while (isSlotInTeamOneEmpty[tempSpawnId] == false);
                break;




            case (int)EnumTeam.TEAM_TWO:
                // Random generate number
                tempSpawnId = Random.Range(0, teamTwoNumberOfSlots);

                // Check if the slot is empty
                do
                {   // If the slot is not empty, generate new random number          
                    if (isSlotInTeamTwoEmpty[tempSpawnId] == false) tempSpawnId = Random.Range(0, teamTwoNumberOfSlots);
                    else
                    {
                        // Return new spawn points
                        isSlotInTeamTwoEmpty[tempSpawnId] = false;
                        return teamTwoSpawnPoints[tempSpawnId];
                    }

                } while (isSlotInTeamTwoEmpty[tempSpawnId] == false);
                break;

        }

        Debug.Log("ERROR: Wrong team number was given, the parameter must be 0 or 1!");
        return new Vector3();
    }

    // Assign the spawn point for asked team
    public Vector3 GiveMeSpawnPosition(int slotID, int team)
    {
        // Error string
        string errorMessage = "";

        // Check which team is asked and return his spawn point
        switch (team)
        {
            case (int)EnumTeam.TEAM_ONE:
                if (slotID >= teamOneSpawnPoints.Length) errorMessage = "ERROR: Array out of range. ID for team one was higher than the lenght of array.";
                else return teamOneSpawnPoints[slotID];
                break;
            case (int)EnumTeam.TEAM_TWO:
                if (slotID >= teamTwoSpawnPoints.Length) errorMessage = "ERROR: Array out of range. ID for team two was higher than the lenght of array.";
                else return teamTwoSpawnPoints[slotID];
                break;
        }

        // Return invalid spawn points
        Debug.Log(errorMessage);
        return new Vector3();
    }


    // When has the round finish, reset all spawn points
    private void ResetSpawnPoints()
    {
        // Initialize boolean array, set all to true, so all slots are empty
        for (int i = 0; i < isSlotInTeamOneEmpty.Length; i++) isSlotInTeamOneEmpty[i] = true;

        // Initialize boolean array, set all to true, so all slots are empty
        for (int i = 0; i < isSlotInTeamTwoEmpty.Length; i++) isSlotInTeamTwoEmpty[i] = true;
    }
}

