using UnityEngine;
using System;
using System.Collections;

namespace BoosterTracks {
    public class AssetLoader : MonoBehaviour {

        public AssetBundle assetBundle;

        public string Path;

        void Start() {

        }

        public void Unload() {
            assetBundle.Unload(true);
        }

        public void LoadAssets() {
            char dsc = System.IO.Path.DirectorySeparatorChar;

            using (WWW www = new WWW("file://" + Path + dsc + "assetbundle"+dsc+"boostertrackbundle")) {
                if (www.error != null)
                    throw new Exception("Download had an error:" + www.error);

                assetBundle = www.assetBundle;

                assetBundle.Unload(false);
            }
        }

    }
}
