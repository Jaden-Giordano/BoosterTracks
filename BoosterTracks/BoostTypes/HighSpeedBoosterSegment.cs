namespace BoosterTracks {
    public class HighSpeedBoosterSegment : BoosterTrackSegment {

        public override void Initialize() {
            base.Initialize();

            this.acceleration = 10f;
        }

    }
}
