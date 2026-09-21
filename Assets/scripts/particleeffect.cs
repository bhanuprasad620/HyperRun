using UnityEngine;

public class particleeffect : MonoBehaviour
{
    public ParticleSystem particleEffect;
    int particleCount = 10; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < particleCount; i++)
        {
            ParticleSystem particle = Instantiate(particleEffect, transform);
            particle.gameObject.SetActive(false);
        }
    }
    public ParticleSystem GetEffect()
    {
        foreach (Transform child in transform)
        {
            if (!child.gameObject.activeInHierarchy)
            {
                child.gameObject.SetActive(true);
                return child.GetComponent<ParticleSystem>();
            }
        }

        return null;
    }
    public void playeffect(Vector3 position)
    {
        ParticleSystem effect = GetEffect();
        if (effect != null)
        {
            effect.transform.position = position;
            effect.Play();
            StartCoroutine(DisableEffect(effect));
        }
    }
    private System.Collections.IEnumerator DisableEffect(ParticleSystem effect)
    {
        yield return new WaitUntil(() => !effect.IsAlive());

        effect.gameObject.SetActive(false);
    }
}
// Update is called once per frame

