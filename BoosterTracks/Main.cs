using UnityEngine;

namespace BoosterTracks {
    public class Main : IMod {

        SpecialSegmentSettings[] specialSegments;

        GameObject assetLoader;

        public void onEnabled() {
            assetLoader = new GameObject();
            AssetLoader loader = assetLoader.AddComponent<AssetLoader>();
            loader.Path = Path;
            loader.LoadAssets();

            specialSegments = AssetManager.Instance.specialSegments;

            SpecialSegmentSettings[] newSpecialSegments = new SpecialSegmentSettings[specialSegments.Length + 3];
            for (int i = 0; i < specialSegments.Length; i++) {
                newSpecialSegments[i] = specialSegments[i];
            }

            SpecialSegmentSettings lowSpeed = ScriptableObject.CreateInstance<SpecialSegmentSettings>();
            lowSpeed.displayName = "Low Speed Booster Track";
            BoosterTrackSegment bseg = new BoosterTrackSegment();
            bseg.setAcceleration(20f);
            lowSpeed.segmentPrefab = bseg;
            lowSpeed.curveAngle = 0;
            lowSpeed.preview = UnityEngine.Object.Instantiate(loader.test);
            lowSpeed.isInverted = false;
            newSpecialSegments[newSpecialSegments.Length - 3] = lowSpeed;

            AssetManager.Instance.specialSegments = newSpecialSegments;

            foreach (Attraction a in AssetManager.Instance.getAttractionObjects()) {
                if (a is Coaster) {
                    Coaster c = (Coaster)a;
                    c.specialSegments.addSpecialSegment(lowSpeed);
                }
            }
        }

        public void onDisabled() {
            foreach (Attraction a in AssetManager.Instance.getAttractionObjects()) {
                if (a is Coaster) {
                    Coaster c = (Coaster)a;
                    c.specialSegments.removeSpecialSegment(AssetManager.Instance.specialSegments[AssetManager.Instance.specialSegments.Length - 3]);
                    c.specialSegments.removeSpecialSegment(AssetManager.Instance.specialSegments[AssetManager.Instance.specialSegments.Length - 2]);
                    c.specialSegments.removeSpecialSegment(AssetManager.Instance.specialSegments[AssetManager.Instance.specialSegments.Length - 1]);
                }
            }

            UnityEngine.Object.DestroyImmediate(AssetManager.Instance.specialSegments[AssetManager.Instance.specialSegments.Length - 3]);
            UnityEngine.Object.DestroyImmediate(AssetManager.Instance.specialSegments[AssetManager.Instance.specialSegments.Length - 2]);
            UnityEngine.Object.DestroyImmediate(AssetManager.Instance.specialSegments[AssetManager.Instance.specialSegments.Length - 1]);

            AssetManager.Instance.specialSegments = specialSegments;

            assetLoader.GetComponent<AssetLoader>().Unload();

            UnityEngine.Object.DestroyImmediate(assetLoader);
        }

        public string Description {
            get { return "Booster Tracks for those super fast coasters!"; }
        }

        public string Identifier { get; set; }

        public string Name {
            get { return "Booster Tracks"; }
        }

        public string Path { get; set; }

    }
}
