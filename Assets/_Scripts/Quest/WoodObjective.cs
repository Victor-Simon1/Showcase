using System;
using MyUnityPackage.ProgressionSystem;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Showcase
{
    public class WoodObjective : IQuestObjective
    {
        public string Title {get; set;}

        public string Description {get; set;}

        public bool IsCompleted {get; set;}

        public int CurrentProgression{get; set;}

        public int MaxProgression {get; set;}

        public event Action<int, int> OnProgress;
        public event Action OnCompleted;

        public WoodObjective(string _title, string _description,int _MaxProgression)
        {
            Title = _title;
            Description = _description;
            MaxProgression = _MaxProgression;

        }
        
        public void Start()
        {
            MyUnityPackage.Toolkit.Logger.LogMessageEditor("START WOOD OBJECTIF! ");
            InteractableWood.OnWoodGet += OnProgressChange;
        }

        public void Stop()
        {
             InteractableWood.OnWoodGet -= OnProgressChange;
        }
        public bool CheckProgress()
        {
            return IsCompleted = CurrentProgression >= MaxProgression;
        }

        public bool IsComplete() => IsCompleted;


        public void OnProgressChange()
        {
            CurrentProgression++;
            OnProgress?.Invoke(CurrentProgression, MaxProgression);
            MyUnityPackage.Toolkit.Logger.LogMessageEditor("WOOD On ProgrssChange");
            if (CheckProgress())
            {
                DialogueLua.SetVariable("CarpenterDialog",DialogueLua.GetVariable("CarpenterDialog").AsInt+1);
                MyUnityPackage.Toolkit.Logger.LogMessageEditor("Completion de la mission d'aller chercher du bois! ");
                OnCompleted?.Invoke();
            }
        }

    }
}