using UnityEngine;
using System;
using System.Collections;

namespace BoosterTracks {
    public class AssetLoader : MonoBehaviour {

        public AssetBundle assetBundle;

        public string Path;

        public Sprite test;

        void Start() {

        }

        public void Unload() {
            assetBundle.Unload(true);
        }

        public UnityEngine.Object LoadAsset(string a) {
            return this.assetBundle.LoadAsset(a);
        }

        public void LoadAssets() {
            char dsc = System.IO.Path.DirectorySeparatorChar;

            using (WWW www = new WWW("file://" + Path + dsc + "assetbundle"+dsc+"boostertrackbundle")) {
                if (www.error != null)
                    throw new Exception("Download had an error:" + www.error);

                assetBundle = www.assetBundle;

                test = Instantiate(assetBundle.LoadAsset<Sprite>("test-sprite"));

                assetBundle.Unload(false);
            }
        }

    }
}
