using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{


    public static GUIManager _sharedInstance;

    [Header("Menu Elements")]
    [SerializeField] GameObject _menu;
    [SerializeField] GameObject _hud;
    [SerializeField] GameObject _gameOverMenu;

    [Header("HUD Elements")]
    [SerializeField] Slider _slider;
    [SerializeField] Image _bgSliderFill;

    [Header("Animation Properties")]
    [SerializeField] float _menuSpeed;
    [SerializeField] float _hudSpeed;

    private void Awake() 
    {
        if (_sharedInstance != null && _sharedInstance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            _sharedInstance = this; 
        }
    }

    private void Start() {
        InMenu();
    }

    #region Game Controller
    private void StartGame() {
        _bgSliderFill.color = new Color(0,255,0);
        _slider.value = 0;
        InGame();
    }
    public void InGame()
    {
        ShowMenu(false);
        ShowPlayAgainMenu(false);
        ShowHUD(true);
    }

    public void InMenu()
    {
        ShowHUD(false);
        ShowPlayAgainMenu(false);
        ShowMenu(true);
    }

    public void InGameOver()
    {
        ShowHUD(false);
        ShowMenu(false);
        ShowPlayAgainMenu(true);
    }


    #endregion

    #region Menu Buttons
    public void StartGameButton()
    {
        GameManager._sharedInstance.StartGame();
        InGame();
    }

    public void QuitGameButton()
    {
        GameManager._sharedInstance.QuitGame();
    }

    void ShowMenu(bool show)
    {
        _menu.gameObject.SetActive(show);
    }

    #endregion

    #region HUD
    public void UpdateStressBar(float value)
    {
        //update bar
        if(value < 50) _bgSliderFill.color = new Color(0,255,0);
        if(value > 50) _bgSliderFill.color = new Color(255,255,0);
        if(value > 70) _bgSliderFill.color = new Color(255,125,0);
        if(value > 90) _bgSliderFill.color = new Color(255,0,0);

        _slider.value = value;
    }

    void ShowHUD(bool show)
    {
        _hud.gameObject.SetActive(show);
    }

    #endregion

    #region Play Again
    public void ResetGameButton()
    {
        GameManager._sharedInstance.ResetGame();
    }

    void ShowPlayAgainMenu(bool show)
    {
        _gameOverMenu.SetActive(show);
    }

    public void BackButton()
    {
        InMenu();
    }
    #endregion
}
