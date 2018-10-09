using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public GameObject TimeManagerObject;

    public StageType StageType { get { return _stageType; } }

    private StageType _stageType;
    private TimeManager _timeManager;

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
        _timeManager.TimeStart();
    }

    public void ChangeStageToForge()
    {
        _timeManager.TimeStop();
    }

    private void Initialize()
    {
        _stageType = StageType.Game;
        _timeManager = TimeManagerObject.GetComponent<TimeManager>();
    }
}
