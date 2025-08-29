using UnityEngine;
using System;
using MyUnityPackage.ProgressionSystem;

namespace Showcase
{
    public class RockObjective : IQuestObjective
    {
        public string Title {get; set;}

        public string Description {get; set;}

        public bool IsCompleted {get; set;}

        public int CurrentProgression{get; set;}

        public int MaxProgression {get; set;}

        public event Action<int, int> OnProgress;
        public event Action OnCompleted;

        public RockObjective(string _title, string _description,int _MaxProgression)
        {
            Title = _title;
            Description = _description;
            MaxProgression = _MaxProgression;

        }
        
        public void Start()
        {
            MyUnityPackage.Toolkit.Logger.LogMessageEditor("START WOOD OBJECTIF! ");
            InteractableRock.OnRockGet += OnProgressChange;
        }

        public void Stop()
        {
            InteractableRock.OnRockGet -= OnProgressChange;
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
                MyUnityPackage.Toolkit.Logger.LogMessageEditor("Completion de la mission d'aller chercher du bois! ");
                OnCompleted?.Invoke();
            }
        }

    }
}

