using System;
using System.Collections.Generic;
using MyUnityPackage.Toolkit;
using PixelCrushers.DialogueSystem;
using TMPro;
using UnityEngine;

namespace Showcase
{
    public class SettingsManager : MonoBehaviour
    {
        private enum ELang
        {
            FR = 0,
            EN,
            MAXLANG
        }
        [SerializeField] TMP_Dropdown resolutionDropdown;
        [SerializeField] TMP_Dropdown langDropdown;
        [SerializeField] TMP_Dropdown fpsDropdown;
        Resolution[] resolutionsArray;

        int[] fpsArray = {30,60,120};
        void Start()
        {
             Debug.Log("This system is in " + Application.systemLanguage);
            ServiceLocator.AddService<SettingsManager>(gameObject);
            resolutionsArray = Screen.resolutions;

            //Add resolution in dropdown
            List<string> resStrings= new List<string>();
            foreach(Resolution res in resolutionsArray)
            {
                resStrings.Add(res.ToString());
            }   
            resolutionDropdown.AddOptions(resStrings);

            //Set default fps
            List<string> fpsStrings= new List<string>();
            foreach(int fps in fpsArray)
            {
                fpsStrings.Add(fps.ToString());
            }   
            fpsDropdown.AddOptions(fpsStrings);

            List<string> langStrings= new List<string>();
            for(int eLang = 0;eLang<(int)ELang.MAXLANG;eLang++)
            {
                langStrings.Add(Enum.GetName(typeof(ELang),eLang));
                
            }
            langDropdown.AddOptions(langStrings);
        }
        public void ChangeQuality(int qualityIndex)
        {
            MUPLogger.LogMessage("" + qualityIndex);
            QualitySettings.SetQualityLevel(qualityIndex,true);
        }
        public void ChangeLangage(int langIndex)
        {
            string langAbbreviation= Localization.GetLanguage(SystemLanguage.French);//for Pixel Crusher dialog system
            string langName = SystemLanguage.French.ToString();//For I2Loc
            switch (langIndex)
            {
                case (int)ELang.FR:
                    langAbbreviation = Localization.GetLanguage(SystemLanguage.French);
                    langName = SystemLanguage.French.ToString();
                    break;
                case (int)ELang.EN:
                    langAbbreviation = Localization.GetLanguage(SystemLanguage.English);
                    langName = SystemLanguage.English.ToString();
                    break;
            }
            if(!I2.Loc.LocalizationManager.HasLanguage(langName))
                MUPLogger.LogMessageWarningEditor("Can not find langage : " + langName + " for I2Loc");
            MUPLogger.LogMessage("Change to " + langName + "-" + langAbbreviation);

            DialogueManager.SetLanguage(langAbbreviation);
            I2.Loc.LocalizationManager.CurrentLanguage = langName;
        }


        public void ChangeResolution(int resolutionIndex)
        {
            MUPLogger.LogMessage("Change resolution ");
            Screen.SetResolution(resolutionsArray[resolutionIndex].width,
                                resolutionsArray[resolutionIndex].height,
                                Screen.fullScreen );
        }

        public void ChangeFullscreen(bool fullscreen)
        {
            Screen.fullScreen = fullscreen;
        }

        public void ChangeFPS(int fpsIndex)
        {
            //TO DO set les fps dans le start + le dropdown
            
            Application.targetFrameRate = fpsArray[fpsIndex];
        }
    }

}
