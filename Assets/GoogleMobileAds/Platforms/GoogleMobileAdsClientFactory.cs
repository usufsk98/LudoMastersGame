/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

// Copyright (C) 2015 Google, Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using UnityEngine;

using GoogleMobileAds.Common;

namespace GoogleMobileAds
{
    internal class GoogleMobileAdsClientFactory
    {
        internal static IBannerClient BuildBannerClient()
        {
            #if UNITY_EDITOR
                // Testing UNITY_EDITOR first because the editor also responds to the currently
                // selected platform.
                return new GoogleMobileAds.Common.DummyClient();
            #elif UNITY_ANDROID
                return new GoogleMobileAds.Android.BannerClient();
            #elif UNITY_IPHONE
                return new GoogleMobileAds.iOS.BannerClient();
            #else
                return new GoogleMobileAds.Common.DummyClient();
            #endif
        }

        internal static IInterstitialClient BuildInterstitialClient()
        {
            #if UNITY_EDITOR
                // Testing UNITY_EDITOR first because the editor also responds to the currently
                // selected platform.
                return new GoogleMobileAds.Common.DummyClient();
            #elif UNITY_ANDROID
                return new GoogleMobileAds.Android.InterstitialClient();
            #elif UNITY_IPHONE
                return new GoogleMobileAds.iOS.InterstitialClient();
            #else
                return new GoogleMobileAds.Common.DummyClient();
            #endif
        }

        internal static IRewardBasedVideoAdClient BuildRewardBasedVideoAdClient()
        {
            #if UNITY_EDITOR
                // Testing UNITY_EDITOR first because the editor also responds to the currently
                // selected platform.
                return new GoogleMobileAds.Common.DummyClient();
            #elif UNITY_ANDROID
                return new GoogleMobileAds.Android.RewardBasedVideoAdClient();
            #elif UNITY_IPHONE
                return new GoogleMobileAds.iOS.RewardBasedVideoAdClient();
            #else
                return new GoogleMobileAds.Common.DummyClient();
            #endif
        }
    }
}
