using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendedRotator : Rotator
{
    // Start is called before the first frame update
    //https://answers.unity.com/questions/818502/inheritance-polymorphism.html

    //https://subscription.packtpub.com/book/game_development/9781784390655/1/ch01lvl1sec19/classes-and-polymorphism

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        Rotate();
    }

    public Color targetColor = new Color(0, 1, 0, 1);
    public Material materialToChange;

    void Start()
    {
        materialToChange = gameObject.GetComponent<Renderer>().material;
        StartCoroutine(LerpFunction(targetColor, 5));
    }

    IEnumerator LerpFunction(Color endValue, float duration)
    {
        float time = 0;
        Color startValue = materialToChange.color;

        while (time < duration)
        {
            materialToChange.color = Color.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        materialToChange.color = endValue;
    }

    public new void Rotate()
    {
        transform.Rotate(new Vector3(30, 0, 0) * Time.deltaTime);
    }
}
