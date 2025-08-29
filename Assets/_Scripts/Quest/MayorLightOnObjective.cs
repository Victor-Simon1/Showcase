using System;
using MyUnityPackage.ProgressionSystem;
using UnityEngine;


namespace Showcase
{
    public class MayorLightOnObjective : IQuestObjective
    {
        public string Title {get;set;}
        public string Description {get;set;}
        public bool IsCompleted {get;set;}
        public int CurrentProgression {get;set;}
        public int MaxProgression {get;set;}
        public event Action<int, int> OnProgress;
        public event Action OnCompleted;

        public MayorLightOnObjective(string _title, string _description, int _countRequired)
        {
            Title = _title;
            Description = _description;
            CurrentProgression = 0;
            MaxProgression = _countRequired;
        }
        public void Start()
        {
            MyUnityPackage.Toolkit.Logger.LogMessageEditor("START LIGH OBJECTIF! ");
            InteractableLight.OnLightOn += OnProgressChange;

            InteractableLight[] lightArray = GameObject.FindObjectsOfType<InteractableLight>();
            foreach (InteractableLight light in lightArray)
                light.Enable();
        }
        public void Stop()
        {
            InteractableLight.OnLightOn -= OnProgressChange;
        }
        
        public bool CheckProgress()
        {
              return IsCompleted = CurrentProgression >= MaxProgression;
        }

        public bool IsComplete()
        {
           return IsCompleted;
        }

        public void OnProgressChange()
        {
           CurrentProgression++;
           OnProgress?.Invoke(CurrentProgression, MaxProgression);

            if (CheckProgress())
            {
                MyUnityPackage.Toolkit.Logger.LogMessageEditor("Completion de la mission d'allumer des lampes! ");
                OnCompleted?.Invoke();
            }
        }
    }
}


