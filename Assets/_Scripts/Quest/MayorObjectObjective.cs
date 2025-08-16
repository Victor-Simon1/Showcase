using System;
using MyUnityPackage.ProgressionSystem;
using UnityEngine;


namespace Showcase
{
    public class MayorObjectObjective : IQuestObjective
    {
        public string Title {get;set;}
        public string Description {get;set;}
        public bool IsCompleted {get;set;}
        public int CurrentProgression {get;set;}
        public int MaxProgression {get;set;}
        public event Action<int, int> OnProgress;
        public event Action OnCompleted;

        public MayorObjectObjective(string _title, string _description, int _countRequired)
        {
            Title = _title;
            Description = _description;
            CurrentProgression = 0;
            MaxProgression = _countRequired;
        }
        public void Start()
        {

        }
        public void Stop()
        {
            throw new NotImplementedException();
        }
        
        public bool CheckProgress()
        {
            throw new NotImplementedException();
        }

        public bool IsComplete()
        {
            throw new NotImplementedException();
        }

        public void OnProgressChange()
        {
            throw new NotImplementedException();
        }
    }
}


