using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class ParticleData
{
    public string particleName;
    public ParticleSystem particleSystem;
}

public class ParticlePlayer : MonoBehaviour
{
    public List<ParticleData> particleList;
    public void PlayParticles(string particleName)
    {
        foreach (ParticleData particleData in particleList)
        {
            if (particleData.particleName == particleName)
            {
                particleData.particleSystem.Play();
            }
        }
    }
}
