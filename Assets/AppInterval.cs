using System;
using UniRx;
using UnityEngine;


public class AppInterval : MonoBehaviour {

	public GameObject Cube;
    private IDisposable _update;	//intervale ne shranjujemo

    void Start()
    {
        _update = Observable.Interval(TimeSpan.FromMilliseconds(1000)).Subscribe(x => 
		// x starts from 0 and is incremented everytime the stream pushes another item.
        {
            Cube.transform.rotation = UnityEngine.Random.rotation;
        });
    }	//naredimo Observable _update, na katerem imamo interval, na katerega se povežemo in nam da stream vsakih 1000ms
		//takrat naredimo rotacijo kocke

    private void OnDestroy()
    {
        _update.Dispose();	//ko ustavimo program, zavržemo vse intervale
    }
}
