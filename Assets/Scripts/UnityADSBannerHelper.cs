using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

namespace Helpers
{
    public static class UnityADSBannerHelper
    {
        public static bool isReady() => Advertisement.IsReady(placementId: "banner");

        public static void Show(BannerPosition pos)
        {
            Advertisement.Banner.SetPosition(pos);
            Advertisement.Banner.Show(placementId: "banner");
        }
    }
}