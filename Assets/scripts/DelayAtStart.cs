using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface ActiveComponent
{
    void Active();
}
public class DelayAtStart : MonoBehaviour
{
    private List<ActiveComponent> _activatid = new List<ActiveComponent>();
    private void Start()
    {
        StartCoroutine(nameof(OnComponent));
    }
    public void Add<T>(GameObject objectWithComponent)
    {
        var com = objectWithComponent.GetComponent<T>();
        if (com is ActiveComponent)
            _activatid.Add((ActiveComponent)com);
    }
    private IEnumerator OnComponent()
    {
        yield return new WaitForSeconds(3);
        for (int i = 0; i < _activatid.Count; i++)
        {
            _activatid[i].Active();
        }
    }

}

