/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeStoreTabsColor : MonoBehaviour
{

    public GameObject[] tabs;

    private Color normalColor;
    private Color otherColor = new Color(0, 51.0f / 255f, 120.0f / 255.0f);
    // Use this for initialization
    void Start()
    {
        normalColor = tabs[2].GetComponent<Image>().color;

        SetSelectectedTab(2);

    }

    public void SetSelectectedTab(int index)
    {
        for (int i = 0; i < tabs.Length; i++)
        {
            if (i != index)
            {
                tabs[i].GetComponent<Image>().color = otherColor;

            }
            else
            {
                tabs[i].GetComponent<Image>().color = normalColor;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
