using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject levelsPanel;
    [SerializeField] private GameObject settingsPanel;

    [Header("Main Buttons")]
    [SerializeField] private Button playBTN;
    [SerializeField] private Button settingsBTN;
    [SerializeField] private Button exitBTN;
    [SerializeField] private Button backBTN;
    
    [Header("Levels Buttons")]
    [SerializeField] private Button LVL_1_BTN;
    [SerializeField] private Button LVL_2_BTN;
    [SerializeField] private Button LVL_3_BTN;

    [Header("Levels Buttons")]
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Dropdown difficultyDropdown;

    private GameObject currentActivePanel;

    private void Start()
    {
        PanelsInit();

        ButtonsInit();

        SettingsInit();
    }

    private void ButtonsInit()
    {
        playBTN.onClick.AddListener(OnPlayButton);
        settingsBTN.onClick.AddListener(OnSettingsButton);
        exitBTN.onClick.AddListener(OnExitButton);
        backBTN.onClick.AddListener(OnBackButton);

        LVL_1_BTN.onClick.AddListener(OnLevelLoad);
        LVL_2_BTN.onClick.AddListener(OnLevelLoad);
        LVL_3_BTN.onClick.AddListener(OnLevelLoad);

        backBTN.gameObject.SetActive(false);
    }

    private void PanelsInit()
    {
        currentActivePanel = mainMenuPanel;

        currentActivePanel.SetActive(true);
        levelsPanel.SetActive(false);
        settingsPanel.SetActive(false);
    }

    private void SettingsInit()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("VolumeLevel", volumeSlider.value);
        difficultyDropdown.value = PlayerPrefs.GetInt("DifficultyLevel", difficultyDropdown.value);
    }

    private void OnPlayButton()
    {
        SwitchActivePanelTo(levelsPanel);

        backBTN.gameObject.SetActive(true);
    }

    private void OnSettingsButton()
    {
        SwitchActivePanelTo(settingsPanel);

        backBTN.gameObject.SetActive(true);
    }

    private void OnExitButton()
    {
        Application.Quit();
    }

    private void OnBackButton()
    {
        SwitchActivePanelTo(mainMenuPanel);

        backBTN.gameObject.SetActive(false);
    }

    private void OnLevelLoad()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnVolumeLevelChanged()
    {
        PlayerPrefs.SetFloat("VolumeLevel", volumeSlider.value);
    }

    public void OnDifficultyLevelChanged()
    {
        PlayerPrefs.SetInt("DifficultyLevel", difficultyDropdown.value);
    }

    private void SwitchActivePanelTo(GameObject newPanel)
    {
        currentActivePanel.SetActive(false);
        currentActivePanel = newPanel;
        currentActivePanel.SetActive(true);
    }
}
