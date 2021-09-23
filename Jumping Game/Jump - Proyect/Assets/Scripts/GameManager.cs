using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public      static      GameManager     Instance;

    #region Player Things
    private         GameObject      player          =       null;

    private         CoinsCollector  pCoins          =       null;

    private         Jumping         pJump           =       null;
    #endregion

    #region Score Floats
    public          float           _maxHeight      =       0f;

    public          float           _timeLive       =       0f;

    [SerializeField]
    [Tooltip("Valor que se multiplica al puntaje")]
    private         float           scoreMultiplyer  =       1.5f;
    #endregion

    #region Score Texts
    [SerializeField]
    private         Text            _secondsText    =       null;

    [SerializeField]
    private         Text            _heightText     =       null;

    [SerializeField]
    private         Text            _coinText       =       null;
    #endregion

    #region UI
    [SerializeField]
    private          GameObject      _limitsPanel    =       null;

    [SerializeField]
    private          GameObject      _GameOverPanel  =       null;

    [SerializeField]
    private          GameObject      _rebornPanel    =       null;

    [SerializeField]
    private          Text            _scoreText      =       null;

    [SerializeField]
    private         Animator        blackFade        =       null;
    #endregion

    [SerializeField]
    private         Grayscale[]     grayscaleObjects;

    [HideInInspector]
    public          bool            isSlow           =       false;

    private         bool            isFinish         =       false;

    [HideInInspector]
    public          bool            outLimits        =       false;

    [SerializeField]
    private         float           _finishLimitsTimer      =       2.5f;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        if(ScoreRegister.Instance != null && ScoreRegister.Instance._generalScore != 0)
        {
            _rebornPanel.SetActive(true);
        }
        else
        {
            _rebornPanel.SetActive(false);
        }

        _limitsPanel.SetActive(false);
        _GameOverPanel.SetActive(false);

        grayscaleObjects = FindObjectsOfType<Grayscale>();

        player = GameObject.FindGameObjectWithTag("Player");

        pJump = player.GetComponent<Jumping>();
        pCoins = player.GetComponent<CoinsCollector>();
    }

    private void Update()
    {
        Grayscale();
        LiveTime();
        UITexts();
        GameOver();

        if (outLimits)
        {
            _limitsPanel.SetActive(true);

            if(_finishLimitsTimer <= 0)
            {
                ScoreRegister.Instance._levelMultiplyer++;
                ScoreRegister.Instance._generalScore += Mathf.Round(((_timeLive + _maxHeight) * pCoins._coins) * scoreMultiplyer * ScoreRegister.Instance._levelMultiplyer);
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                blackFade.SetTrigger("Fade");
                _finishLimitsTimer -= Time.deltaTime;
            }
        }
    }

    private void Grayscale()
    {
        if (isSlow)
        {
            for(int i = 0; i < grayscaleObjects.Length; i++)
            {
                grayscaleObjects[i].GrayScaleEnabled();
            }
        }
        else if (!isSlow)
        {
            for(int i = 0; i < grayscaleObjects.Length; i++)
            {
                grayscaleObjects[i].GrayScaleDisabled();
            }
        }
    }

    private void LiveTime()
    {
        if(pJump.isStartJump && !pJump.isDead)
        {
            _timeLive += Time.deltaTime;
        }
    }

    private void UITexts()
    {
        _secondsText.text = Mathf.Round(_timeLive).ToString() + "s";
        _heightText.text = _maxHeight.ToString() + "mts";
        _coinText.text = "Coins: " + pCoins.coinsAmount.ToString();
    }

    private void GameOver()
    {
        if (pJump.isDead & !isFinish)
        {
            ScoreRegister.Instance._generalScore += Mathf.Round(((_timeLive + _maxHeight) * (pCoins._coins + scoreMultiplyer + ScoreRegister.Instance._levelMultiplyer)) / 10);
            _GameOverPanel.SetActive(true);
            _scoreText.text = "Score: " + ScoreRegister.Instance._generalScore.ToString();
            isFinish = true;
        }
    }

    public void BackAgain()
    {
        blackFade.SetTrigger("Fade");
        ScoreRegister.Instance._generalScore = 0;
        SceneManager.LoadScene(0);
    }
}
