﻿using System;
using UnityEngine;

namespace BoosterTracks {
    public class BoosterTrackSegment : Straight4 {

        [Serialized]
        protected float acceleration = 0f;

        protected override void initiate(TrackSegment4 previousSegment) {
            base.initiate(previousSegment);
            acceleration = 40f;
        }

        protected override void Awake() {
            // If Track already has custom color
            if (this.customColors == null || GetComponent<CustomColors>() == null) {
                // add customcolor component
                base.Awake();
                // set customcolors to an array with a length of 0
                this.customColors.setColors(new Color[0]);
            }
        }

        /*
        protected override void initiate(TrackSegment4 previousSegment) {
            CubicBezier bez = new CubicBezier();
            bez.p0 = previousSegment.getEndpoint();
            Vector3 dir = previousSegment.getDirection();
            dir *= previousSegment.getLengthMultiplicator() * (float)this.size;
            bez.p3 = bez.p0 + dir;
            bez.p1 = bez.p0 + (bez.p3 - bez.p0) / 3f;
            bez.p2 = bez.p3 - (bez.p3 - bez.p0) / 3f;
            base.addCurve(bez);
        }
        */
        public override float getAcceleration() {
            return acceleration;
        }

        public void setAcceleration(float a) {
            this.acceleration = a;
        }
        
    }
}