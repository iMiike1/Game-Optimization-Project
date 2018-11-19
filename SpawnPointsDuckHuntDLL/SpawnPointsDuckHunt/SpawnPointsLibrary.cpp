#include "SpawnPointsLibrary.h"



extern "C"
{
	//returns team size
	int GetTeamSpawnPositionSize()					{ return TEAM_SPAWN_POSITION_SIZE; }
	//returns team spawn point positions
	Vector3 GetTeamSpawnPosition(int position)		{ return teamSpawnPosition[position]; }
	// returns solo player position
	Vector3 GetSoloPlayerSpawnPosition()			{ return soloPlayerPosition; }
}