using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redCircle : MonoBehaviour
{
    public int vitesseDeplacement ;
    public float facteurAugmentation = 10f;

    void Start()
    {
        Destroy(gameObject,4f);
    }

    private void Update()
    {
        transform.Translate(Vector3.back * vitesseDeplacement * Time.deltaTime);
        AugmenterEchelle();
    }

    private  void AugmenterEchelle()
    {
        // Obtenir l'échelle actuelle de l'objet
        Vector3 echelleActuelle = transform.localScale;

        // Calculer la nouvelle échelle en l'augmentant selon le facteur
        Vector3 nouvelleEchelle = echelleActuelle + new Vector3(facteurAugmentation, facteurAugmentation ,0f) * Time.deltaTime;

        // Appliquer la nouvelle échelle à l'objet
        transform.localScale = nouvelleEchelle;
    }
}
