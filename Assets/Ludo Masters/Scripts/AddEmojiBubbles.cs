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

public class AddEmojiBubbles : MonoBehaviour
{

    public GameObject prefab;
    public GameObject parent;
    // Use this for initialization
    void Start()
    {
        int packsCount = GameObject.Find("StaticGameVariablesContainer").GetComponent<StaticGameVariablesController>().packsCount;

        for (int i = 0; i < packsCount - 1; i++)
        {
            GameObject myObject = Instantiate(prefab);
            myObject.GetComponent<EmojiShopController>().fillData(i);
            myObject.transform.parent = parent.transform;
            myObject.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
