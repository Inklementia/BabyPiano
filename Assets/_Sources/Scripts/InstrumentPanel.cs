using FM;
using FM.Legacy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentPanel : MonoBehaviour
{
    [SerializeField] private CarouselView carouselView;

    private void Start()
    {
        carouselView.AddOnItemSelectedListener((int index) => {
            Debug.Log("Selected: " + index);
        });

        Select(1);
    }

    public void SelectItem()
    {
        Debug.Log("Selected Index: " + carouselView.GetCurrentItem());
    }

    public void ScrollNext()
    {
        carouselView.Next();
    }

    public void ScrollPrevious()
    {
        carouselView.Previous();
    }

    public void Select(int index)
    {
        carouselView.SelectIndex(index, true);
    }

}
