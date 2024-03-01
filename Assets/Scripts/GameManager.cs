using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo 
{
    public List<List<bool>> Info;
    public int StickCount;
    public int StickCapacity;
    public GameSetup GameSetup;
    public GameSetup AnswerGameSetup;
    public int Seed;

    public GameInfo(GameSetup gameSetup, GameSetup answerGameSetup, int stickCount, int seed, int stickCapacity = 3)
    {
        StickCount = stickCount;
        StickCapacity = stickCapacity;
        GameSetup = gameSetup;
        AnswerGameSetup = answerGameSetup;
        Seed = seed;
        Info = new List<List<bool>>();
    }
}

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _startStickCapacity = 3;
    [SerializeField] private int _startStickCount = 3;
    [SerializeField] private int _startTorusCount = 3;

    [SerializeField] private GameObject _visualizeObject;
    [SerializeField] private List<GameSetup> _setups = new List<GameSetup>();
    [SerializeField] private Transform _answerPosition;

    private IVisualizer _visualizer;
    private GameInfo _gameInfo;

    private GameSetup _oldSetup;
    private GameSetup _oldAnswerSetup;

    private InfoController _infoController;

    public int Seed { get; set; }

    private const int GAME_SETUP_INDEX_OFFSET = 2;

    private void Awake()
    {
        _infoController = FindObjectOfType<InfoController>();
        _visualizer = _visualizeObject.GetComponent<IVisualizer>();
    }

    private void Start()
    {
        RandomizeGame();
    }

    private void CalculateGameVariant(int stickCount = 3, int stickCapacity = 3, int torusCount = 3)
    {
        if (_oldSetup != null)
            Destroy(_oldSetup.gameObject);
              
        if (_oldAnswerSetup != null)
            Destroy(_oldAnswerSetup.gameObject);

        _oldSetup = Instantiate(_setups[stickCount - GAME_SETUP_INDEX_OFFSET], Vector3.zero, Quaternion.identity);
        _oldAnswerSetup = Instantiate(_setups[stickCount - GAME_SETUP_INDEX_OFFSET], _answerPosition);
        _oldAnswerSetup.transform.localPosition = Vector3.zero;

        _gameInfo = new GameInfo(_oldSetup, _oldAnswerSetup, stickCount, Seed);

        for (int i = 0; i < stickCount; i++)
        {
            List<bool> gameStick = new List<bool>();
            _gameInfo.Info.Add(gameStick);
        }

        System.Random random = new System.Random(Seed);

        for (int j = 0; j < torusCount; j++)
        {
            int stickIndex = 0;
            do
            {
                stickIndex = random.Next(0, stickCount);
            }
            while (_gameInfo.Info[stickIndex].Count >= stickCapacity);

            _gameInfo.Info[stickIndex].Add(true);
        }
    }

    [ContextMenu("Debug Game")]
    public void RandomizeGame()
    {
        Seed = Random.Range(int.MinValue, int.MaxValue);

        CalculateGameVariant(_startStickCount, _startStickCapacity, _startTorusCount);
        _visualizer.Visualize(_gameInfo);
        _infoController.MakePhoto();
    }
}
