using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

namespace Helpers
{
    public static class UnityADSRewardetVideoHelper
    {
        public static bool isReady() => Advertisement.IsReady(placementId: "rewarderVideo");

        public static void Show(Action<ShowResult> callback)
        {
            ShowOptions options = new ShowOptions
            {
                resultCallback = callback
            };
            Advertisement.Show("rewardetVideo", options);
        }
    }
}
