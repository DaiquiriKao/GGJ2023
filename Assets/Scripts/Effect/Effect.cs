using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Effect
{
    public enum effectType { Noun, Adjective, Verb};
    public effectType PartOfSpeech = effectType.Noun;
    public GameObject InstantiateObject;
    public UnityEvent Skill;
    public Status.status Ability;

    public virtual void Execution()
    {
        if (PartOfSpeech == effectType.Noun)
            Instanitiate();
        else if (PartOfSpeech == effectType.Adjective)
            AddStatus();
        else if (PartOfSpeech == effectType.Verb)
            AddSkill();
    }
    public void Instanitiate()
    {
        GameObject.Instantiate(InstantiateObject);
    }
    public void AddStatus()
    {
        GameObject.Find("Status").GetComponent<Status>().CurrentSatus |= Ability;
    }
    public void AddSkill()
    {
        Skill.Invoke();
    }
}
