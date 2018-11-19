#pragma once
#include "Vector3.h"

// Other Tean size
const int TEAM_SPAWN_POSITION_SIZE = 3;

// Shooter position
Vector3 soloPlayerPosition(10.0f, 3.5f, -10.0f);

// Rest of team amount and positions
Vector3 teamSpawnPosition[TEAM_SPAWN_POSITION_SIZE] = { Vector3(-10.0f, 3.5f, 10.0f),
														Vector3(0.0f, 3.5f, 10.0f),
														Vector3(10.0f, 3.5f, 10.0f)};


extern "C"
{	
	__declspec(dllimport) int GetTeamSpawnPositionSize();
	__declspec(dllimport) Vector3 GetTeamSpawnPosition(int position);
	__declspec(dllimport) Vector3 GetSoloPlayerSpawnPosition();
}