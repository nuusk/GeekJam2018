using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public StageType StageType { get { return _stageType; } }

    private StageType _stageType;

	void Start()
    {
        Initialize();
	}

    public void ChangeStage(StageType stageType)
    {
        if (stageType == StageType.Game)
            ChangeStageToGame();
        else if (stageType == StageType.Forge)
            ChangeStageToForge();

        _stageType = stageType;
    }  

    public void ChangeStageToGame()
    {
        GameManager.instance.TimeManager.TimeStart();
    }

    public void ChangeStageToForge()
    {
        GameManager.instance.TimeManager.TimeStop();
    }

    private void Initialize()
    {
        _stageType = StageType.Game;
    }
}
