namespace BoosterTracks {
    public class MediumSpeedBoosterSegment : BoosterTrackSegment {

        public override void Initialize() {
            base.Initialize();

            this.acceleration = 5f;
        }

    }
}
