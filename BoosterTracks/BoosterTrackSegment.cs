using System;

namespace BoosterTracks {
    public class BoosterTrackSegment : Straight4 {

        [Serialized]
        protected float acceleration = 0f;

        public override float getAcceleration() {
            return acceleration;
        }
    }
}