namespace BoosterTracks {
    public class LowSpeedBoosterSegment : BoosterTrackSegment {

        public override void Initialize() {
            base.Initialize();

            this.acceleration = 2.5f;
        }

    }
}
